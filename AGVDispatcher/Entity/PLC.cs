using AGVDispatcher.App;
using AGVDispatcher.Com;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.Entity
{
    public class PLC : IAGVDevice
    {
        private AGVTCPClient client;
        public AGVTCPClient ComClient => client;
        private AGVComState comstate = AGVComState.OffLine;
        public AGVComState ComState => comstate;

        public byte AGVID { get; private set; }

        public IPAddress IP => ((IPEndPoint)ComClient.Client.Client.RemoteEndPoint).Address;

        public IPAddress ExpectedIP { get; set ; }

        private ushort sid = 1;
        public ushort LatestSerialCode => sid++;

        private AGVServer server;
        private byte[] authcode = new byte[16];

        public AGVServer Server => server;

        public int Order { get; private set; }

        public IOState InputState { get; private set; }
        public IOState OutputState { get; private set; }
        public bool HookState { get; private set; }

        public AGVType @AGVType => AGVType.PLCSimu;
        protected System.Timers.Timer timer;
        public double InfoQueryInterval
        {
            get => timer.Interval;
            set => timer.Interval = value;
        }

        private bool poll_en = false;
        public bool PollInfoEnabled => poll_en;
        public bool PollInfoWaitResponse { get; set; }

        public event OnAGVStateUpdateDlg OnAGVStateUpdate;
        public event OnAGVComStateUpdateDlg OnAGVComStateUpdate;
        public event OnAGVDisconnectedDlg OnAGVDisconnected;

        public bool CheckInputState(int index)
        {
            Contract.Assert(index >= 1 && index <= 5);
            if (index == 5)
                return this.HookState;

            bool rt = ((byte)InputState & (1 << (8 - index))) == 0;
            return !rt;
        }
        public bool CheckOutputState(int index)
        {
            Contract.Assert(index >= 1 && index <= 4);
            bool rt = ((byte)OutputState & (1 << (8 - index))) == 0;
            return !rt;
        }
        public void SetOutputState(int index, bool state)
        {
            Contract.Assert(index >= 1 && index <= 5);
            IOSetMode io = (state ? IOSetMode.Trigger : IOSetMode.Release);
            AGVComData<SetIOData> data = new AGVComData<SetIOData>(this.AGVID,this.LatestSerialCode);
            switch(index)
            {
                case 1: data.PayLoad.ExtIO1 = io; break;
                case 2: data.PayLoad.ExtIO2 = io; break;
                case 3: data.PayLoad.ExtIO3 = io; break;
                case 4: data.PayLoad.ExtIO4 = io; break;
                case 5: data.PayLoad.Hook = io; break;
            }
            this.server.SendData(this, data);

        }
        public void SetComStateFlag(AGVComState flag, AGVComState rflag = 0)
        {
            var before = this.comstate;
            this.comstate |= flag;
            this.comstate &= ~rflag;
            OnAGVComStateUpdate?.Invoke(this, before, this.comstate);
        }

        public void ParseQueryResponse(StateResponseData data)
        {

            InputState = data.InputState;
            OutputState = data.OutputState;
            HookState = data.Hooked;
            if (PollInfoEnabled && PollInfoWaitResponse)
                this.timer.Enabled = true;
            this.OnAGVStateUpdate?.Invoke(this);
        }

        public void SetPassword(string pass)
        {
            for (int i = 0; i < 8; i++)
            {
                authcode[i] = Byte.Parse(pass.Substring(i, 1), System.Globalization.NumberStyles.HexNumber);
            }
        }
        public void SetSalt(byte[] salt)
        {
            Buffer.BlockCopy(salt, 0, authcode, 8, 8);
        }

        public void AuthValidate()
        {
            AGVComData<ValidationData> data = new AGVComData<ValidationData>(AGVID, LatestSerialCode);
            unsafe
            {
                for (int i = 0; i < 16; i++)
                {
                    data.PayLoad.Code[i] = authcode[i];
                }
            }
            this.server.SendData(this, data);
        }

        public PLC()
        {
            timer = new();
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
           
        }

        public void StartInfoPolling()
        {
            poll_en = true;
            timer.Enabled = true;
        }
        public void StartInfoPolling(bool waitandpoll)
        {
            poll_en = true;
            this.PollInfoWaitResponse = waitandpoll;
            timer.Enabled = true;
        }
        public void StopInfoPolling()
        {
            poll_en = false;
            this.timer.Enabled = false;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.comstate == AGVComState.Normal)
            {
                this.SendQueryRequest();
                if (!PollInfoWaitResponse)
                    timer.Enabled = true;
            }
        }

        public void Init(byte id, AGVTCPClient client, AGVServer server, IAGVDevConfig conf)
        {
            this.server = server;
            this.client = client;
            this.AGVID = id;
            this.client.OnDisconnected += (cl) =>
            {
                this.SetComStateFlag(0, AGVComState.OnLine);
                OnAGVDisconnected?.Invoke(this);
            };
            //             this.client.OnDisconnected += (cl) =>
            //             {
            //                 this.SetComStateFlag(0, AGVComState.OnLine);
            //             };
            if (conf != null)
            {
                PLCConfig c = (PLCConfig)conf;
                this.ExpectedIP = IPAddress.Parse(c.IP);
                this.SetPassword(c.Password);
            }
        }

        public void SendQueryRequest()
        {
            AGVComData<QueryStateData> data = new AGVComData<QueryStateData>(this.AGVID, this.LatestSerialCode);
            this.server.SendData(this, data);
        }
    }
}

using AGVDispatcher.App;
using AGVDispatcher.Com;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AGVDispatcher.Entity
{

    public partial class AGV :  IComparable<AGV>, IAGVDevice
    {
        private ushort sid = 1;
        private AGVTCPClient client;
        public AGVTCPClient ComClient => client;
        private AGVComState comstate = AGVComState.Unkown;
        public AGVComState ComState => comstate;
        public byte AGVID { get; private set; }
        public int Order { get; private set; }
        public AGVType @AGVType { get; private set; }
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

        public AGVState State { get; private set; }
        public ushort PhysicPoint { get; private set; }
        protected ushort LogicPoint { get; private set; }
        public DirectionCode Direction { get; private set; }
        public bool HookState { get; private set; }
        public IOState InputState { get; private set; }
        public IOState OutputState { get; private set; }
        public float BatteryVoltage { get; private set; }
        public byte BatteryPercent { get; private set; }
        public AGVWorkState WorkState { get; private set; } = AGVWorkState.NotReady;
        public IPAddress IP => ((IPEndPoint)ComClient.Client.Client.RemoteEndPoint).Address;
        public IPAddress ExpectedIP { get; set; }

        public ushort LatestSerialCode => sid++;
        private AGVServer server;
        public AGVServer Server => server;
        private byte[] authcode = new byte[16];
        public ICollection<byte> AuthCode => Array.AsReadOnly(authcode);
        

        public void SetPassword(string pass)
        {
            for(int i=0;i<8;i+=2)
            {
                authcode[i] = Byte.Parse(pass.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            }

        }

        public void SetSalt(byte[] salt)
        {
            Buffer.BlockCopy(salt, 0, authcode, 8, 8);
        }

        public bool CheckInputState(int index)
        {
            Contract.Assert(index >= 1 && index <= 4);
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
            Contract.Assert(index >= 1 && index <= 4);
            if (state)
                OutputState |= (IOState)(1 << (8 - index));
            else
                OutputState &= (IOState)~(1 << (8 - index));
        }

        public void SetComStateFlag(AGVComState flag,AGVComState rflag = 0)
        {
            var before = this.comstate;
            this.comstate |= flag;
            this.comstate &= ~rflag;
            OnAGVComStateUpdate?.Invoke(this, before, this.comstate);
        }


        public void ParseQueryResponse(StateResponseData data)
        {
            State = data.State;
            PhysicPoint = data.PhysicPoint;
            LogicPoint = data.LogicPoint;
            Direction = data.Direction;
            HookState = data.Hooked;
            InputState = data.InputState;
            OutputState = data.OutputState;
            BatteryVoltage = data.Voltage;
            BatteryPercent = data.BatteryPercent;
            if (PollInfoEnabled && PollInfoWaitResponse)
                this.timer.Enabled = true;
            this.OnAGVStateUpdate?.Invoke(this);
        }

        public void SetWorkState(AGVWorkState state)
        {
            this.WorkState = state;
            this.OnAGVStateUpdate?.Invoke(this);
        }

        public int CompareTo(AGV other)
        {
            return this.Order - other.Order;
        }

        public AGV()
        {
            this.Actions = new AGVBehavior(this);
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
            if(this.comstate == AGVComState.Normal && PollInfoEnabled)
            {
                this.Actions.SendQueryRequest();
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
                AGVConfig c = (AGVConfig)conf;
                if(c.IP is not null)
                    this.ExpectedIP = IPAddress.Parse(c.IP);
                if(c.Password is not null && c.Password.Length > 0)
                    this.SetPassword(c.Password);
                this.Order = c.Order;
            }
        }
    }

}

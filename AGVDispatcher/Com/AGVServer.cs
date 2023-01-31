using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using AGVDispatcher.Com;
using AGVDispatcher.Entity;
using AGVDispatcher.Util;

namespace AGVDispatcher.Com
{
    public delegate void OnAGVAuthResponseDlg(AGVTCPClient client, AGVComData<AuthResponseData> data);
    public delegate void OnAGVValidatResponseDlg(byte agvid, bool success);
    public delegate void OnAGVStateResponseDlg(byte agvid, AGVComData<StateResponseData> data);
    public delegate void OnAGVClientConnectedDlg(AGVTCPClient client);
    public delegate void OnAGVClientDisconnectedDlg(AGVTCPClient client);
    public class AGVServer
    {
        private TCPDriver server;
        public event OnAGVAuthResponseDlg OnAGVAuthResponse;
        public event OnAGVValidatResponseDlg OnAGVValidatResponseDlg;
        public event OnAGVStateResponseDlg OnAGVStateResponse;
        public event OnAGVClientConnectedDlg OnAGVClientConnected;
        public event OnAGVClientDisconnectedDlg OnAGVClientDisconnected;

        public AGVServer()
        {           
            server = new TCPDriver();
            server.OnComClientConnected += Server_OnComClientConnected;
            server.OnComClientDisconneted += Server_OnComClientDisconneted;
            server.OnComDataReceived += Server_OnComDataReceived;
        }

        public void StartServer(ushort port)
        {
            server.SetParameter(IPAddress.Any, port);
            server.Init();
            server.Start();
        }

        public void StopServer(bool abort)
        {
            server.Stop(abort);
        }

        public void SendData<T>(IAGVDevice agv, AGVComData<T> data) where T : IComDataField
        {
            agv.ComClient.Lock();
            server.SendData(agv.ComClient, data.ToArray());
        }


        public void RequestAuth(AGVTCPClient client)
        {
            AGVComData<AuthRequestData> data = new AGVComData<AuthRequestData>(0, 0);
            client.Lock();
            server.SendData(client, data.ToArray());
        }

        private void Server_OnComClientDisconneted(IComClient client)
        {
            client.Disconnect();
            this.OnAGVClientDisconnected?.Invoke((AGVTCPClient)client);
        }

        private void Server_OnComClientConnected(IComClient client)
        {
            this.RequestAuth((AGVTCPClient)client);
            this.OnAGVClientConnected?.Invoke((AGVTCPClient)client);
        }

        private void Server_OnComDataReceived(IComClient client, byte[] data)
        {
            IComData fdata = new AGVComData<IComDataField>();
            fdata.SetBuffer(data);
            ((AGVTCPClient)client).UnLock();

            if (fdata.CheckCode != fdata.CheckSum())
                return;    

            if (fdata.DataType == ComDataType.AuthResponse)
            {
                OnAGVAuthResponse?.Invoke((AGVTCPClient)client, (AGVComData<AuthResponseData>)fdata);
            }
            else if(fdata.DataType == ComDataType.GenralResponse)
            {
                AGVComData<GeneralResponseData> rdata = (AGVComData<GeneralResponseData>)fdata;
                if(rdata.PayLoad.RequestCode == ComDataType.Validation)
                {
                    bool succ = (rdata.PayLoad.ErrorCode == ComErrorCode.Success ? true : false);
                    OnAGVValidatResponseDlg?.Invoke(rdata.AGVID, succ);
                }
            }
            else if(fdata.DataType == ComDataType.StateResponse)
            {
                OnAGVStateResponse?.Invoke(fdata.AGVID, (AGVComData<StateResponseData>)fdata);
            }
            
        }


    }
}

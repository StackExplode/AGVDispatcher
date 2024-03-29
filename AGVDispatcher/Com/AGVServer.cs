﻿using System;
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
    public delegate void OnAGVGeneralResponseDlg(byte agvid, bool succ, AGVComData<GeneralResponseData> data);
    public class AGVServer
    {
        private TCPDriver server;
        public event OnAGVAuthResponseDlg OnAGVAuthResponse;
        public event OnAGVValidatResponseDlg OnAGVValidatResponse;
        public event OnAGVStateResponseDlg OnAGVStateResponse;
        public event OnAGVClientConnectedDlg OnAGVClientConnected;
        public event OnAGVClientDisconnectedDlg OnAGVClientDisconnected;
        public event OnAGVGeneralResponseDlg OnAGVGeneralResponse;

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
            Util.Helpers.SingleAGVDebug(Util.Helpers.DumpComDataRaw(data));
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
            IComData fdata = null;
            bool recfinish = ((AGVTCPClient)client).RecData(data, (bf) =>
             {
                 fdata = new AGVComData<UnknownData>();
                 fdata.SetBuffer(bf);
                 ((AGVTCPClient)client).UnLock();
             });
    
            if (!recfinish)
                return;
            
            if (fdata.CheckCode != fdata.CalcCheckSum())
                return;    

            if (fdata.DataType == ComDataType.AuthResponse)
            {
                OnAGVAuthResponse?.Invoke((AGVTCPClient)client, (fdata.UnsafeAs<AuthResponseData>()));
            }
            else if(fdata.DataType == ComDataType.GenralResponse)
            {
                AGVComData<GeneralResponseData> rdata = fdata.UnsafeAs<GeneralResponseData>();
                bool succ = (rdata.PayLoad.ErrorCode == ComErrorCode.Success ? true : false);
                if (rdata.PayLoad.RequestCode == ComDataType.Validation)
                {
                    OnAGVValidatResponse?.Invoke(rdata.AGVID, succ);
                }
                else
                {
                    OnAGVGeneralResponse?.Invoke(rdata.AGVID, succ, rdata);
                }
                Util.Helpers.SingleAGVDebug("Genetal Response:{0}", rdata.PayLoad.ErrorCode.GetDescription());
            }
            else if(fdata.DataType == ComDataType.StateResponse)
            {
                OnAGVStateResponse?.Invoke(fdata.AGVID, fdata.UnsafeAs<StateResponseData>());
            }
            
        }


    }
}

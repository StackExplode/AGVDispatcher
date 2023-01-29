﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AGVDispatcher.Util;
using AGVDispatcher.Entity;
using AGVDispatcher.Com;
using System.Runtime.InteropServices;
using System.Net;
using System.Threading;

namespace AGVDispatcher.App
{
    public class WareHouse
    {
        private AGVServer server;
        private Dictionary<int, AGV> allagv = new Dictionary<int, AGV>();
        private Dictionary<int, PLC> allplc = new Dictionary<int, PLC>();
        private Config config;
        private AGVDispatcher dispatcher;
        private WareHouseMapv2 _map;
        public event OnDispacherAllFinishedDlg OnDispacherAllFinished;
        public WareHouseMapv2 Map => _map;


        public WareHouse(/*Config cfg*/)
        {
            config = GlobalConfig.Config;
            server = new AGVServer();
            server.OnAGVAuthResponse += Server_OnAGVAuthResponse;
            server.OnAGVValidated += Server_OnAGVValidated;
            server.OnAGVStateResponse += Server_OnAGVStateResponse;

            _map = new WareHouseMapv2();
            dispatcher = new AGVDispatcher(allagv, allplc, _map);
            dispatcher.OnDispacherAllFinished += (a) => { OnDispacherAllFinished?.Invoke(a); };


        }

        private void Server_OnAGVStateResponse(byte agvid, AGVComData<StateResponseData> data)
        {
            if(allagv.ContainsKey(agvid))
            {
                var agv = allagv[agvid];
                agv.ParseQueryResponse(data.PayLoad);
            }
            else if(allplc.ContainsKey(agvid))
            {
                var plc = allplc[agvid];
                plc.ParseQueryResponse(data.PayLoad);
            }
        }

        public async void QueryAGVStateOnce(byte agvid, Action<AGV,bool> callback)
        {
            int tmout = GlobalConfig.Config.SystemConfig.AGVComTimeout;
            bool tout = false;
            AutoResetEvent mutex = new AutoResetEvent(false);
            var agv = allagv[agvid];
            var ddd = new OnAGVStateUpdateDlg((_)=> { mutex.Set(); });
            agv.OnAGVStateUpdate += ddd;
            await Task.Run(() => { agv.Actions.SendQueryRequest(); tout=mutex.WaitOne(tmout); });
            agv.OnAGVStateUpdate -= ddd;
            callback(agv, tout);
        }

        public async void QueryPLCStateOnce(byte plcid, Action<PLC,bool> callback)
        {
            int tmout = GlobalConfig.Config.SystemConfig.AGVComTimeout;
            bool tout = false;
            AutoResetEvent mutex = new AutoResetEvent(false);
            var agv = allplc[plcid];
            var ddd = new OnAGVStateUpdateDlg((_) => { mutex.Set(); });
            agv.OnAGVStateUpdate += ddd;
            await Task.Run(() => { agv.SendQueryRequest(); tout=mutex.WaitOne(tmout); });
            agv.OnAGVStateUpdate -= ddd;
            callback(agv, tout);
        }

        public void StartServer()
        {
            server.StartServer(GlobalConfig.Config.SystemConfig.ListenPort);     
        }

        public async void StopServerAsync(Action callback = null)
        {
            AutoResetEvent mutex = new AutoResetEvent(dispatcher.RunningAGVCount > 0);
            var ddd = new OnDispacherAllFinishedDlg((_) => { mutex.Set(); });
            dispatcher.OnDispacherAllFinished += ddd;
            Task task = new Task(() => { mutex.WaitOne(); server.StopServer(false); });
            task.Start();
            await task;
            dispatcher.OnDispacherAllFinished -= ddd;
            callback?.Invoke();
        }

        public void StopServerAbort()
        {
            server.StopServer(true);
        }

        public bool StartRun()
        {
            if (!dispatcher.CheckAGVReady())
                return false;
            dispatcher.StartRunMissions();
            return true;
        }

        public void EmergencyStop() => dispatcher.EmergencyStop();

        private void Server_OnAGVValidated(byte agvid, bool success)
        {
            AGV agv = allagv[agvid];
            if (success)
            {
                agv.SetComStateFlag(AGVComState.Authorized);
                agv.SetWorkState(AGVWorkState.Idle);
            }
        }

        private void Server_OnAGVAuthResponse(IComClient client, AGVComData<AuthResponseData> data)
        {

            int dd = config.CheckDeviceByID(data.AGVID,out var conf);

            byte[] bb = new byte[8];
            unsafe
            {
                for (int i = 0; i < 8; i++)
                {
                    bb[i] = data.PayLoad.Salt[i];
                }
            }

            if (dd > 0)
            {
                AGV agv;
                
                if(!config.SystemConfig.CheckIP || IPAddress.Parse(conf.IP) == ((AGVTCPClient)client).IP)
                    if (!allagv.ContainsKey(data.AGVID))
                    {
                        agv = new AGV();
                        allagv.Add(data.AGVID, agv);
                    }
                agv = allagv[data.AGVID];      

                agv.Init(data.AGVID, (AGVTCPClient)client, server, conf);
                if (data.PayLoad.IsAuthNeeded)
                { 
                    agv.SetSalt(bb);
                    agv.SetComStateFlag(AGVComState.OnLine);
                    agv.Actions.AuthValidate();
                }
                else
                {
                    agv.SetComStateFlag(AGVComState.Normal);
                    agv.SetWorkState(AGVWorkState.Idle);
                }        
            }
            else if(dd < 0)
            {
                PLC plc;
                
                if (!config.SystemConfig.CheckIP || IPAddress.Parse(conf.IP) == ((AGVTCPClient)client).IP)
                    if (!allplc.ContainsKey(data.AGVID))
                    {
                        plc = new PLC();
                        allplc.Add(data.AGVID, plc);
                    }
                plc = allplc[data.AGVID];

                plc.Init(data.AGVID, (AGVTCPClient)client, server, conf);
                if (data.PayLoad.IsAuthNeeded)
                {
                    plc.SetSalt(bb);
                    plc.SetComStateFlag(AGVComState.OnLine);
                    plc.AuthValidate();
                }
                else
                {
                    plc.SetComStateFlag(AGVComState.Normal);
                }
            }
            else
            {
                client.Disconnect();
            }

        }
    }
}

﻿using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL.v2
{
    public class Action_BackwardAfterPick : IAGVAction
    {
        public bool CheckActionEnd()
        {
            bool rt = endpoint.Equals(agv.PhysicPoint, true);
            Util.Helpers.SingleAGVDebugIf(rt, "Backward from pick point to turn point OK!");
            return rt;
        }

        AGV agv;
        WareHouseMapv2 map;
        int product;
        IPoint endpoint;
        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.agv = agv;
            this.map = (WareHouseMapv2)map;
            this.product = (int)param[0];
        }

        public bool Run()
        {
            (TurnPoint tpt, _) = map.GetPickProductTurnWay(product);
            List<(InsOpCode, byte)> list = new List<(InsOpCode, byte)>();
            endpoint = tpt;

            list.Add(((InsOpCode, byte))(InsOpCode.Stop, StopType.Normal));
            
            agv.Actions.AddOpCache(tpt, list);

            //Hook delay bug
            System.Threading.Thread.Sleep(GlobalConfig.Config.SystemConfig.HookDelay * 1000);

            agv.Actions.RunBackward();
            Task.Delay(200);
            agv.Actions.RunBackward();
            Task.Delay(200);
            agv.Actions.RunBackward();
            Task.Delay(200);

            Util.Helpers.SingleAGVDebug("Start to backward from pick point to turn point!");

            return true;
        }
    }
}

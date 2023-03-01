using AGVDispatcher.App;
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

            ////Hook delay bug
            //System.Threading.Thread.Sleep(GlobalConfig.Config.SystemConfig.HookDelay * 1000);

            //agv.Actions.RunBackward();
            //System.Threading.Thread.Sleep(50);
            //agv.Actions.RunBackward();
            //System.Threading.Thread.Sleep(50);
            //agv.Actions.RunBackward();
            //System.Threading.Thread.Sleep(50);

            var ppt = map.GetPickProductPoint(product);
            list.Clear();
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.HookDelay));
            list.Add((InsOpCode.Run, (byte)OpRunParam.Backward));
            agv.Actions.AddOpCache(ppt, list);

            System.Threading.Thread.Sleep(50);
            agv.Actions.ForceStation(ppt);

            Util.Helpers.SingleAGVDebug("Start to backward from pick point to turn point!");

            return true;
        }
    }
}

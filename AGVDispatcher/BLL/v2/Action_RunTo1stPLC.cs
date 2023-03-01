using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL.v2
{
    public class Action_RunTo1stPLC : IAGVAction
    {
        public bool CheckActionEnd()
        {
            bool con1 = wpt.Equals(agv.PhysicPoint, true);
            bool con2 = (agv.HookState == false);
            Util.Helpers.SingleAGVDebugIf(con1 && con2, "Run to WorkPt1 OK!Hook down OK!");
            return con1 && con2;
        }

        AGV agv;
        WareHouseMapv2 map;
        int product;
        WorkPoint wpt;
        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.agv = agv;
            this.map = (WareHouseMapv2)map;
            this.product = (int)param[0];
            wpt = map.GetWorkStationPoint(1);
        }

        public bool Run()
        {
            map.PickBusy = false;

            (TurnPoint tpt, _) = map.GetPickProductTurnWay(product);

            List<(InsOpCode, byte)> list = new List<(InsOpCode, byte)>();
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.StopDelay));
            //Stright bug
            list.Add(((InsOpCode, byte))(InsOpCode.Run, OpRunParam.Foreward));
            list.Add(((InsOpCode, byte))(InsOpCode.Turn, OpTurnType.LeftTurn));
            agv.Actions.AddOpCache(tpt, list);

            list.Clear();
            list.Add((InsOpCode.Stop, (byte)StopType.Normal));
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.StopDelay));
            list.Add((InsOpCode.Hook, (byte)OpHookParam.Release));  //2 = Release
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.HookDelay));
            agv.Actions.AddOpCache(wpt, list);

            agv.Actions.ForceStation(tpt);

            Util.Helpers.SingleAGVDebug("Start to run to 1st WorkPt from Pick turn point");

            return true;
        }
    }
}

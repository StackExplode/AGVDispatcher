using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL
{
    public class Action_BreakeZoneTo1stPLC : IAGVAction
    {
        private AGV agv;
        private int product;
        private WareHouseMap map;

        public bool CheckActionEnd()
        {
            bool con1 = (map.GetWorkStationPoint(1).Equals(agv.PhysicPoint, true));
            bool con2 = (agv.HookState == false);
            return (con1 && con2);
        }

        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.agv = agv;
            this.map = map;
            this.product = (int)param[0];
        }

        public bool Run()
        {
            (TurnPoint point, TurnType turn) = map.GetPickProductTurnWay(product);
            List<(InsOpCode, byte)> list = new List<(InsOpCode, byte)>();
            if(turn != TurnType.NoChange)
            {
                list.Add((InsOpCode.Turn, (byte)((byte)turn - 2)));
                agv.Actions.AddOpCache(point, list);
            }

            list.Clear();
            list.Add((InsOpCode.Stop, (byte)StopType.Normal));
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.StopDelay));
            list.Add((InsOpCode.Hook, (byte)OpHookParam.Hookup));  //1 = Hook up
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.HookDelay));
            list.Add((InsOpCode.Run, (byte)OpRunParam.SameAsLast));   //2 = Same as last direction
            agv.Actions.AddOpCache(map.GetPickProductPoint(product), list);

            list.Clear();
            list.Add((InsOpCode.Stop, (byte)StopType.Normal));
            list.Add((InsOpCode.Hook, (byte)OpHookParam.Release));  //0 = Hook release
            agv.Actions.AddOpCache(map.GetWorkStationPoint(1), list);

            agv.Actions.RunStraigth();

            return true;
        }
    }
}

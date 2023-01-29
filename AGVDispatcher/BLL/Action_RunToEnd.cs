using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL
{
    public class Action_RunToEnd : IAGVAction
    {
        AGV agv;
        WareHouseMap map;
        int product;

        public bool CheckActionEnd()
        {
            return (map.BKEnterPoint.Equals(agv.PhysicPoint, true));
        }

        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.agv = agv;
            this.map = map;
            this.product = (int)param[0];
        }

        public bool Run()
        {
            List<(InsOpCode, byte)> list = new List<(InsOpCode, byte)>();

            IPoint plc3_pt = map.GetWorkStationPoint(3);
            list.Add((InsOpCode.Hook, (byte)OpHookParam.Hookup));
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.HookDelay));
            list.Add((InsOpCode.Run, (byte)OpRunParam.SameAsLast));
            agv.Actions.AddOpCache(plc3_pt, list);

            list.Clear();
            var turn = map.PutProductTurnWay(this.product);
            if(turn.Item2 != TurnType.NoChange)
            {
                list.Add((InsOpCode.Turn, (byte)((byte)turn.Item2 - 2)));
                agv.Actions.AddOpCache(turn.Item1, list);
            }

            list.Clear();
            var prod_pt = map.GetPutProductPoint(this.product);
            list.Add((InsOpCode.Stop, (byte)StopType.Normal));
            list.Add((InsOpCode.Hook, (byte)OpHookParam.Release));
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.HookDelay));
            list.Add((InsOpCode.Run, (byte)OpRunParam.SameAsLast));
            agv.Actions.AddOpCache(prod_pt, list);

            list.Clear();
            list.Add((InsOpCode.Stop, (byte)StopType.Normal));
            agv.Actions.AddOpCache(map.BKEnterPoint , list);

            return true;
        }
    }
}

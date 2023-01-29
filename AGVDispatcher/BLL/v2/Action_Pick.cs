using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL.v2
{
    public class Action_Pick : IAGVAction
    {
        public bool CheckActionEnd()
        {
            bool con1 = map.GetPickProductPoint(prod).Equals(agv.PhysicPoint, true);
            bool con2 = agv.HookState == true;
            return con1 && con2;
        }

        AGV agv;
        WareHouseMapv2 map;
        int prod;
        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.agv = agv;
            this.map = (WareHouseMapv2)map;
            this.prod = (int)param[0];
        }

        public bool Run()
        {
            map.PickBusy = true;

            (TurnPoint point, TurnType turn) = map.PickProductTurnWay(prod);
            List<(InsOpCode, byte)> list = new List<(InsOpCode, byte)>();

            if (turn != TurnType.NoChange)
            {
                list.Add((InsOpCode.Turn, (byte)((byte)turn - 2)));
                agv.Actions.AddOpCache(point, list);
            }
            else
            {
                list.Add(((InsOpCode, byte))(InsOpCode.Run, OpRunParam.SameAsLast));
                agv.Actions.AddOpCache(point, list);
            }

            for (ushort i = 0; i<map.MAX_PROD; i++)
            {
                if(i != prod)
                {
                    (TurnPoint pt, _) = map.PickProductTurnWay(i);
                    list.Clear();
                    list.Add(((InsOpCode, byte))(InsOpCode.Run, OpRunParam.SameAsLast));
                    agv.Actions.AddOpCache(pt, list);
                }
            }

            list.Clear();
            list.Add((InsOpCode.Stop, (byte)StopType.Normal));
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.StopDelay));
            list.Add((InsOpCode.Hook, (byte)OpHookParam.Hookup));  //1 = Hook up
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.HookDelay));
            //list.Add((InsOpCode.Run, (byte)OpRunParam.ReverseAsLast));   //3 = Reverse from last direction
            agv.Actions.AddOpCache(map.GetPickProductPoint(prod), list);

            agv.Actions.RunStraigth();

            return true;
        }
    }
}

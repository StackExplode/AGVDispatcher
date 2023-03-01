using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGVDispatcher.Util;

namespace AGVDispatcher.BLL.v2
{
    public class Action_Pick : IAGVAction
    {
        public bool CheckActionEnd()
        {
            bool con1 = map.GetPickProductPoint(prod).Equals(agv.PhysicPoint, true);
            bool con2 = agv.HookState == true;
            //Util.Helpers.SingleAGVDebug("Prod={0}, agv={1}", map.GetPickProductPoint(prod).PhysicID, agv.PhysicPoint);
            Util.Helpers.SingleAGVDebugIf(con1 && con2, "Hook is up, pick ok! ProdID={0}", prod);
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

            (TurnPoint point, TurnType turn) = map.GetPickProductTurnWay(prod);
            List<(InsOpCode, byte)> list = new List<(InsOpCode, byte)>();

            OpTurnType debug;

            for (ushort i = 1; i<=map.MAX_PROD; i++)
            {
                if(i != prod)
                {
                    (TurnPoint pt, _) = map.GetPickProductTurnWay(i);
                    list.Clear();
                    //Same As Last not work, for AGV can never detect what is front or back!
                    list.Add(((InsOpCode, byte))(InsOpCode.Turn, OpTurnType.LeftTurn));
                    agv.Actions.AddOpCache(pt, list);
                    //Task.Delay(200);
                }
            }
            System.Threading.Thread.Sleep(150);
            list.Clear();
            if (turn != TurnType.NoChange)
            {
                list.Add((InsOpCode.Turn, (byte)((byte)turn - 2)));
                list.Add((InsOpCode.SetSpeed, 20));
                agv.Actions.AddOpCache(point, list);
                debug = (OpTurnType)((byte)turn - 2);
            }
            else
            {
                list.Add(((InsOpCode, byte))(InsOpCode.Run, OpRunParam.SameAsLast));
                list.Add((InsOpCode.SetSpeed, 20));
                agv.Actions.AddOpCache(point, list);
                debug = (OpTurnType)((byte)turn - 2);
            }

            list.Clear();
            list.Add((InsOpCode.Stop, (byte)StopType.Normal));
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.StopDelay));
            list.Add((InsOpCode.Hook, (byte)OpHookParam.Hookup));  //1 = Hook up
            list.Add((InsOpCode.SetSpeed, 40));
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.HookDelay));
            //list.Add((InsOpCode.Run, (byte)OpRunParam.ReverseAsLast));   //3 = Reverse from last direction
            agv.Actions.AddOpCache(map.GetPickProductPoint(prod), list);

            Util.Helpers.SingleAGVDebug($"Start to pick prod, prodid={prod}, TurnPt={point.LogicID}[{point.PhysicID}], dir={debug.GetDescription()}");
            agv.Actions.RunStraigth();


            return true;
        }
    }
}

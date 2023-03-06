using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL.v2
{
    public class Action_Put : IAGVAction
    {
        public bool CheckActionEnd()
        {
            bool con1 = map.GetPutProductPoint(prod).Equals(agv.PhysicPoint, true);
            bool con2 = (agv.HookState == false);
            Util.Helpers.SingleAGVDebugIf(con1 && con2, "Put finished, and Hook is down! ProdID={0}", prod);
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
            bool issp = map.IsPutProdctSpecial(prod);
            if (issp)
                map.PutSpBusy = true;
            else
                map.PutBusy = true;

            List<(InsOpCode, byte)> list = new List<(InsOpCode opcode, byte param)>();
            (TurnPoint pt, TurnType turn) = map.GetPutProductTurnWay(prod);

            if (issp)
                list.Add(((InsOpCode, byte))(InsOpCode.Turn, OpTurnType.LeftTurn));
            else
                list.Add(((InsOpCode, byte))(InsOpCode.Run, OpRunParam.SameAsLast));
            agv.Actions.AddOpCache(map.PutWaitPoint, list);

            for(int i=1;i<=map.MAX_PROD;i++)
            {
                if(i != prod)
                {
                    list.Clear();
                    (TurnPoint ppt, _) = map.GetPutProductTurnWay(i);
                    //Stright bug
                    list.Add(((InsOpCode, byte))(InsOpCode.Turn, OpTurnType.LeftTurn));
                    agv.Actions.AddOpCache(ppt, list);
                    //Task.Delay(200);
                }
            }

            list.Clear();
            if (turn != TurnType.NoChange)
            {
                list.Add((InsOpCode.Turn, (byte)((byte)turn - 2)));
                list.Add((InsOpCode.SetSpeed, 20));
                agv.Actions.AddOpCache(pt, list);
            }
            else
            {
                list.Add(((InsOpCode, byte))(InsOpCode.Run, OpRunParam.SameAsLast));
                list.Add((InsOpCode.SetSpeed, 20));
                agv.Actions.AddOpCache(pt, list);
            }

            list.Clear();
            list.Add(((InsOpCode, byte))(InsOpCode.Stop, StopType.Normal));
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.StopDelay));
            list.Add(((InsOpCode, byte))(InsOpCode.Hook, OpHookParam.Release));
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.HookDelay));
            agv.Actions.AddOpCache(map.GetPutProductPoint(prod), list);

            agv.Actions.ForceStation(map.PutWaitPoint);

            Util.Helpers.SingleAGVDebug("Start to put product! ProdID={0}", prod);

            return true;
        }
    }
}

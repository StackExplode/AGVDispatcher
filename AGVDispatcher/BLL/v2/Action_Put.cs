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
            (TurnPoint pt, TurnType turn) = map.PutProductTurnWay(prod);

            if (issp)
                list.Add(((InsOpCode, byte))(InsOpCode.Turn, OpTurnType.LeftTurn));
            else
                list.Add(((InsOpCode, byte))(InsOpCode.Run, OpRunParam.SameAsLast));
            agv.Actions.AddOpCache(map.PutWaitPoint, list);

            for(int i=0;i<map.MAX_PROD;i++)
            {
                if(i != prod)
                {
                    list.Clear();
                    (TurnPoint ppt, _) = map.PutProductTurnWay(i);
                    list.Add(((InsOpCode, byte))(InsOpCode.Run, OpRunParam.SameAsLast));
                    agv.Actions.AddOpCache(ppt, list);
                }
            }

            list.Clear();
            if (turn != TurnType.NoChange)
            {
                list.Add((InsOpCode.Turn, (byte)((byte)turn - 2)));
                agv.Actions.AddOpCache(pt, list);
            }
            else
            {
                list.Add(((InsOpCode, byte))(InsOpCode.Run, OpRunParam.SameAsLast));
                agv.Actions.AddOpCache(pt, list);
            }

            list.Clear();
            list.Add(((InsOpCode, byte))(InsOpCode.Stop, StopType.Normal));
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.StopDelay));
            list.Add(((InsOpCode, byte))(InsOpCode.Hook, OpHookParam.Release));
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.HookDelay));
            agv.Actions.AddOpCache(map.GetPutProductPoint(prod), list);

            agv.Actions.ForceStation(map.PutWaitPoint);

            return true;
        }
    }
}

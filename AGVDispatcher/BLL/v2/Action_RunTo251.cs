using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL.v2
{
    public class Action_RunTo251 : IAGVAction
    {
        public bool CheckActionEnd()
        {
            if (skip)
                return false;

            return map.BreakWaitPoint.Equals(agv.PhysicPoint, true);

        }

        AGV agv;
        WareHouseMapv2 map;
        int prod;
        bool skip = false;
        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.agv = agv;
            this.map = (WareHouseMapv2)map;
            this.prod = (int)param[0];
        }

        public bool Run()
        {
            if(map.IsPutProdctSpecial(prod))
            {
                skip = true;
                map.PutSpBusy = false;
                return false;
            }

            map.PutBusy = false;
            List<(InsOpCode, byte)> list = new List<(InsOpCode opcode, byte param)>();
            (TurnPoint pt, TurnType turn) = map.GetPutProductTurnWay(prod);

            
            if (turn == TurnType.NoChange)
                list.Add(((InsOpCode, byte))(InsOpCode.Turn, OpTurnType.LeftTurn));
            else
                list.Add(((InsOpCode, byte))(InsOpCode.Run, OpRunParam.Foreward));
            agv.Actions.AddOpCache(pt, list);

            list.Clear();
            list.Add(((InsOpCode, byte))(InsOpCode.Stop, StopType.Normal));
            agv.Actions.AddOpCache(map.BreakWaitPoint, list);

            agv.Actions.ForceStation(pt);

            return true;
        }
    }
}

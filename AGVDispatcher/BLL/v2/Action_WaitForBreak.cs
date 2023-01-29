using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL.v2
{
    public class Action_WaitForBreak : IAGVAction
    {
        public bool CheckActionEnd()
        {
            if (busy)
                return map.PutSpBusy;
            else
                return false;
        }

        WareHouseMapv2 map;
        bool busy = false;
        int prod;
        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.map = (WareHouseMapv2)map;
            prod = (int)param[0];
        }

        public bool Run()
        {
            if (map.IsPutProdctSpecial(prod))
            {
                busy = false;
            }
            else
            {
                busy = map.PutSpBusy;
            }

            return busy;
        }
    }
}

using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL.v2
{
    public class Action_WaitForPut : IAGVAction
    {
        public bool CheckActionEnd()
        {
            if (busy)
            {
                if (map.IsPutProdctSpecial(prod))
                    return !map.PutSpBusy;
                else
                    return !map.PutBusy;
            }
            else
                return true;
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
            if(map.IsPutProdctSpecial(prod))
            {
                busy = map.PutSpBusy;
            }
            else
            {
                busy = map.PutBusy;
            }
            Util.Helpers.SingleAGVDebug("Wait for put, busy={0}", busy);
            return busy;
        }
    }
}

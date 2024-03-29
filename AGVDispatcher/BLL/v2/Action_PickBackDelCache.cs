﻿using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL.v2
{
    public class Action_PickBackDelCache : IAGVAction
    {
        protected AGV agv;
        protected int prod;
        protected WareHouseMapv2 map;
        public bool CheckActionEnd()
        {
            return false;
        }

        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.agv = agv;
            prod = (int)param[0];
            this.map = (WareHouseMapv2)map;
        }

        public virtual bool Run()
        {
            
            var pt1 = map.GetPickProductPoint(prod);
            agv.Actions.DelOPCache(pt1);
            (IPoint pt, _) = map.GetPickProductTurnWay(prod);
            //agv.Actions.DelOPCache(pt);
            agv.Actions.ClearOPCache();
            Util.Helpers.SingleAGVDebug("Delete Pickpoint cache!");
            return false;
        }
    }

    public class Action_PutBackDelCache : Action_PickBackDelCache
    {
        public override bool Run()
        {
            
            agv.Actions.DelOPCache(map.GetPutProductPoint(prod));
            (IPoint pt, _) = map.GetPutProductTurnWay(prod);
            //agv.Actions.DelOPCache(pt);
            agv.Actions.ClearOPCache();
            Util.Helpers.SingleAGVDebug("Clear putpoint cache!");
            return false;
        }
    }
}

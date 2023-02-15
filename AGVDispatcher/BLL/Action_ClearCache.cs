using AGVDispatcher.App;
using AGVDispatcher.Entity;
using AGVDispatcher.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL
{
    class Action_ClearCache : IAGVAction
    {
        private AGV agv;
        public bool CheckActionEnd()
        {
            return false;
        }

        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.agv = agv;
        }

        public bool Run()
        {
            agv.Actions.ClearOPCache();
            Helpers.SingleAGVDebug("Clear All Cache!");
            return false;
        }
    }
}

using AGVDispatcher.App;
using AGVDispatcher.Entity;
using AGVDispatcher.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL.v2
{
    public class Action_WaitForPick : AGVDispatcher.BLL.IAGVAction
    {
        public bool CheckActionEnd()
        {
            if (busy)
                return !map.PickBusy;
            else
                return true;
        }

        WareHouseMapv2 map;
        bool busy = false;
        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.map = (WareHouseMapv2)map;
        }

        public bool Run()
        {
            busy = map.PickBusy;
            Helpers.SingleAGVDebug("Wait for enter pick, busy={0}.", busy);
            return busy;
        }
    }
}

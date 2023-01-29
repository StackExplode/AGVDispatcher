using AGVDispatcher.App;
using AGVDispatcher.Entity;
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
                return map.PickBusy;
            else
                return false;
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
            return busy;
        }
    }
}

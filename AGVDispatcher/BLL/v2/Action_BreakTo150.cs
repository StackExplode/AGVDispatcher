using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AGVDispatcher.BLL.v2
{
    class Action_BreakTo150 : AGVDispatcher.BLL.IAGVAction
    {
        public bool CheckActionEnd()
        {
            return (map.PickWaitPoint.Equals(agv.PhysicPoint, true));
        }

        AGV agv;
        WareHouseMapv2 map;

        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.agv = agv;
            this.map = (WareHouseMapv2)map;
        }

        public bool Run()
        {
            agv.Actions.SetAutoStop(map.PickWaitPoint);
            agv.Actions.RunStraigth();
            return true;
        }
    }
}

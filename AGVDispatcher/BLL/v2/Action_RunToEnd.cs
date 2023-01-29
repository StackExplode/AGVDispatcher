using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL.v2
{
    public class Action_RunToEnd : IAGVAction
    {
        private AGV agv;
        private WareHouseMapv2 map;

        public bool CheckActionEnd()
        {
            return (map.BKEnterPoint.Equals(agv.PhysicPoint, true));
        }


        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.agv = agv;
            this.map = (WareHouseMapv2)map;
        }

        public bool Run()
        {
            List<(InsOpCode, byte)> list = new List<(InsOpCode, byte)>();
            list.Add((InsOpCode.Stop, (byte)StopType.Normal));
            agv.Actions.AddOpCache(map.BKEnterPoint, list);

            agv.Actions.RunStraigth();

            return true;
        }
    }
}

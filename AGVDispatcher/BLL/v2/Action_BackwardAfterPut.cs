using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL.v2
{
    public class Action_BackwardAfterPut : IAGVAction
    {
        public bool CheckActionEnd()
        {
            return endpoint.Equals(agv.PhysicPoint, true);
        }

        AGV agv;
        WareHouseMapv2 map;
        int product;
        IPoint endpoint;
        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.agv = agv;
            this.map = (WareHouseMapv2)map;
            this.product = (int)param[0];
        }

        public bool Run()
        {
            List<(InsOpCode, byte)> list = new List<(InsOpCode opcode, byte param)>();
            (TurnPoint pt, _) = map.PutProductTurnWay(product);
            endpoint = pt;

            list.Add(((InsOpCode, byte))(InsOpCode.Stop, StopType.Normal));
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.StopDelay));
            agv.Actions.AddOpCache(pt, list);

            agv.Actions.RunBackward();

            return true;
        }
    }
}

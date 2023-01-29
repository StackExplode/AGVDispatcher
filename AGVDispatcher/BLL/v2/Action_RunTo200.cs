using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL.v2
{
    public class Action_RunTo200 : IAGVAction
    {
        public bool CheckActionEnd()
        {
            return map.PutWaitPoint.Equals(agv.PhysicPoint, true);
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
            List<(InsOpCode, byte)> list = new List<(InsOpCode, byte)>();
            WorkPoint wpt = map.GetWorkStationPoint(3);

            list.Add(((InsOpCode, byte))(InsOpCode.Hook, OpHookParam.Hookup));
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.HookDelay));
            list.Add(((InsOpCode, byte))(InsOpCode.Run, OpRunParam.SameAsLast));
            agv.Actions.AddOpCache(wpt, list);

            agv.Actions.SetAutoStop(map.PutWaitPoint);

            agv.Actions.ForceStation(wpt);

            return true;

        }
    }
}

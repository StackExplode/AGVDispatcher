using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL
{
    public class Action_RunTo2ndPLC : IAGVAction
    {
        AGV agv;
        WareHouseMap map;
        protected virtual int start_plc => 1;
        protected virtual int end_plc => 2;

        public virtual bool CheckActionEnd()
        {
            bool con1 = (map.GetWorkStationPoint(end_plc).Equals(agv.PhysicPoint,true));
            bool con2 = (agv.HookState == false);
            return (con1 && con2);
        }

        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.agv = agv;
            this.map = map;
        }

        public virtual bool Run() 
        {
            List<(InsOpCode, byte)> lst = new List<(InsOpCode opcode, byte param)>();

            lst.Add((InsOpCode.Hook, (byte)OpHookParam.Hookup));
            lst.Add(((InsOpCode.Delay), GlobalConfig.Config.SystemConfig.HookDelay));
            lst.Add((InsOpCode.Run, (byte)OpRunParam.SameAsLast));
            agv.Actions.AddOpCache(map.GetPickProductPoint(start_plc), lst);

            lst.Clear();
            lst.Add((InsOpCode.Stop, (byte)StopType.Normal));
            lst.Add(((InsOpCode.Delay), GlobalConfig.Config.SystemConfig.StopDelay));
            lst.Add((InsOpCode.Hook, (byte)OpHookParam.Release));
            lst.Add(((InsOpCode.Delay), GlobalConfig.Config.SystemConfig.HookDelay));
            agv.Actions.AddOpCache(map.GetPickProductPoint(end_plc), lst);

            agv.Actions.ForceStation(map.GetPickProductPoint(start_plc));

            return true;
        }
    }

    public class Action_RunTo3rdPLC : Action_RunTo2ndPLC
    {
        protected override int start_plc => 2;
        protected override int end_plc => 3;
    }
}

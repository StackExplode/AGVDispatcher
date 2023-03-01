using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL
{
    public class Action_CallPLCWork : IAGVAction
    {
        protected bool WORK_LEVEL { get; set; } 
        protected bool FINISH_LEVEL { get; set; } 
        protected int WORK_IO { get; set; } 
        protected int FINISH_IO { get; set; } 

        protected int PLCNum { get; set; }
        private Dictionary<int, PLC> plcs;
        private WareHouseMap map;
        private byte workstation;
        WorkPoint workpt;

        public Action_CallPLCWork(byte workstation)
        {
            this.workstation = workstation;
        }

        public bool CheckActionEnd()
        {
            bool rt = (plcs[PLCNum].CheckInputState(FINISH_IO) == FINISH_LEVEL);
#warning For Debug only!!
            if (workstation != 1)
                rt = true;
            Util.Helpers.SingleAGVDebugIf(rt, "WorkPt{0} finish signal rec!", workstation);
            return rt;
        }

        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.plcs = plcs;
            this.map = map;

           
            workpt = map.GetWorkStationPoint(workstation);
            PLCNum = GlobalConfig.Config.GetPLCByOrder(workpt.PLCOrder);
            this.WORK_LEVEL = workpt.WorkLevel;
            this.FINISH_LEVEL = workpt.FinishLevel;
            this.WORK_IO = workpt.WorkIO;
            this.FINISH_IO = workpt.FinishIO;
        }

        public bool Run()
        {
            //Hook delay bug
            System.Threading.Thread.Sleep(GlobalConfig.Config.SystemConfig.HookDelay * 1000);
            if (workpt.GetType() != typeof(CheckPoint))
                plcs[PLCNum].WriteOutputState(WORK_IO, WORK_LEVEL);
            Util.Helpers.SingleAGVDebug("Call WorkPt{0} to work! IO={1},Level={2}", workstation, WORK_IO, WORK_LEVEL);
            return true;
        }
    }


}

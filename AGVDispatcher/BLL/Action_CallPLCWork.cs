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

        protected int PLCNum { get; init; }
        private Dictionary<int, PLC> plcs;
        private WareHouseMap map;

        public Action_CallPLCWork(byte workstation)
        {
            var workpt = map.GetWorkStationPoint(workstation);
            PLCNum = GlobalConfig.Config.GetPLCByOrder(workpt.PLCOrder);
            this.WORK_LEVEL = workpt.WorkLevel;
            this.FINISH_LEVEL = workpt.FinishLevel;
            this.WORK_IO = workpt.WorkIO;
            this.FINISH_IO = workpt.FinishIO;
        }

        public bool CheckActionEnd()
        {
            return (plcs[PLCNum].CheckInputState(FINISH_IO) == FINISH_LEVEL);
        }

        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.plcs = plcs;
            this.map = map;
        }

        public bool Run()
        {
            plcs[PLCNum].SetOutputState(WORK_IO, WORK_LEVEL);
            return true;
        }
    }


}

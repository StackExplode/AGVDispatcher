using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL
{
    public class Action_Custom : IAGVAction
    {
        public Func< Action_Custom, bool> RunDelegate { get; set; }
        public Func< Action_Custom, bool> CheckDelegate { get; set; }
        public AGV TheAGV { get; set; }
        Dictionary<int, PLC> PLCs { get; set; }
        WareHouseMap Map { get; set; }
        object[] Parameters { get; set; }

        public bool CheckActionEnd()
        {
            if (CheckDelegate != null)
                return CheckDelegate(this);
            else
                return false;
        }

        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            TheAGV = agv;
            PLCs = plcs;
            Map = map;
            Parameters = param;
        }

        public bool Run()
        {
            if (RunDelegate != null)
                return RunDelegate(this);
            else
                return false;
        }
    }
}

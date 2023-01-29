using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using AGVDispatcher.Entity;
using AGVDispatcher.App;

namespace AGVDispatcher.BLL
{
    public interface IAGVAction
    {
        public bool Run();
        public bool CheckActionEnd();

        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param);
    }


}

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
        protected AGV agv;
        protected WareHouseMapv2 map;
        protected int product;

        public bool CheckActionEnd()
        {
            bool rt = (map.BKEnterPoint.Equals(agv.PhysicPoint, true));
            Util.Helpers.SingleAGVDebugIf(rt, "Arrive at end point!");
            return rt;
        }


        public void Init(AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map, params object[] param)
        {
            this.agv = agv;
            this.map = (WareHouseMapv2)map;
            this.product = (int)param[0];
        }

        public virtual bool Run()
        {
            List<(InsOpCode, byte)> list = new List<(InsOpCode, byte)>();
            list.Add((InsOpCode.Stop, (byte)StopType.Normal));
            agv.Actions.AddOpCache(map.BKEnterPoint, list);

            agv.Actions.RunStraigth();

            return true;
        }
    }

    public class Action_RunToEnd_v3 : Action_RunToEnd
    {
        public override bool Run()
        {
            map.PutBusy = false;
            map.PutSpBusy = false;

            (TurnPoint tpt, _) = map.GetPutProductTurnWay(product);

            List<(InsOpCode, byte)> list = new List<(InsOpCode, byte)>();
            list.Add((InsOpCode.Delay, GlobalConfig.Config.SystemConfig.StopDelay));
            //Stright bug
            list.Add(((InsOpCode, byte))(InsOpCode.Turn, OpTurnType.LeftTurn));
            agv.Actions.AddOpCache(tpt, list);


            list.Clear();
            list.Add((InsOpCode.Stop, (byte)StopType.Normal));
            agv.Actions.AddOpCache(map.BKEnterPoint, list);

            agv.Actions.ForceStation(tpt);

            Util.Helpers.SingleAGVDebug("Start to run to End Point from Pick turn point");

            return true;
        }
    }
}

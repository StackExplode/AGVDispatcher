using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.Entity
{
    public partial class AGV : IAGVDevice
    {
        public AGVBehavior Actions { get; }
        public class AGVBehavior
        {
            private AGV agv;
            public AGVBehavior(AGV agv)
            {
                this.agv = agv;
            }
            public void RunStraigth()
            {
                AGVComData<StartRunData> data = new AGVComData<StartRunData>(agv.AGVID, agv.LatestSerialCode);
                data.PayLoad.Direction = DirectionCode.Forward;
                agv.server.SendData(agv, data);
            }

            public void RunBackward()
            {
                AGVComData<StartRunData> data = new AGVComData<StartRunData>(agv.AGVID, agv.LatestSerialCode);
                data.PayLoad.Direction = DirectionCode.Backward;
                agv.server.SendData(agv, data);
            }

            public void RunAsLast()
            {
                AGVComData<StartRunData> data = new AGVComData<StartRunData>(agv.AGVID, agv.LatestSerialCode);
                data.PayLoad.Direction = DirectionCode.SameAsLast;
                agv.server.SendData(agv, data);
            }

            public void StopRun(StopType st)
            {
                AGVComData<StopRunData> data = new AGVComData<StopRunData>(agv.AGVID, agv.LatestSerialCode);
                data.PayLoad.StopType = st;
                agv.server.SendData(agv, data);
            }

            public void AuthValidate()
            {
                AGVComData<ValidationData> data = new AGVComData<ValidationData>(agv.AGVID, agv.LatestSerialCode);
                unsafe
                {
                    for (int i = 0; i < 16; i++)
                    {
                        data.PayLoad.Code[i] = agv.authcode[i];
                    }
                }
                agv.server.SendData(agv, data);
            }

            public void SetAutoStop(IPoint goal)
            {
                AGVComData<SetPointInsCacheData> data = new AGVComData<SetPointInsCacheData>(agv.AGVID, agv.LatestSerialCode);
                data.PayLoad.Point = goal.PhysicID;
                data.PayLoad.CacheOP = CacheOpCode.Create;
                ref var ins1 = ref data.PayLoad.Instructions(1);
                ins1.OpCode = InsOpCode.Stop;
                ins1.Param = 0; //Forward
                agv.server.SendData(agv, data);
            }

            public void DelOPCache(IPoint point)
            {
                AGVComData<SetPointInsCacheData> data = new AGVComData<SetPointInsCacheData>(agv.AGVID, agv.LatestSerialCode);
                data.PayLoad.CacheOP = CacheOpCode.Delete;
                data.PayLoad.Point = point.PhysicID;
                Task.Delay(200);
                agv.server.SendData(agv, data);
            }

            public void ClearOPCache()
            {
                AGVComData<SetPointInsCacheData> data = new AGVComData<SetPointInsCacheData>(agv.AGVID, agv.LatestSerialCode);
                data.PayLoad.CacheOP = CacheOpCode.Clear;
                agv.server.SendData(agv, data);
            }

            public void AddOpCache(IPoint point, List<(InsOpCode opcode, byte param)> insts)
            {
                AGVComData<SetPointInsCacheData> data = new AGVComData<SetPointInsCacheData>(agv.AGVID, agv.LatestSerialCode);
                data.PayLoad.CacheOP = CacheOpCode.Create;
                data.PayLoad.Point = point.PhysicID;
                for(int i = 0;i < insts.Count; i++)
                {
                    ref var ins = ref data.PayLoad.Instructions(i + 1);
                    ins.OpCode = insts[i].opcode;
                    ins.Param = insts[i].param;
                }
                Task.Delay(200);
                agv.server.SendData(agv, data);
            }

            public void EmergStop()
            {
                AGVComData<ButtonSimulateData> data = new AGVComData<ButtonSimulateData>(agv.AGVID, agv.LatestSerialCode);
                data.PayLoad.EmergencyStop = true;
                agv.server.SendData(agv, data);
            }

            public void AGVReady()
            {
                AGVComData<ButtonSimulateData> data = new AGVComData<ButtonSimulateData>(agv.AGVID, agv.LatestSerialCode);
                data.PayLoad.Ready = true;
                agv.server.SendData(agv, data);
            }

            public void ClearFault()
            {
                AGVComData<ButtonSimulateData> data = new AGVComData<ButtonSimulateData>(agv.AGVID, agv.LatestSerialCode);
                data.PayLoad.FaultClear = true;
                agv.server.SendData(agv, data);
            }

            public void ClearFaultAndReady()
            {
                AGVComData<ButtonSimulateData> data = new AGVComData<ButtonSimulateData>(agv.AGVID, agv.LatestSerialCode);
                data.PayLoad.FaultClear = true;
                data.PayLoad.Ready = true;
                agv.server.SendData(agv, data);
            }

            public void SendQueryRequest()
            {
                AGVComData<QueryStateData> data = new AGVComData<QueryStateData>(agv.AGVID, agv.LatestSerialCode);
                agv.server.SendData(agv, data);
            }

            public void ForceStation(IPoint point)
            {
                AGVComData<ForceStationData> data = new AGVComData<ForceStationData>(agv.AGVID, agv.LatestSerialCode);
                data.PayLoad.StationID = point.PhysicID;
                agv.server.SendData(agv, data);
            }

            public void WriteOutputState(int index, bool state)
            {
                Contract.Assert(index >= 1 && index <= 5);
                IOSetMode io = (state ? IOSetMode.Trigger : IOSetMode.Release);
                AGVComData<SetIOData> data = new AGVComData<SetIOData>(agv.AGVID, agv.LatestSerialCode);
                switch (index)
                {
                    case 1: data.PayLoad.ExtIO1 = io; break;
                    case 2: data.PayLoad.ExtIO2 = io; break;
                    case 3: data.PayLoad.ExtIO3 = io; break;
                    case 4: data.PayLoad.ExtIO4 = io; break;
                    case 5: data.PayLoad.Hook = io; break;
                }
                agv.server.SendData(agv, data);

            }
        }

    }

    
}

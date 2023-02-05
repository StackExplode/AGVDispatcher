using AGVDispatcher.Entity;
using AGVDispatcher.App;
using AGVDispatcher.Util;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AGVDispatcher.BLL;

namespace AGVDispatcher.App
{
    public delegate void OnDispacherAllFinishedDlg(bool emerg);
    public class AGVDispatcher
    {
        WareHouseMap map;
        Dictionary<int, AGV> allagv;
        Dictionary<int, PLC> allplc;
        //Dictionary<int, int> agv_order;
        int miss_count = 0;
        public event OnDispacherAllFinishedDlg OnDispacherAllFinished;

        public int RunningAGVCount => miss_count;
        private Func<IQueuedActions> NewZhangZongActions;

        public AGVDispatcher(Dictionary<int, AGV> agvs, Dictionary<int, PLC> plcs, WareHouseMap map)
        {
            this.map = map;
            allagv = agvs;
            allplc = plcs;
            NewZhangZongActions = () => new BLL.v2.ZhangZongSeqActionsV2();
        }

        private KeyValuePair<int,AGV>[] GenerateSortedAGVs()
        {     
            return allagv.OrderBy(i => i.Value.Order).ToArray();
        }

        public void StartRunMissions()
        {
            if (miss_count > 0)
                throw new Exception("There Still AGV Running! Cannot Start New Loop!");
            map.ResetMapState();
            miss_count = 0;
            var ordered = GenerateSortedAGVs();
            for (int i=0;i< allagv.Count;i++)
            {
                if (map.LastAvilableProduct < 0)
                {
                    BreakZonePoint pt = map.GetLastBreakZonePoint();
                    AGV agv = ordered[i].Value;
                    if(!pt.Equals(agv.PhysicPoint, true))
                    {
                        miss_count++;
                        var mis = new RestInBreakMission(agv, pt);
                        mis.OnMissionFinished += (lastmis) =>
                        {
                            miss_count--;
                            if (miss_count <= 0)
                            {
                                agv.SetWorkState(AGVWorkState.Idle);
                                this.OnDispacherAllFinished?.Invoke(false);
                            }
                        };
                        mis.Start();
                    }    
                }
                else
                {
                    miss_count++;
                    int prod = map.PickLastestProduct();
                    QueuedMission mis = new QueuedMission(NewZhangZongActions(), ordered[i].Value, allplc, map, prod);
                    mis.OnMissionFinished += MissionFinishHandler;
                    mis.Start();
                }
            }
            if(miss_count <= 0)
                this.OnDispacherAllFinished?.Invoke(false);
        }

        public bool CheckAGVReady()
        {
            foreach(var agv in allagv)
            {
                if (agv.Value.ComState != AGVComState.Normal)
                    return false;
//                 if (agv.Value.WorkState != AGVWorkState.Idle)
//                     return false;
                if(agv.Value.State != AGVState.StopIdle)
                    return false;
            }
            return true;
        }


        public void EmergencyStop()
        {
            foreach(var agv in allagv)
            {
                agv.Value.Actions.EmergStop();
            }
            miss_count = 0;
            this.OnDispacherAllFinished?.Invoke(true);
        }

#if !DEBUG
//#error 你不能在非调试版本下调用用户调度方法！
#else
        public void RunCustomQueue(AGV agv,IQueuedActions acts, OnMissionFinishedDlg callback = null, params object[] param)
        {
            QueuedMission mis = new QueuedMission(acts, agv, allplc, map, param);
            if(callback != null)
                mis.OnMissionFinished += callback;
            mis.Start();
        }

        private class TempQueue : IQueuedActions
        {
            public Queue<IAGVAction> ActionQueue { get; }
            public TempQueue(IAGVAction act)
            {
                ActionQueue = new Queue<IAGVAction>();
                ActionQueue.Enqueue(act);
            }
        }

        public void RunCustomAction(AGV agv, IAGVAction act, OnMissionFinishedDlg callback = null, params object[] param)
        {
            TempQueue q = new TempQueue(act);
            QueuedMission mis = new QueuedMission(q, agv, allplc, map, param);
            if (callback != null)
                mis.OnMissionFinished += callback;
            mis.Start();
        }
#endif
        private void MissionFinishHandler(IMission mission)
        {
            if(map.LastAvilableProduct < 0)
            {
                
                BreakZonePoint pt = map.GetLastBreakZonePoint();
                AGV agv = mission.AGVCar;
                mission.Dispose();
                if (!pt.Equals(agv.PhysicPoint, true))
                {
                    var mis = new RestInBreakMission(agv, pt);
                    mis.OnMissionFinished += (lastmis) =>
                    {
                        miss_count--;
                        if (miss_count <= 0)
                        {
                            agv.SetWorkState(AGVWorkState.Idle);
                            this.OnDispacherAllFinished?.Invoke(false);
                        }
                    };
                    mission.Dispose();
                    mis.Start();
                }
                else
                {
                    miss_count--;
                    if (miss_count <= 0)
                    {
                        agv.SetWorkState(AGVWorkState.Idle);
                        this.OnDispacherAllFinished?.Invoke(false);
                    }
                }
                        
            }
            else
            {
                int prod = map.PickLastestProduct();
                QueuedMission mis = new QueuedMission(NewZhangZongActions(), mission.AGVCar, allplc, map, prod);
                mis.OnMissionFinished += MissionFinishHandler;
                mission.Dispose();
                mis.Start();
            }
        }
    }
}

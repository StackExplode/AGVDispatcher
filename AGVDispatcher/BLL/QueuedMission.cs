using AGVDispatcher.App;
using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL
{
    public class QueuedMission : IMission
    {
        
        public event OnMissionFinishedDlg OnMissionFinished;
        private AutoResetEvent locker;

        Dictionary<int, PLC> _plcs;
        AGV _agv;
        object[] param;
        IAGVAction currentAct;
        WareHouseMap _map;
        private bool disposedValue;
        Queue<IAGVAction> queue;

        public AGV AGVCar => _agv;
        public QueuedMission(IQueuedActions acts, AGV agv, Dictionary<int, PLC> plcs, WareHouseMap map,params object[] p)
        {
            _plcs = plcs;
            _agv = agv;
            param = p;
            _map = map;
            this.queue = acts.ActionQueue;
            locker = new AutoResetEvent(false);
            agv.OnAGVStateUpdate += Agv_OnAGVStateUpdate;
            foreach (var plc in plcs)
                plc.Value.OnAGVStateUpdate += Agv_OnAGVStateUpdate;
            //_plc.OnXXX += XXX
        }

        private void Agv_OnAGVStateUpdate(IAGVDevice agv)
        {
            if (currentAct.CheckActionEnd())
                locker.Set();
        }

        [System.Diagnostics.Conditional("DEBUG")]
        void SkipStep()
        {
            int sk = GlobalConfig.DebugConfig.RunSkipFrom;
            if (sk <= 0)
                return;
            for (int i = 0; i < sk; i++)
                queue.Dequeue();
        }

        bool forceexit = false;
        public virtual void Start()
        {
            forceexit = false;
            SkipStep();
            Task task = new Task(() =>
            {
                while(queue.Count > 0 && !forceexit)
                {
                    currentAct = queue.Dequeue();
                    currentAct.Init(_agv, _plcs, _map, param);
                    if(currentAct.Run())
                        locker.WaitOne();
                }
            });
            task.ContinueWith((t) => { this.OnMissionFinished?.Invoke(this, forceexit); });
            task.Start();
           
        }

        public void Abort()
        {
            forceexit = true;
            locker.Set();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.OnMissionFinished = null;
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并替代终结器
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~NormalMission()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        
    }
}

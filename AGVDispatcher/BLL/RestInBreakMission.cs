using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL
{
    public class RestInBreakMission : IMission
    {
        private bool disposedValue;

        public AGV AGVCar => agv;

        public event OnMissionFinishedDlg OnMissionFinished;

        private AGV agv;
        private BreakZonePoint bpt;
        private AutoResetEvent locker;

        public RestInBreakMission(AGV agv,BreakZonePoint pt)
        {
            this.agv = agv;
            this.bpt = pt;
            locker = new AutoResetEvent(false);
            agv.OnAGVStateUpdate += Agv_OnAGVStateUpdate;
        }

        private void Agv_OnAGVStateUpdate(IAGVDevice iagv)
        {
            AGV a = (AGV)iagv;
            if (bpt.Equals(agv.PhysicPoint , true))
                locker.Set();
        }

        bool forceexit = false;
        public void Start()
        {
            forceexit = false;
            Task task = new Task(() =>
            {
                agv.Actions.SetAutoStop(bpt);
                agv.Actions.RunStraigth();
                locker.WaitOne();
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
                    OnMissionFinished = null;
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并替代终结器
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~RestInBreakMission()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

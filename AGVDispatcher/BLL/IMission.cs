using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AGVDispatcher.App;

namespace AGVDispatcher.BLL
{
    public delegate void OnMissionFinishedDlg(IMission mission, bool isabort);
    public interface IMission : IDisposable
    {
        public void Start();
        public event OnMissionFinishedDlg OnMissionFinished;
        public AGV AGVCar { get; }
        public void Abort();
    }
}

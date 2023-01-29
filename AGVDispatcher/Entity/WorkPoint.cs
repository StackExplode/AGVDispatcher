using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.Entity
{
    [Serializable]
    public class WorkPoint : NormalPoint
    {
        public byte PLCOrder { get; set; }
        public byte WorkIO { get; set; } = 1;
        public bool WorkLevel { get; set; } = true;
        public byte FinishIO { get; set; } = 1;
        public bool FinishLevel { get; set; } = true;

        public override PointType PointType => PointType.WorkStation;

        public override void CopyFrom(IPoint pt)
        {
            base.CopyFrom(pt);
            WorkPoint p = (WorkPoint)pt;
            this.PLCOrder = p.PLCOrder;
            this.WorkIO = p.WorkIO;
            this.WorkLevel = p.WorkLevel;
            this.FinishIO = p.FinishIO;
            this.FinishLevel = p.FinishLevel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.Entity
{
    [Serializable]
    public class BreakZonePoint : NormalPoint
    {
        public byte Order { get; set; }
        public override PointType PointType => PointType.BreakZone;

        public override string Name => $"第{Order+1}待命位";

        public override void CopyFrom(IPoint pt)
        {
            base.CopyFrom(pt);
            BreakZonePoint p = (BreakZonePoint)pt;
            this.Order = p.Order;
        }
    }
}

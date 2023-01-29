using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.Entity
{
    [Serializable]
    public class TurnPoint : NormalPoint
    {
        public override PointType PointType => PointType.Turn;
    }
}

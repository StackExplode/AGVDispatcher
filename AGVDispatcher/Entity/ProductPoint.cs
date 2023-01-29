using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.Entity
{
    [Serializable]
    public class ProductPoint : NormalPoint
    {
        public byte ProductID { get; set; }
        public bool IsTakePoint { get; set; }   //False=Put point
        public bool IsAvailable { get; set; } = true;

        public override PointType PointType => PointType.Product;

        public override void CopyFrom(IPoint pt)
        {
            base.CopyFrom(pt);
            ProductPoint p = (ProductPoint)pt;
            this.ProductID = p.ProductID;
            this.IsTakePoint = p.IsTakePoint;
            this.IsAvailable = p.IsAvailable;
        }
    }
}

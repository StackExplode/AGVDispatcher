using AGVDispatcher.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.Entity
{
    [Serializable]
    public class NormalPoint : IPoint
    {
        //public string RFIDSerial => throw new NotImplementedException();

        public ushort PhysicID { get; set; }

        public ushort LogicID { get; set; }
        public virtual string Name => @PointType.GetDescription();
        public virtual string PointDescription => "无描述";

        public virtual PointType @PointType => PointType.Normal;

        public virtual string Description
        {
            get
            {
                return string.Format("{0}[{1}] - {2}: {3}", LogicID, PhysicID, Name , PointDescription);
            }
        }


        public virtual void CopyFrom(IPoint pt)
        {
            NormalPoint p = (NormalPoint)pt;
            this.PhysicID = p.PhysicID;
            this.LogicID = p.LogicID;
        }

        public virtual bool Equals(IPoint other, bool isphy = false)
        {
            if (isphy)
                return this.PhysicID == other.PhysicID;
            else
                return this.LogicID == other.LogicID;
        }

        public virtual bool Equals(ushort other, bool isphy = false)
        {
            if (isphy)
                return this.PhysicID == other;
            else
                return this.LogicID == other;
        }
    }
}

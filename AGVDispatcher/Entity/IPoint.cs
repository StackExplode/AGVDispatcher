using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AGVDispatcher.Entity
{
    [XmlInclude(typeof(NormalPoint))]
    [XmlInclude(typeof(TurnPoint))]
    [XmlInclude(typeof(BreakZonePoint))]
    [XmlInclude(typeof(WorkPoint))]
    [XmlInclude(typeof(ProductPoint))]
    public interface IPoint
    {
        //public string RFIDSerial { get; }
        public ushort PhysicID { get; set; }
        public ushort LogicID { get; set;}
        public PointType @PointType { get; }
        public void CopyFrom(IPoint pt);
        public bool Equals(IPoint other,bool isphy = false);
        public bool Equals(ushort other, bool isphy = false);


    }
}

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

        protected string LevelStringfy(bool b) => b ? "高" : "低";

        protected int WorkPointOrder = 0;

        public WorkPoint(int i)
        {
            WorkPointOrder = i;
        }

        public WorkPoint() { }

        public override string Name => $"第{WorkPointOrder}作业点";

        public override string PointDescription
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"PLC次序：{PLCOrder}; ");
                sb.Append($"工作命令IO：{WorkIO}, {LevelStringfy(WorkLevel)}电平有效; ");
                sb.Append($"完成信号IO：{FinishIO}, {LevelStringfy(FinishLevel)}电平有效; ");

                return sb.ToString();
            }
        }

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

    [Serializable]
    public class CheckPoint : WorkPoint
    {
        public CheckPoint(int i) : base(i)
        {
        }
        public CheckPoint() { }

        public override string Name => $"检测点{WorkPointOrder}";

        public override string PointDescription
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"PLC次序：{PLCOrder}; ");
                sb.Append($"完成信号IO：{FinishIO}, {LevelStringfy(FinishLevel)}电平有效; ");

                return sb.ToString();
            }
        }
    }
}

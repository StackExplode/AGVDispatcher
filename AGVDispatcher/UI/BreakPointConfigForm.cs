using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGVDispatcher.UI
{
    public partial class BreakPointConfigForm : PointConfigForm
    {
        public BreakPointConfigForm(BreakZonePoint pt)
        {
            base.Point = pt;
            InitializeComponent();
        }

        protected override void SetPointProperty(IPoint pt)
        {
            pt.PhysicID = ushort.Parse(txt_phy.Text);
        }

        protected override void InitFormValue(IPoint pt)
        {
            base.InitFormValue(pt);
            lbl_order.Text = (pt as BreakZonePoint).Order.ToString();
            txt_phy.Text = pt.PhysicID.ToString();
        }

    }
}

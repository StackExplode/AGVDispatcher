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
    public partial class NormalPointConfigForm : PointConfigForm
    {

        public NormalPointConfigForm(NormalPoint pt)
        {
            base.Point = pt;
            InitializeComponent();
        }

        protected NormalPointConfigForm() { InitializeComponent(); }

        protected override void SetPointProperty(IPoint pt)
        {
            NormalPoint p = pt as NormalPoint;
            p.PhysicID = ushort.Parse(txt_phy.Text);
        }

        protected override void InitFormValue(IPoint pt)
        {
            txt_phy.Text = pt?.PhysicID.ToString() ?? "null";
        }
    }
}

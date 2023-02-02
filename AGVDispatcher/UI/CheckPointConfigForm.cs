using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGVDispatcher.Entity;

namespace AGVDispatcher.UI
{
    public partial class CheckPointConfigForm : PointConfigForm
    {
        public CheckPointConfigForm(CheckPoint pt)
        {
            base.Point = pt;
            InitializeComponent();
        }

        protected override void SetPointProperty(IPoint pt)
        {
            var p = pt as CheckPoint;
            p.PhysicID = ushort.Parse(txt_phy.Text);
            p.PLCOrder = byte.Parse(txt_plc.Text);
            p.FinishIO = byte.Parse(txt_finish.Text);

            if (cmb_finish.SelectedIndex == 0)
                p.FinishLevel = true;
            else if (cmb_finish.SelectedIndex == 1)
                p.FinishLevel = false;

        }

        protected override void InitFormValue(IPoint pt)
        {
            var p = pt as CheckPoint;
            lbl_logi.Text = p.LogicID.ToString();
            txt_phy.Text = p.PhysicID.ToString();
            txt_plc.Text = p.PLCOrder.ToString();
            txt_finish.Text = p.FinishIO.ToString();

            if (p.FinishLevel)
                cmb_finish.SelectedIndex = 0;
            else
                cmb_finish.SelectedIndex = 1;
        }
    }
}

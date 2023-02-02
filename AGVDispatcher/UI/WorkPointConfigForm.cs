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
    public partial class WorkPointConfigForm : PointConfigForm
    {
        public WorkPointConfigForm(WorkPoint pt)
        {
            base.Point = pt;
            InitializeComponent();
        }

        private void WorkPointConfigForm_Load(object sender, EventArgs e)
        {
           

        }

        protected override void SetPointProperty(IPoint pt)
        {
            var p = pt as WorkPoint;
            p.PhysicID = ushort.Parse(txt_phy.Text);
            p.PLCOrder = byte.Parse(txt_plc.Text);
            p.WorkIO = byte.Parse(txt_work.Text);
            p.FinishIO = byte.Parse(txt_finish.Text);
            if (cmb_finish.SelectedIndex == 0)
                p.FinishLevel = true;
            else if (cmb_finish.SelectedIndex == 1)
                p.FinishLevel = false;
            if (cmb_work.SelectedIndex == 0)
                p.WorkLevel = true;
            else if (cmb_work.SelectedIndex == 1)
                p.WorkLevel = false;
        }

        protected override void InitFormValue(IPoint pt)
        {
            var p = pt as WorkPoint;
            lbl_logi.Text = p.LogicID.ToString();
            txt_phy.Text = p.PhysicID.ToString();
            txt_plc.Text = p.PLCOrder.ToString();
            txt_work.Text = p.WorkIO.ToString();
            txt_finish.Text = p.FinishIO.ToString();
            if (p.WorkLevel)
                cmb_work.SelectedIndex = 0;
            else
                cmb_work.SelectedIndex = 1;
            if (p.FinishLevel)
                cmb_finish.SelectedIndex = 0;
            else
                cmb_finish.SelectedIndex = 1;
        }
    }
}

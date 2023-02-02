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
    public partial class ProductConfigForm : PointConfigForm
    {
        public ProductConfigForm(Entity.ProductPoint point)
        {
            base.Point = point;
            InitializeComponent();
        }

        protected override void SetPointProperty(IPoint pt)
        {
            var p = pt as Entity.ProductPoint;
            p.IsAvailable = checkBox1.Checked;
            if (rad_pick.Checked)
                p.IsTakePoint = true;
            else if (rad_put.Checked)
                p.IsTakePoint = false;
            p.PhysicID = ushort.Parse(txt_phy.Text);
        }

        protected override void InitFormValue(IPoint pt)
        {
            var p = pt as Entity.ProductPoint;
            lbl_prod_id.Text = p.ProductID.ToString();
            if (p.IsTakePoint)
                rad_pick.Checked = true;
            else
                rad_put.Checked = true;
            checkBox1.Checked = p.IsAvailable;
            txt_phy.Text = p.PhysicID.ToString();
        }
    }
}

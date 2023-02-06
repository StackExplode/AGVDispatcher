using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AGVDispatcher.App;
using AGVDispatcher.Entity;

namespace AGVDispatcher.UI
{
    public partial class fm_fastprod : Form
    {
        WareHouseMapv2 map;
        public fm_fastprod(WareHouseMapv2 map)
        {
            this.map = map;
            InitializeComponent();
        }

        private void fm_fastprod_Load(object sender, EventArgs e)
        {
            txt1.Text = "";
            foreach (var pt in map.AllPoints)
            {
                if(pt.PointType == PointType.Product)
                {
                    var p = pt as ProductPoint;
                    if (p.IsTakePoint && p.IsAvailable)
                        txt1.Text += p.ProductID.ToString() + ",";
                }
            }
            txt1.Text = txt1.Text.TrimEnd(',');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var pt in map.AllPoints)
            {
                if (pt.PointType == PointType.Product)
                {
                    var p = pt as ProductPoint;
                    if (p.IsTakePoint)
                        p.IsAvailable = true;
                }
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] prodids = txt1.Text.Trim().Split(',');
            HashSet<byte> hs = new HashSet<byte>();
            if(txt1.Text.Length > 0)
            {
                foreach (var id in prodids)
                    hs.Add(byte.Parse(id));
            }

            foreach (var pt in map.AllPoints)
            {
                if (pt.PointType == PointType.Product)
                {
                    var p = pt as ProductPoint;
                    if (p.IsTakePoint)
                    {
                        p.IsAvailable = hs.Contains(p.ProductID);
                    }
                }
            }
            this.Close();
        }
    }
}

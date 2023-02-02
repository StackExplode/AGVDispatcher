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
using AGVDispatcher.Util;

namespace AGVDispatcher.UI
{
    public partial class AGVMapConfiger : UserControl
    {
        public AGVMapConfiger()
        {
            InitializeComponent();
            listBox1.ItemHeight = 26;
            listBox1.ValueMember = "LogicID";
            listBox1.DisplayMember = "Description";
        }

        public WareHouseMap Map { get; set; }

        private void ShowPointConfigForm()
        {
            IPoint pt = listBox1.SelectedItem as IPoint;
            if (pt == null)
                return;
            PointConfigForm fm = null;
            var tp = pt.GetType();
            switch (tp.Name)
            {
                case nameof(NormalPoint): fm = new NormalPointConfigForm(pt as NormalPoint); break;
                case nameof(TurnPoint): fm = new TurnPointConfigForm(pt as TurnPoint); break;
                case nameof(BreakZonePoint): fm = new BreakPointConfigForm(pt as BreakZonePoint); break;
                case nameof(ProductPoint): fm = new ProductConfigForm(pt as ProductPoint); break;
                case nameof(WorkPoint): fm = new WorkPointConfigForm(pt as WorkPoint); break;
                case nameof(CheckPoint): fm = new CheckPointConfigForm(pt as CheckPoint); break;
                default:MessageBox.Show("尚未支持此类型RFID设置！"); break;
            }
            fm?.ShowDialog();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                ShowPointConfigForm();
            }

        }

        SolidBrush reportsBackgroundBrush1 = new SolidBrush(Color.FromArgb(228,250,255));
        SolidBrush reportsBackgroundBrush2 = new SolidBrush(Color.FromArgb(199, 240, 255));
        SolidBrush SelectedBackBrush = new SolidBrush(Color.FromArgb(227,113,180));
        SolidBrush reportsForegroundBrush = new SolidBrush(Color.Black);
        SolidBrush reportsForegroundBrushSelected = new SolidBrush(Color.White);
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var lbReports = listBox1;
            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < lbReports.Items.Count)
            {
                string text = (lbReports.Items[index] as IPoint).Description;
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if (selected)
                {
                    backgroundBrush = SelectedBackBrush;

                }
                else if ((index % 2) == 0)
                    backgroundBrush = reportsBackgroundBrush1;
                else
                    backgroundBrush = reportsBackgroundBrush2;
                //Rectangle rct = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, 26);
                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? reportsForegroundBrushSelected : reportsForegroundBrush;
                int x = lbReports.GetItemRectangle(index).Location.X;
                int y = lbReports.GetItemRectangle(index).Location.Y;
                y += 6;
                g.DrawString(text, e.Font, foregroundBrush, new Point(x,y));
            }

            e.DrawFocusRectangle();

        }

        BindingSource _bs;
        public void RefreshData(bool st = false)
        {
            _bs.DataSource = Map.AllPoints;
            listBox1.DataSource = _bs;
            _bs.ResetBindings(st);
        }

        private void AGVMapConfiger_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            _bs = bs;
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ShowPointConfigForm();
        }
    }

  
}

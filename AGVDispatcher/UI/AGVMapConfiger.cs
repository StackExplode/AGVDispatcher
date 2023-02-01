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
    public partial class AGVMapConfiger : UserControl
    {
        public AGVMapConfiger()
        {
            InitializeComponent();
            listBox1.ItemHeight = 26;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                MessageBox.Show(listBox1.SelectedItem.ToString());
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
                string text = lbReports.Items[index].ToString();
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
    }
}

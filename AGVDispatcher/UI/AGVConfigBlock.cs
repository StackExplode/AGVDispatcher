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
    public partial class AGVConfigBlock : UserControl
    {
        public AGVConfigBlock()
        {
            InitializeComponent();
        }


        public event Action<AGVConfigBlock> OnCrossClicked;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.OnCrossClicked?.Invoke(this);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                this.BackColor = Color.FromArgb(255, 223, 223);
            else
                this.BackColor = Color.LightGray;
        }
    }
}

using AGVDispatcher.App;
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
    public partial class AGVConfigBlock : UserControl, IAGVDevConfigBlock
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

        public void Init(IAGVDevConfig c)
        {
            var conf = c as AGVConfig;
            this.checkBox1.Enabled = conf.InUse;
            this.txt_id.Text = conf.AGVID.ToString();
            this.txt_order.Text = conf.Order.ToString();
            this.txt_ip.Text = conf.IP ?? "";
            this.txt_pass.Text = conf.Password ?? "";
        }

        public IAGVDevConfig GenerateConfig()
        {
            AGVConfig conf = new AGVConfig();
            conf.InUse = checkBox1.Checked;
            conf.AGVID = byte.Parse(txt_id.Text);
            conf.Order = byte.Parse(txt_order.Text);
            conf.Password = txt_pass.Text.Length > 1 ? txt_pass.Text : null;
            conf.IP = txt_ip.Text.Length > 1 ? txt_ip.Text : null;

            return conf;
        }
    }
}

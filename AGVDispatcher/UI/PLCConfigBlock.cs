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
    public partial class PLCConfigBlock : UserControl, IAGVDevConfigBlock
    {

        public event Action<PLCConfigBlock> OnCrossClicked;
        public PLCConfigBlock()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.OnCrossClicked?.Invoke(this);
        }

        public IAGVDevConfig GenerateConfig()
        {
            PLCConfig conf = new PLCConfig();
            conf.PLCID = byte.Parse(txt_id.Text);
            conf.Order = byte.Parse(txt_order.Text);
            conf.Password = txt_pass.Text.Length > 0 ? txt_pass.Text : null;
            conf.IP = txt_ip.Text.Length > 0 ? txt_ip.Text : null;

            return conf;
        }

        public void Init(IAGVDevConfig c)
        {
            var conf = c as PLCConfig;
            this.txt_id.Text = conf.PLCID.ToString();
            txt_order.Text = conf.Order.ToString();
            txt_pass.Text = conf.Password ?? "";
            txt_ip.Text = conf.IP ?? "";
        }
    }
}

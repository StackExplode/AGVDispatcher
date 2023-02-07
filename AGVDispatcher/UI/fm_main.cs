using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using AGVDispatcher.App;

namespace AGVDispatcher.UI
{
    public partial class fm_main : Form
    {
        //WareHouse house;
        public fm_main()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.robot_delivery;
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            lbl_ver.Text = "Ver:" + ver.Major.ToString() + "." + ver.Minor.ToString();
            //house = new WareHouse();
            GlobalConfig.CreateNewConfig();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fm_config fm = new fm_config(new WareHouse());
            fm.FormClosed += (_, _) => { this.Show(); };
            this.Hide();
            fm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fm_run fm = new fm_run(new WareHouse());
            fm.FormClosed += (_, _) => { this.Show(); };
            this.Hide();
            fm.ShowDialog();
        }
    }
}

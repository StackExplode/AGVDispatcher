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

namespace AGVDispatcher.UI
{
    public partial class fm_config : Form
    {
        WareHouse house;
        
        public fm_config(WareHouse h)
        {
            house = h;
            InitializeComponent();
            agvMapConfiger1.Map = h.Map;
        }

        private void fm_config_Load(object sender, EventArgs e)
        {
            house.Map.LoadFromFile("./map.xml");
            agvMapConfiger1.RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.house.Map.SaveToFile("./map.xml");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AGVConfigBlock agvblock = new AGVConfigBlock() { Dock = DockStyle.Top};
            Panel panel = new Panel() { Height = agvblock.Height + 10,Dock = DockStyle.Top};
            agvblock.OnCrossClicked += Agvblock_OnCrossClicked;
            panel.Controls.Add(agvblock);
            panel_agv.Controls.Add(panel);
            panel.BringToFront();
            button3.Parent.BringToFront();
            panel_agv.ScrollControlIntoView(button3.Parent);
        }

        private void Agvblock_OnCrossClicked(AGVConfigBlock obj)
        {
            panel_agv.Controls.Remove(obj.Parent);
            obj.Parent.Dispose();
            obj.Dispose();
        }
    }
}

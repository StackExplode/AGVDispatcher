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
        Config _config => GlobalConfig.Config;
        bool saved = false;
        
        public fm_config(WareHouse h)
        {
            house = h;
            InitializeComponent();
            agvMapConfiger1.Map = h.Map;
        }

        private void LoadConfigFromFile()
        {
            house.Map.LoadFromFile("./Roaming/map.xml");
            agvMapConfiger1.RefreshData();

            //Load config.xml
            _config.LoadFromFile("./Roaming/config.xml");
        }

        private void fm_config_Load(object sender, EventArgs e)
        {
            LoadConfigFromFile();
            foreach (var agv in _config.AllAGV_ByOrder)
            {
                var agv_block = AddAGVConfBlock(false);
                agv_block.Init(agv.Value);
            }
            foreach (var plc in _config.AllPLC_ByOrder)
            {
                var plc_block = AddPLCConfBlock(false);
                plc_block.Init(plc.Value);
            }

            chk_checkIP.Checked = _config.SystemConfig.CheckIP;
            txt_port.Text = _config.SystemConfig.ListenPort.ToString();
            txt_tmout.Text = _config.SystemConfig.AGVComTimeout.ToString();
            txt_polltime.Text = _config.SystemConfig.AGVQueryInterval.ToString();
            txt_hookdelay.Text = _config.SystemConfig.HookDelay.ToString();
            txt_stopdelay.Text = _config.SystemConfig.StopDelay.ToString();
        }

        int CheckRepeateAGV()
        {
            HashSet<int> id = new HashSet<int>();
            HashSet<int> order = new HashSet<int>();
            foreach (Panel panel in panel_agv.Controls)
            {
                if (panel.Controls[0] is IAGVDevConfigBlock)
                {
                    IAGVDevConfigBlock agvc = (IAGVDevConfigBlock)panel.Controls[0];
                    AGVConfig conf = (AGVConfig)agvc.GenerateConfig();
                    if (!id.Add(conf.AGVID))
                        return 1;
                    if (!order.Add(conf.Order))
                        return 2;
                }
            }
            return 0;
        }
        int CheckRepeatePLC()
        {
            HashSet<int> id = new HashSet<int>();
            HashSet<int> order = new HashSet<int>();
            foreach (Panel panel in panel_plc.Controls)
            {
                if (panel.Controls[0] is IAGVDevConfigBlock)
                {
                    IAGVDevConfigBlock agvc = (IAGVDevConfigBlock)panel.Controls[0];
                    PLCConfig conf = (PLCConfig)agvc.GenerateConfig();
                    if (!id.Add(conf.PLCID))
                        return 1;
                    if (!order.Add(conf.Order))
                        return 2;
                }
            }
            return 0;
        }

        private bool SaveDataToFile()
        {
            int chk = CheckRepeateAGV();
            if(chk == 1)
            {
                MessageBox.Show("有AGV的ID（编号）重复，无法保存！");
                return false;
            }
            else if(chk == 2)
            {
                MessageBox.Show("有AGV的发车次序重复，无法保存！");
                return false;
            }

            chk = CheckRepeatePLC();
            if (chk == 1)
            {
                MessageBox.Show("有PLC的ID（编号）重复，无法保存！");
                return false;
            }
            else if (chk == 2)
            {
                MessageBox.Show("有PLC的次序重复，无法保存！");
                return false;
            }

            _config.ClearAGVConfig();
            _config.ClearPLCConfig();
            foreach (Panel panel in panel_agv.Controls)
            {
                if (panel.Controls[0] is IAGVDevConfigBlock)
                {
                    IAGVDevConfigBlock agvc = (IAGVDevConfigBlock)panel.Controls[0];
                    _config.AddAGVConfig((AGVConfig)agvc.GenerateConfig());
                }
            }
            foreach (Panel panel in panel_plc.Controls)
            {
                if (panel.Controls[0] is IAGVDevConfigBlock)
                {
                    IAGVDevConfigBlock agvc = (IAGVDevConfigBlock)panel.Controls[0];
                    _config.AddPLCConfig((PLCConfig)agvc.GenerateConfig());
                }
            }
            _config.SystemConfig.ListenPort = ushort.Parse(txt_port.Text);
            _config.SystemConfig.CheckIP = chk_checkIP.Checked;
            _config.SystemConfig.AGVComTimeout = int.Parse(txt_tmout.Text);
            _config.SystemConfig.AGVQueryInterval = int.Parse(txt_polltime.Text);
            _config.SystemConfig.HookDelay = byte.Parse(txt_hookdelay.Text);
            _config.SystemConfig.StopDelay = byte.Parse(txt_stopdelay.Text);

            _config.SaveToFile("./Roaming/config.xml");
            this.house.Map.SaveToFile("./Roaming/map.xml");
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool succ = SaveDataToFile();
            if(succ)
            {
                MessageBox.Show("保存成功！");
                saved = true;
                this.Close();
            }
            
        }

        private AGVConfigBlock AddAGVConfBlock(bool bringtofont = true)
        {
            AGVConfigBlock agvblock = new AGVConfigBlock() { Dock = DockStyle.Top };
            Panel panel = new Panel() { Height = agvblock.Height + 10, Dock = DockStyle.Top };
            agvblock.OnCrossClicked += (obj) =>
            {
                panel_agv.Controls.Remove(obj.Parent);
                obj.Parent.Dispose();
                obj.Dispose();
            };
            panel.Controls.Add(agvblock);
            panel_agv.Controls.Add(panel);
            if(bringtofont)
            {
                panel.BringToFront();
                button3.Parent.BringToFront();
                panel_agv.ScrollControlIntoView(button3.Parent);
            }
            
            return agvblock;
        }

        private PLCConfigBlock AddPLCConfBlock(bool bringtofont = true)
        {
            PLCConfigBlock plcblock = new PLCConfigBlock() { Dock = DockStyle.Left };
            Panel panel = new Panel() { Height = plcblock.Height + 10, Dock = DockStyle.Left };
            plcblock.OnCrossClicked += (obj) =>
            {
                panel_plc.Controls.Remove(obj.Parent);
                obj.Parent.Dispose();
                obj.Dispose();
            };
            panel.Controls.Add(plcblock);
            panel_plc.Controls.Add(panel);
            if(bringtofont)
            {
                panel.BringToFront();
                button4.Parent.BringToFront();
                panel_plc.ScrollControlIntoView(button4.Parent);
            }
           
            return plcblock;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddAGVConfBlock();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddPLCConfBlock();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("快速批量设置货物点位有无功能。\r\n尚未完成！请在RFID点位表格里逐个修改。");
            fm_fastprod fm = new fm_fastprod(house.Map);
            fm.FormClosed += (_, _) => { this.agvMapConfiger1.RefreshData(); };
            fm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fm_config_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!saved)
            {
                var dr = MessageBox.Show("你是否确定退出设置？所有的配置都不会被保存！","警告",MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}

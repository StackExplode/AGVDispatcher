using AGVDispatcher.App;
using AGVDispatcher.Entity;
using AGVDispatcher.Util;
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
    public partial class fm_run : Form
    {
        private WareHouse house;
        Config _config => GlobalConfig.Config;
        bool finished = true;
        Dictionary<int, AGVStateIndicator> allagvpanels = new Dictionary<int, AGVStateIndicator>();
        Dictionary<int, PLCIndicator> allplcpanels = new Dictionary<int, PLCIndicator>();

        public fm_run(WareHouse h)
        {
            this.house = h;
            InitializeComponent();
        }

        private void LoadConfigFromFile()
        {
            house.Map.LoadFromFile("./Roaming/map.xml");
            //Load config.xml
            _config.LoadFromFile("./Roaming/config.xml");
        }

        private void AddAGVIndicator(AGVConfig conf, bool bringtofont = true)
        {
            AGVStateIndicator ctrl = new AGVStateIndicator() { Dock = DockStyle.Top };
            Panel panel = new Panel() { Height = ctrl.Height + 10, Dock = DockStyle.Top };
            panel.Controls.Add(ctrl);
            panel_agv.Controls.Add(panel);
            if (bringtofont)
                panel.BringToFront();
            ctrl.SetAGVConfig(conf);
            allagvpanels.Add(conf.AGVID, ctrl);
        }

        private void AddPLCIndicator(PLCConfig conf, bool bringtofont = true)
        {
            PLCIndicator ctrl = new PLCIndicator() { Dock = DockStyle.Top };
            Panel panel = new Panel() { Height = ctrl.Height + 10, Dock = DockStyle.Top };
            panel.Controls.Add(ctrl);
            panel_agv.Controls.Add(panel);
            if (bringtofont)
                panel.BringToFront();
            ctrl.SetPLCConfig(conf);
            allplcpanels.Add(conf.PLCID, ctrl);
        }

        private void fm_run_Load(object sender, EventArgs e)
        {
            LoadConfigFromFile();
            foreach (var a in _config.AllAGV_ByOrder)
                this.AddAGVIndicator(a.Value, true);
            foreach (var p in _config.AllPLC_ByOrder)
                this.AddPLCIndicator(p.Value, true);

            house.OnAGVConnected += House_OnAGVConnected;
            house.OnAGVValidated += House_OnAGVValidated;
            house.OnDispacherAllFinished += House_OnDispacherAllFinished;

            house.StartServer();
        }



        private void House_OnDispacherAllFinished(bool emerg)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                finished = true;
                btn_run.Text = "运行完毕!";
                btn_estop.Enabled = btn_removeagv.Enabled = false;
                MessageBox.Show("所有AGV任务执行完毕！如要再次执行，请退出本窗口重新打开！");

            }));
        }

        private void House_OnAGVValidated(IAGVDevice iagv, bool success)
        {
            if(iagv.AGVType == AGVType.AGVNormal)
            {
                var agv = iagv as AGV;
                agv.InfoQueryInterval = GlobalConfig.Config.SystemConfig.AGVQueryInterval;
                agv.StartInfoPolling(false);
                agv.Actions.AGVReady();
            }
            else if (iagv.AGVType == AGVType.PLCSimu)
            {
                var plc = iagv as PLC;
                plc.InfoQueryInterval = GlobalConfig.Config.SystemConfig.AGVQueryInterval;
                plc.StartInfoPolling(false);
            }
        }

        private void House_OnAGVConnected(IAGVDevice iagv, Com.AGVTCPClient client, bool inconfig, bool isneedauth, bool? ipexpected)
        {
            if (iagv is null)
                return;
            if(iagv.AGVType == AGVType.AGVNormal && allagvpanels.ContainsKey(iagv.AGVID))
            {
                allagvpanels[iagv.AGVID].SetAGV((AGV)iagv, house.Map, true);
            }
            else if(iagv.AGVType == AGVType.PLCSimu && allplcpanels.ContainsKey(iagv.AGVID))
            {
                allplcpanels[iagv.AGVID].SetPLC((PLC)iagv, true);
            }
        }

        private void fm_run_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!finished)
            {
                var dr = MessageBox.Show("你是否确定退出？如果有AGV仍在运行则可能会脱离本程序控制！", "警告", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                    e.Cancel = true;
            }
            foreach (var a in allagvpanels)
                a.Value.AGVDevice?.StopInfoPolling();
            foreach (var p in allplcpanels)
                p.Value.PLCDevice?.StopInfoPolling();

            house.StopServerAbort();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = house.CheckReadyToGo();
            if (!ok)
                MessageBox.Show("仍有AGV处于非空闲/或通信异常，不能开始任务！");
            else
            {
                finished = false;
                btn_run.Enabled = btn_ready.Enabled = false;
                btn_run.Text = "运行中...";
                btn_run.BackColor = Color.White;
                btn_estop.Enabled = btn_removeagv.Enabled = true;
                house.StartRun();

            }
            
        }

        private void btn_estop_Click(object sender, EventArgs e)
        {
            btn_estop.Enabled = btn_removeagv.Enabled = false;
            house.EmergencyStop();
        }

        private void btn_ready_Click(object sender, EventArgs e)
        {
            foreach (var a in allagvpanels)
                a.Value.AGVDevice?.Actions.AGVReady();
        }

        private void btn_removeagv_Click(object sender, EventArgs e)
        {
//#error 最后的最后
            List<int> lst = new List<int>();
            foreach(var a in allagvpanels)
            {
                if(a.Value.AGVDevice is not null)
                    lst.Add(a.Value.AGVDevice.AGVID);
            }
            RemoveAGVUI fm = new RemoveAGVUI(lst);
            fm.ShowDialog();

            if(fm.Result != null)
            {
                AGVStateIndicator ai = allagvpanels[(int)fm.Result];
                AGV a = ai.AGVDevice;
                house.AbortAGVMission(a);
                a.StopInfoPolling();
                panel_agv.Controls.Remove(ai.Parent);
                ai.Dispose();
            }
        }
    }
}

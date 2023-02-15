using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AGVDispatcher.Entity;
using AGVDispatcher.App;
using AGVDispatcher.Util;

namespace AGVDispatcher.UI
{
    /// <summary>
    /// AGV信息界面按钮被点击事件
    /// </summary>
    /// <param name="sender">AGV所属的信息框</param>
    /// <param name="agv">所联动的AGV</param>
    /// <param name="button">被按下的按钮类型</param>
    /// <returns>是否继续运行默认处理</returns>
    public delegate bool OnAGVButtonPressedDlg(AGVStateIndicator sender, AGV agv, AGVButtonType button);
    public partial class AGVStateIndicator : UserControl
    {
        AGVConfig agvconf;
        AGV agv;

        public event OnAGVButtonPressedDlg OnAGVButtonPressed;
        public bool UseAGVLogicPoint { get; set; } = false;
        public WareHouseMap Map { get; private set; }

        public AGVStateIndicator()
        {           
            InitializeComponent();          
        }

        public void SetAGVConfig(AGVConfig agvc)
        {
            agvconf = agvc;
            this.Invoke((MethodInvoker)(() =>
            {
                this.lbl_id.Text = agvconf.AGVID.ToString();
                this.lbl_order.Text = agvconf.Order.ToString();
            }));
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void AGVStateIndicator_Load(object sender, EventArgs e)
        {
            
        }

        public void RefreshComState(AGV a)
        {
            var c = a.ComState;
            (string text, Color color) rt = c switch
            {
                _ when !c.HasFlag(AGVComState.OnLine) => ("离线", Color.Red),
                AGVComState.Normal => ("通信正常",Color.Lime),
                _ when c.HasFlag(AGVComState.ComError) => ("通信错误", Color.Red),
                _ when c.HasFlag(AGVComState.TimeOut) => ("通信超时", Color.Red),
                _ when !c.HasFlag(AGVComState.Authorized) =>("未验证", Color.Yellow),
                _ => ("未知状态",Color.DarkGray)
            };
            lbl_comstate.Text = rt.text;
            pic_com.BackColor = rt.color;
        }

        public void RefreshState(AGV a)
        {
            lbl_ip.Text = a.ComClient.IP.ToString();
            lbl_state.Text = a.State.GetDescription();
            pic_state.BackColor = a.State.GetUIColor() ?? Color.DarkGray;
            if (UseAGVLogicPoint)
                lbl_logi.Text = a.LogicPoint.ToString();
            else
                lbl_logi.Text = Map[a.PhysicPoint, true]?.LogicID.ToString() ?? "0";
            lbl_phy.Text = a.PhysicPoint.ToString();
            lbl_volt.Text = a.BatteryVoltage.ToString();
            lbl_battery.Text = a.BatteryPercent.ToString() + "%";

            pic_hook.BackColor = a.HookState ? Color.Lime : Color.White;

            pic_i1.BackColor = a.InputState.HasFlag(IOState.Bit1) ? Color.Lime : Color.White;
            pic_i2.BackColor = a.InputState.HasFlag(IOState.Bit2) ? Color.Lime : Color.White;
            pic_i3.BackColor = a.InputState.HasFlag(IOState.Bit3) ? Color.Lime : Color.White;
            pic_i4.BackColor = a.InputState.HasFlag(IOState.Bit4) ? Color.Lime : Color.White;

            pic_o1.BackColor = a.OutputState.HasFlag(IOState.Bit1) ? Color.Lime : Color.White;
            pic_o2.BackColor = a.OutputState.HasFlag(IOState.Bit2) ? Color.Lime : Color.White;
            pic_o3.BackColor = a.OutputState.HasFlag(IOState.Bit3) ? Color.Lime : Color.White;
            pic_o4.BackColor = a.OutputState.HasFlag(IOState.Bit4) ? Color.Lime : Color.White;

        }

        public AGV AGVDevice => agv;
        public void SetAGV(AGV a, WareHouseMap map, bool autoupdate)
        {
            agv = a;
            Map = map;
           
            this.Invoke((MethodInvoker)(() =>
            {
                btn_startup.Enabled = btn_ready.Enabled = btn_fault.Enabled = btn_estop.Enabled = true;
            }));
            
            if(autoupdate)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    RefreshComState(a);
                    RefreshState(a);
                }));
               
                agv.OnAGVComStateUpdate += (_, _, _) => this.Invoke((MethodInvoker)(() => RefreshComState(agv)));
                agv.OnAGVStateUpdate += (_) => this.Invoke((MethodInvoker)(() => RefreshState(agv)));
            }
        }

        private void btn_ready_Click(object sender, EventArgs e)
        {
            bool rt = this.OnAGVButtonPressed?.Invoke(this, agv, AGVButtonType.Ready) ?? true;
            if(rt && agv.ComState == AGVComState.Normal)
            {
                agv.Actions.AGVReady();
            }
        }

        private void btn_fault_Click(object sender, EventArgs e)
        {
            bool rt = this.OnAGVButtonPressed?.Invoke(this, agv, AGVButtonType.ClearFault) ?? true;
            if (rt && agv.ComState == AGVComState.Normal)
            {
                agv.Actions.ClearFault();
            }
        }

        private void btn_estop_Click(object sender, EventArgs e)
        {
            bool rt = this.OnAGVButtonPressed?.Invoke(this, agv, AGVButtonType.EStop) ?? true;
            if (rt && agv.ComState == AGVComState.Normal)
            {
                agv.Actions.EmergStop();
            }
        }

        private void btn_startup_Click(object sender, EventArgs e)
        {
            bool rt = this.OnAGVButtonPressed?.Invoke(this, agv, AGVButtonType.Startup) ?? true;
            if (rt && agv.ComState == AGVComState.Normal)
            {
                agv.Actions.RunAsLast();
            }
        }

        private void pic_agv_Click(object sender, EventArgs e)
        {
#if DEBUG
            agv.Actions.WriteOutputState(5, !agv.HookState);
#endif
        }

        private void lbl_id_Click(object sender, EventArgs e)
        {
#if DEBUG
            agv.Actions.RunBackward();
#endif
        }

        private void lbl_order_Click(object sender, EventArgs e)
        {
#if DEBUG
            agv.Actions.RunStraigth();
#endif
        }
    }

    public enum AGVButtonType
    {
        UnKnown = 0,
        Startup,
        Ready,
        ClearFault,
        EStop
    }
}

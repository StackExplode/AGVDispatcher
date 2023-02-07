using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AGVDispatcher.Entity;
using AGVDispatcher.App;
using AGVDispatcher.Util;

namespace AGVDispatcher.UI
{
    public partial class PLCIndicator : UserControl
    {
        public PLCIndicator()
        {
            InitializeComponent();
        }

        PLCConfig plcconf;
        PLC plc;
        public PLC PLCDevice => plc;

        public void SetPLCConfig(PLCConfig p)
        {
            plcconf = p;
            lbl_id.Text = plcconf.PLCID.ToString();
            lbl_order.Text = plcconf.Order.ToString();
        }

        public void SetPLC(PLC p, bool autoupdate)
        {
            plc = p;
            if (autoupdate)
            {
                RefreshComState(p);
                RefreshState(p);
                plc.OnAGVComStateUpdate += (_, _, _) => this.Invoke((MethodInvoker)(() => RefreshComState(plc)));
                plc.OnAGVStateUpdate += (_) => this.Invoke((MethodInvoker)(() => RefreshState(plc)));
            }
        }

        public void RefreshComState(PLC a)
        {
            var c = a.ComState;
            (string text, Color color) rt = c switch
            {
                _ when !c.HasFlag(AGVComState.OnLine) => ("离线", Color.Red),
                AGVComState.Normal => ("通信正常", Color.Green),
                _ when !c.HasFlag(AGVComState.ComError) => ("通信错误", Color.Red),
                _ when !c.HasFlag(AGVComState.TimeOut) => ("通信超时", Color.Red),
                _ when !c.HasFlag(AGVComState.Authorized) => ("未验证", Color.Yellow),
                _ => ("未知状态", Color.DarkGray)
            };
            lbl_comstate.Text = rt.text;
            pic_com.BackColor = rt.color;
        }

        public void RefreshState(PLC a)
        {
            lbl_ip.Text = a.ComClient.IP.ToString();

            pic_hook.BackColor = a.HookState ? Color.Green : Color.White;

            pic_i1.BackColor = a.InputState.HasFlag(IOState.Bit1) ? Color.Green : Color.White;
            pic_i2.BackColor = a.InputState.HasFlag(IOState.Bit2) ? Color.Green : Color.White;
            pic_i3.BackColor = a.InputState.HasFlag(IOState.Bit3) ? Color.Green : Color.White;
            pic_i4.BackColor = a.InputState.HasFlag(IOState.Bit4) ? Color.Green : Color.White;

            pic_o1.BackColor = a.OutputState.HasFlag(IOState.Bit1) ? Color.Green : Color.White;
            pic_o2.BackColor = a.OutputState.HasFlag(IOState.Bit2) ? Color.Green : Color.White;
            pic_o3.BackColor = a.OutputState.HasFlag(IOState.Bit3) ? Color.Green : Color.White;
            pic_o4.BackColor = a.OutputState.HasFlag(IOState.Bit4) ? Color.Green : Color.White;

        }

    }
}

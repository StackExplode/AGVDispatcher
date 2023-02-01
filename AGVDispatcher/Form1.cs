using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGVDispatcher.App;
using AGVDispatcher.Entity;
using AGVDispatcher.Util;

namespace AGVDispatcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
 
        }


        WareHouse house;

        private void button1_Click(object sender, EventArgs e)
        {
            house = new WareHouse();
            house.OnDispacherAllFinished += House_OnDispacherAllFinished;
            //#error TODO:没写完
            GlobalConfig.Config = FakeTestInit.FakeReadConfig("配置文件路径");
            FakeTestInit.House = house;
            FakeTestInit.InitSystem();
            FakeTestInit.InitAGVConfig();
            FakeTestInit.InitPLCConfig();
            FakeTestInit.InitMap();
            house.OnAGVConnected += (agv, _, _, _,_) => {
                this.Invoke((MethodInvoker)(() => { listBox1.Items.Add($"ID为{agv.AGVID}的AGV已连接！"); }));
            };
            house.OnAGVDisconnected += (agv) =>
            {
                this.Invoke((MethodInvoker)(() => { listBox1.Items.Add($"ID为{agv.AGVID}的AGV已断连！"); }));
            };
            house.OnAGVValidated += (agv, succ) =>
            {
                this.Invoke((MethodInvoker)(() => { listBox1.Items.Add($"ID为{agv.AGVID}的AGV进行了身份验证，结果：{succ}！"); }));
            };
        }

        private void House_OnDispacherAllFinished(bool emerg)
        {
            if(emerg)
            {
                MessageBox.Show("急停命令下达全部完毕！");
            }
            else
            {
                MessageBox.Show("所有AGV任务执行完毕！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            house.StartServer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            house.StartRun();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            house.EmergencyStop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            house.StopServerAsync(()=> { MessageBox.Show("全部小车断线并关闭服务器完毕！"); });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte i = byte.Parse(textBox1.Text);
            house.QueryAGVStateOnce(i, (agv,tout) =>
            {
                if(tout)
                {
                    listBox1.Items.Add("查询AGV状态超时！");
                }
                else
                {
                    listBox1.Items.Add($"查询AGV状态成功，其输入端口1为{agv.CheckInputState(1)}");
                }

            });
        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte i = byte.Parse(textBox1.Text);
            house.QueryPLCStateOnce(i, (plc, tout) =>
            {
                if (tout)
                {
                    listBox1.Items.Add("查询PLC状态超时！");
                }
                else
                {
                    listBox1.Items.Add($"查询PLC状态成功，其输入端口1为{plc.CheckInputState(1)}");
                }

            });
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataTemplateTest.Run();
        }
    }



}

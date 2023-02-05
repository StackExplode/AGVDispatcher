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
using System.Xml;
using System.Xml.Serialization;
using AGVDispatcher.App;
using AGVDispatcher.Entity;
using AGVDispatcher.Util;
using ExtendedXmlSerializer;
using ExtendedXmlSerializer.Configuration;

/*
 TODO:
1. 准备后才能启动
2. 定时查询AGV状态
3. 
 */

namespace AGVDispatcher.UI
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
            GlobalConfig.Config = FakeTestInit.FakeReadConfig();
            FakeTestInit.House = house;
            FakeTestInit.InitSystem();
            FakeTestInit.InitAGVConfig();
            FakeTestInit.InitPLCConfig();
            FakeTestInit.InitMap();
            house.OnAGVConnected += (agv, _, _, _,_) => {
                this.Invoke((MethodInvoker)(() => {
                listBox1.Items.Add($"ID为{agv.AGVID}的AGV已连接！");
                (agv as AGV).InfoQueryInterval = GlobalConfig.Config.SystemConfig.AGVQueryInterval;
                (agv as AGV).StartInfoPolling(false);
                (agv as AGV).OnAGVStateUpdate += (a) =>
                {
                this.Invoke((MethodInvoker)(()=>{ listBox1.Items.Add($"查询AGV状态成功，其当前物理点位为{((AGV)a).PhysicPoint}"); }));
                        
                    };
                }));
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
                    listBox1.Items.Add($"查询AGV状态成功，其当前物理点位为{agv.PhysicPoint}");
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

        private void button9_Click(object sender, EventArgs e)
        {
            fm_config fm = new fm_config(house);
            fm.ShowDialog();
        }

        class MyItemType
        {
            public MyItemType(int n) => val = n;
            public int val { get; set; }
            public string TheValue
            {
                get => $"The value = {val}";
            }
        }
        MyItemType spec = new MyItemType(100);
        BindingSource bs = new BindingSource();
        List<MyItemType> itms;
        private void button10_Click(object sender, EventArgs e)
        {
            itms = new List<MyItemType>();
            itms.Add(new MyItemType(1));
            itms.Add(spec);
            itms.Add(new MyItemType(10));

            //bs.DataSource = itms;

            listBox2.DisplayMember = "TheValue";
            listBox2.ValueMember = "val";
            listBox2.DataSource = itms;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            spec.val = 250;
            bs.ResetBindings(false);
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var dic = new Dictionary<ushort, IPoint>()
            {
                [1] = new NormalPoint(),
                [2] = new NormalPoint() { LogicID = 222},
                [3] = new WorkPoint(1) { PLCOrder = 38}
            };

            IExtendedXmlSerializer serializer = new ConfigurationContainer().Create();
            System.IO.FileStream file = System.IO.File.Create("./test.xml");
            XmlWriterSettings setting = new XmlWriterSettings() { Indent = true};
            serializer.Serialize(setting ,file, dic);
            file.Close();
        }

       
    }



}

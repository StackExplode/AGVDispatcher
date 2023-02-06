
namespace AGVDispatcher.UI
{
    partial class fm_config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_agv = new System.Windows.Forms.Panel();
            this.panel_addagv = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel_plc = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel_map = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_stopdelay = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_hookdelay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_tmout = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_checkIP = new System.Windows.Forms.CheckBox();
            this.txt_polltime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.agvMapConfiger1 = new AGVDispatcher.UI.AGVMapConfiger();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_agv.SuspendLayout();
            this.panel_addagv.SuspendLayout();
            this.panel_plc.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel_map.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 583F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tableLayoutPanel1.Controls.Add(this.panel_agv, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_plc, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_map, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 221F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1399, 818);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_agv
            // 
            this.panel_agv.AutoScroll = true;
            this.panel_agv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_agv.Controls.Add(this.panel_addagv);
            this.panel_agv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_agv.Location = new System.Drawing.Point(0, 0);
            this.panel_agv.Margin = new System.Windows.Forms.Padding(0);
            this.panel_agv.Name = "panel_agv";
            this.tableLayoutPanel1.SetRowSpan(this.panel_agv, 2);
            this.panel_agv.Size = new System.Drawing.Size(300, 818);
            this.panel_agv.TabIndex = 0;
            // 
            // panel_addagv
            // 
            this.panel_addagv.Controls.Add(this.button3);
            this.panel_addagv.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_addagv.Location = new System.Drawing.Point(0, 0);
            this.panel_addagv.Name = "panel_addagv";
            this.panel_addagv.Size = new System.Drawing.Size(298, 70);
            this.panel_addagv.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Font = new System.Drawing.Font("黑体", 20F);
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(298, 55);
            this.button3.TabIndex = 0;
            this.button3.Text = "+新增AGV+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel_plc
            // 
            this.panel_plc.AutoScroll = true;
            this.panel_plc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_plc.Controls.Add(this.panel6);
            this.panel_plc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_plc.Location = new System.Drawing.Point(303, 597);
            this.panel_plc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel_plc.Name = "panel_plc";
            this.panel_plc.Size = new System.Drawing.Size(577, 221);
            this.panel_plc.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(88, 219);
            this.panel6.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Left;
            this.button4.Font = new System.Drawing.Font("黑体", 20F);
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 219);
            this.button4.TabIndex = 1;
            this.button4.Text = "+\r\n新\r\n增\r\nP\r\nL\r\nC\r\n+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel_map
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_map, 3);
            this.panel_map.Controls.Add(this.agvMapConfiger1);
            this.panel_map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_map.Location = new System.Drawing.Point(303, 3);
            this.panel_map.Name = "panel_map";
            this.panel_map.Size = new System.Drawing.Size(1093, 591);
            this.panel_map.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1186, 600);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 215);
            this.panel1.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Orange;
            this.button5.Font = new System.Drawing.Font("黑体", 20F);
            this.button5.Location = new System.Drawing.Point(10, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(193, 63);
            this.button5.TabIndex = 2;
            this.button5.Text = "快速货物设置";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("黑体", 20F);
            this.button2.Location = new System.Drawing.Point(10, 143);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(193, 63);
            this.button2.TabIndex = 1;
            this.button2.Text = "放弃";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("黑体", 20F);
            this.button1.Location = new System.Drawing.Point(10, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txt_stopdelay);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txt_hookdelay);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.txt_tmout);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.chk_checkIP);
            this.panel4.Controls.Add(this.txt_polltime);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txt_port);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(886, 597);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(294, 221);
            this.panel4.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(5, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(269, 12);
            this.label11.TabIndex = 16;
            this.label11.Text = "小贴士：双击上面列表里的RFID站点可以进行设置";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(160, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "秒";
            // 
            // txt_stopdelay
            // 
            this.txt_stopdelay.Location = new System.Drawing.Point(91, 122);
            this.txt_stopdelay.Name = "txt_stopdelay";
            this.txt_stopdelay.Size = new System.Drawing.Size(63, 21);
            this.txt_stopdelay.TabIndex = 14;
            this.txt_stopdelay.Text = "10";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "停车延时等待：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(160, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "秒";
            // 
            // txt_hookdelay
            // 
            this.txt_hookdelay.Location = new System.Drawing.Point(91, 149);
            this.txt_hookdelay.Name = "txt_hookdelay";
            this.txt_hookdelay.Size = new System.Drawing.Size(63, 21);
            this.txt_hookdelay.TabIndex = 11;
            this.txt_hookdelay.Text = "10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "挂钩延时等待：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "毫秒";
            // 
            // txt_tmout
            // 
            this.txt_tmout.Location = new System.Drawing.Point(91, 95);
            this.txt_tmout.Name = "txt_tmout";
            this.txt_tmout.Size = new System.Drawing.Size(63, 21);
            this.txt_tmout.TabIndex = 8;
            this.txt_tmout.Text = "10000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "通信超时时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "毫秒";
            // 
            // chk_checkIP
            // 
            this.chk_checkIP.AutoSize = true;
            this.chk_checkIP.Location = new System.Drawing.Point(175, 43);
            this.chk_checkIP.Name = "chk_checkIP";
            this.chk_checkIP.Size = new System.Drawing.Size(108, 16);
            this.chk_checkIP.TabIndex = 5;
            this.chk_checkIP.Text = "是否检查IP绑定";
            this.chk_checkIP.UseVisualStyleBackColor = true;
            // 
            // txt_polltime
            // 
            this.txt_polltime.Location = new System.Drawing.Point(91, 68);
            this.txt_polltime.Name = "txt_polltime";
            this.txt_polltime.Size = new System.Drawing.Size(63, 21);
            this.txt_polltime.TabIndex = 4;
            this.txt_polltime.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "轮询数据间隔：";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(91, 41);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(63, 21);
            this.txt_port.TabIndex = 2;
            this.txt_port.Text = "17878";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "服务监听端口：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 16F);
            this.label1.ForeColor = System.Drawing.Color.Fuchsia;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "系统参数";
            // 
            // agvMapConfiger1
            // 
            this.agvMapConfiger1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agvMapConfiger1.Location = new System.Drawing.Point(0, 0);
            this.agvMapConfiger1.Map = null;
            this.agvMapConfiger1.Name = "agvMapConfiger1";
            this.agvMapConfiger1.Size = new System.Drawing.Size(1093, 591);
            this.agvMapConfiger1.TabIndex = 0;
            // 
            // fm_config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 818);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fm_config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fm_config_FormClosing);
            this.Load += new System.EventHandler(this.fm_config_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_agv.ResumeLayout(false);
            this.panel_addagv.ResumeLayout(false);
            this.panel_plc.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel_map.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_agv;
        private System.Windows.Forms.Panel panel_plc;
        private System.Windows.Forms.Panel panel_map;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel_addagv;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_stopdelay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_hookdelay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_tmout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_checkIP;
        private System.Windows.Forms.TextBox txt_polltime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_port;
        private AGVMapConfiger agvMapConfiger1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button5;
    }
}
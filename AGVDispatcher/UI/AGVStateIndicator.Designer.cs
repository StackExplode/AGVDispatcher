namespace AGVDispatcher.UI
{
    partial class AGVStateIndicator
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.pic_agv = new System.Windows.Forms.PictureBox();
            this.pic_com = new System.Windows.Forms.PictureBox();
            this.lbl_comstate = new System.Windows.Forms.Label();
            this.pic_state = new System.Windows.Forms.PictureBox();
            this.lbl_state = new System.Windows.Forms.Label();
            this.lbl_ip = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_logi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_phy = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_volt = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_battery = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pic_hook = new System.Windows.Forms.PictureBox();
            this.pic_i1 = new System.Windows.Forms.PictureBox();
            this.pic_i2 = new System.Windows.Forms.PictureBox();
            this.pic_i3 = new System.Windows.Forms.PictureBox();
            this.pic_i4 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pic_o4 = new System.Windows.Forms.PictureBox();
            this.pic_o3 = new System.Windows.Forms.PictureBox();
            this.pic_o2 = new System.Windows.Forms.PictureBox();
            this.pic_o1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ready = new System.Windows.Forms.Button();
            this.btn_fault = new System.Windows.Forms.Button();
            this.btn_estop = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_order = new System.Windows.Forms.Label();
            this.btn_startup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_agv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_com)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_state)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_hook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_i1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_i2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_i3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_i4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_o4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_o3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_o2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_o1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "AGV编号";
            // 
            // lbl_id
            // 
            this.lbl_id.Font = new System.Drawing.Font("宋体", 25F);
            this.lbl_id.ForeColor = System.Drawing.Color.Blue;
            this.lbl_id.Location = new System.Drawing.Point(3, 29);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(79, 35);
            this.lbl_id.TabIndex = 0;
            this.lbl_id.Text = "0";
            this.lbl_id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_id.Click += new System.EventHandler(this.lbl_id_Click);
            // 
            // pic_agv
            // 
            this.pic_agv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_agv.Image = global::AGVDispatcher.Properties.Resources.sample_AGV;
            this.pic_agv.Location = new System.Drawing.Point(4, 69);
            this.pic_agv.Name = "pic_agv";
            this.pic_agv.Size = new System.Drawing.Size(75, 75);
            this.pic_agv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_agv.TabIndex = 1;
            this.pic_agv.TabStop = false;
            this.pic_agv.Click += new System.EventHandler(this.pic_agv_Click);
            // 
            // pic_com
            // 
            this.pic_com.BackColor = System.Drawing.Color.Red;
            this.pic_com.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_com.Location = new System.Drawing.Point(87, 7);
            this.pic_com.Name = "pic_com";
            this.pic_com.Size = new System.Drawing.Size(20, 20);
            this.pic_com.TabIndex = 2;
            this.pic_com.TabStop = false;
            // 
            // lbl_comstate
            // 
            this.lbl_comstate.AutoSize = true;
            this.lbl_comstate.Font = new System.Drawing.Font("宋体", 11.5F);
            this.lbl_comstate.Location = new System.Drawing.Point(113, 11);
            this.lbl_comstate.Name = "lbl_comstate";
            this.lbl_comstate.Size = new System.Drawing.Size(40, 16);
            this.lbl_comstate.TabIndex = 3;
            this.lbl_comstate.Text = "离线";
            // 
            // pic_state
            // 
            this.pic_state.BackColor = System.Drawing.Color.DarkGray;
            this.pic_state.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_state.Location = new System.Drawing.Point(87, 33);
            this.pic_state.Name = "pic_state";
            this.pic_state.Size = new System.Drawing.Size(20, 20);
            this.pic_state.TabIndex = 2;
            this.pic_state.TabStop = false;
            // 
            // lbl_state
            // 
            this.lbl_state.AutoSize = true;
            this.lbl_state.Font = new System.Drawing.Font("宋体", 11.5F);
            this.lbl_state.Location = new System.Drawing.Point(113, 37);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(40, 16);
            this.lbl_state.TabIndex = 3;
            this.lbl_state.Text = "未知";
            this.lbl_state.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.ForeColor = System.Drawing.Color.Blue;
            this.lbl_ip.Location = new System.Drawing.Point(3, 171);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(47, 12);
            this.lbl_ip.TabIndex = 5;
            this.lbl_ip.Text = "0.0.0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "AGV IP：";
            // 
            // lbl_logi
            // 
            this.lbl_logi.AutoSize = true;
            this.lbl_logi.Font = new System.Drawing.Font("宋体", 11.5F);
            this.lbl_logi.Location = new System.Drawing.Point(147, 63);
            this.lbl_logi.Name = "lbl_logi";
            this.lbl_logi.Size = new System.Drawing.Size(16, 16);
            this.lbl_logi.TabIndex = 3;
            this.lbl_logi.Text = "0";
            this.lbl_logi.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "逻辑站点";
            // 
            // lbl_phy
            // 
            this.lbl_phy.AutoSize = true;
            this.lbl_phy.Font = new System.Drawing.Font("宋体", 11.5F);
            this.lbl_phy.Location = new System.Drawing.Point(147, 82);
            this.lbl_phy.Name = "lbl_phy";
            this.lbl_phy.Size = new System.Drawing.Size(16, 16);
            this.lbl_phy.TabIndex = 3;
            this.lbl_phy.Text = "0";
            this.lbl_phy.Click += new System.EventHandler(this.label2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "物理站点";
            // 
            // lbl_volt
            // 
            this.lbl_volt.AutoSize = true;
            this.lbl_volt.Font = new System.Drawing.Font("宋体", 11.5F);
            this.lbl_volt.Location = new System.Drawing.Point(153, 168);
            this.lbl_volt.Name = "lbl_volt";
            this.lbl_volt.Size = new System.Drawing.Size(40, 16);
            this.lbl_volt.TabIndex = 3;
            this.lbl_volt.Text = "0.0V";
            this.lbl_volt.Click += new System.EventHandler(this.label2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "电压";
            // 
            // lbl_battery
            // 
            this.lbl_battery.AutoSize = true;
            this.lbl_battery.Font = new System.Drawing.Font("宋体", 11.5F);
            this.lbl_battery.Location = new System.Drawing.Point(221, 167);
            this.lbl_battery.Name = "lbl_battery";
            this.lbl_battery.Size = new System.Drawing.Size(24, 16);
            this.lbl_battery.TabIndex = 3;
            this.lbl_battery.Text = "0%";
            this.lbl_battery.Click += new System.EventHandler(this.label2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(225, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "电量";
            // 
            // pic_hook
            // 
            this.pic_hook.BackColor = System.Drawing.Color.White;
            this.pic_hook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_hook.Location = new System.Drawing.Point(230, 126);
            this.pic_hook.Name = "pic_hook";
            this.pic_hook.Size = new System.Drawing.Size(16, 16);
            this.pic_hook.TabIndex = 2;
            this.pic_hook.TabStop = false;
            // 
            // pic_i1
            // 
            this.pic_i1.BackColor = System.Drawing.Color.White;
            this.pic_i1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_i1.Location = new System.Drawing.Point(120, 107);
            this.pic_i1.Name = "pic_i1";
            this.pic_i1.Size = new System.Drawing.Size(16, 16);
            this.pic_i1.TabIndex = 2;
            this.pic_i1.TabStop = false;
            // 
            // pic_i2
            // 
            this.pic_i2.BackColor = System.Drawing.Color.White;
            this.pic_i2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_i2.Location = new System.Drawing.Point(145, 107);
            this.pic_i2.Name = "pic_i2";
            this.pic_i2.Size = new System.Drawing.Size(16, 16);
            this.pic_i2.TabIndex = 2;
            this.pic_i2.TabStop = false;
            // 
            // pic_i3
            // 
            this.pic_i3.BackColor = System.Drawing.Color.White;
            this.pic_i3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_i3.Location = new System.Drawing.Point(170, 107);
            this.pic_i3.Name = "pic_i3";
            this.pic_i3.Size = new System.Drawing.Size(16, 16);
            this.pic_i3.TabIndex = 2;
            this.pic_i3.TabStop = false;
            // 
            // pic_i4
            // 
            this.pic_i4.BackColor = System.Drawing.Color.White;
            this.pic_i4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_i4.Location = new System.Drawing.Point(195, 107);
            this.pic_i4.Name = "pic_i4";
            this.pic_i4.Size = new System.Drawing.Size(16, 16);
            this.pic_i4.TabIndex = 2;
            this.pic_i4.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(225, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "挂钩";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(85, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "输入";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(124, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(148, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(172, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(197, 126);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 7;
            this.label14.Text = "4";
            // 
            // pic_o4
            // 
            this.pic_o4.BackColor = System.Drawing.Color.White;
            this.pic_o4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_o4.Location = new System.Drawing.Point(195, 141);
            this.pic_o4.Name = "pic_o4";
            this.pic_o4.Size = new System.Drawing.Size(16, 16);
            this.pic_o4.TabIndex = 8;
            this.pic_o4.TabStop = false;
            // 
            // pic_o3
            // 
            this.pic_o3.BackColor = System.Drawing.Color.White;
            this.pic_o3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_o3.Location = new System.Drawing.Point(170, 141);
            this.pic_o3.Name = "pic_o3";
            this.pic_o3.Size = new System.Drawing.Size(16, 16);
            this.pic_o3.TabIndex = 9;
            this.pic_o3.TabStop = false;
            // 
            // pic_o2
            // 
            this.pic_o2.BackColor = System.Drawing.Color.White;
            this.pic_o2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_o2.Location = new System.Drawing.Point(145, 141);
            this.pic_o2.Name = "pic_o2";
            this.pic_o2.Size = new System.Drawing.Size(16, 16);
            this.pic_o2.TabIndex = 10;
            this.pic_o2.TabStop = false;
            // 
            // pic_o1
            // 
            this.pic_o1.BackColor = System.Drawing.Color.White;
            this.pic_o1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_o1.Location = new System.Drawing.Point(120, 141);
            this.pic_o1.Name = "pic_o1";
            this.pic_o1.Size = new System.Drawing.Size(16, 16);
            this.pic_o1.TabIndex = 11;
            this.pic_o1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "输出";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_ready
            // 
            this.btn_ready.BackColor = System.Drawing.Color.Cyan;
            this.btn_ready.Enabled = false;
            this.btn_ready.Location = new System.Drawing.Point(70, 190);
            this.btn_ready.Name = "btn_ready";
            this.btn_ready.Size = new System.Drawing.Size(57, 23);
            this.btn_ready.TabIndex = 13;
            this.btn_ready.Text = "准备";
            this.btn_ready.UseVisualStyleBackColor = false;
            this.btn_ready.Click += new System.EventHandler(this.btn_ready_Click);
            // 
            // btn_fault
            // 
            this.btn_fault.BackColor = System.Drawing.Color.Orange;
            this.btn_fault.Enabled = false;
            this.btn_fault.Location = new System.Drawing.Point(136, 190);
            this.btn_fault.Name = "btn_fault";
            this.btn_fault.Size = new System.Drawing.Size(57, 23);
            this.btn_fault.TabIndex = 13;
            this.btn_fault.Text = "清故障";
            this.btn_fault.UseVisualStyleBackColor = false;
            this.btn_fault.Click += new System.EventHandler(this.btn_fault_Click);
            // 
            // btn_estop
            // 
            this.btn_estop.BackColor = System.Drawing.Color.Red;
            this.btn_estop.Enabled = false;
            this.btn_estop.Location = new System.Drawing.Point(202, 190);
            this.btn_estop.Name = "btn_estop";
            this.btn_estop.Size = new System.Drawing.Size(57, 23);
            this.btn_estop.TabIndex = 13;
            this.btn_estop.Text = "急停";
            this.btn_estop.UseVisualStyleBackColor = false;
            this.btn_estop.Click += new System.EventHandler(this.btn_estop_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(198, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 16);
            this.label15.TabIndex = 14;
            this.label15.Text = "发车次序";
            // 
            // lbl_order
            // 
            this.lbl_order.Font = new System.Drawing.Font("宋体", 25F);
            this.lbl_order.ForeColor = System.Drawing.Color.Purple;
            this.lbl_order.Location = new System.Drawing.Point(198, 29);
            this.lbl_order.Name = "lbl_order";
            this.lbl_order.Size = new System.Drawing.Size(71, 35);
            this.lbl_order.TabIndex = 15;
            this.lbl_order.Text = "0";
            this.lbl_order.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_order.Click += new System.EventHandler(this.lbl_order_Click);
            // 
            // btn_startup
            // 
            this.btn_startup.BackColor = System.Drawing.Color.Lime;
            this.btn_startup.Enabled = false;
            this.btn_startup.Location = new System.Drawing.Point(4, 190);
            this.btn_startup.Name = "btn_startup";
            this.btn_startup.Size = new System.Drawing.Size(57, 23);
            this.btn_startup.TabIndex = 16;
            this.btn_startup.Text = "启动";
            this.btn_startup.UseVisualStyleBackColor = false;
            this.btn_startup.Click += new System.EventHandler(this.btn_startup_Click);
            // 
            // AGVStateIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_startup);
            this.Controls.Add(this.lbl_order);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btn_estop);
            this.Controls.Add(this.btn_fault);
            this.Controls.Add(this.btn_ready);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pic_o4);
            this.Controls.Add(this.pic_o3);
            this.Controls.Add(this.pic_o2);
            this.Controls.Add(this.pic_o1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_ip);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_battery);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_volt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_phy);
            this.Controls.Add(this.lbl_logi);
            this.Controls.Add(this.lbl_state);
            this.Controls.Add(this.lbl_comstate);
            this.Controls.Add(this.pic_i4);
            this.Controls.Add(this.pic_i3);
            this.Controls.Add(this.pic_i2);
            this.Controls.Add(this.pic_i1);
            this.Controls.Add(this.pic_hook);
            this.Controls.Add(this.pic_state);
            this.Controls.Add(this.pic_com);
            this.Controls.Add(this.pic_agv);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.label1);
            this.Name = "AGVStateIndicator";
            this.Size = new System.Drawing.Size(270, 220);
            this.Load += new System.EventHandler(this.AGVStateIndicator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_agv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_com)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_state)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_hook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_i1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_i2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_i3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_i4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_o4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_o3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_o2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_o1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.PictureBox pic_agv;
        private System.Windows.Forms.PictureBox pic_com;
        private System.Windows.Forms.Label lbl_comstate;
        private System.Windows.Forms.PictureBox pic_state;
        private System.Windows.Forms.Label lbl_state;
        private System.Windows.Forms.Label lbl_ip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_logi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_phy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_volt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_battery;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pic_hook;
        private System.Windows.Forms.PictureBox pic_i1;
        private System.Windows.Forms.PictureBox pic_i2;
        private System.Windows.Forms.PictureBox pic_i3;
        private System.Windows.Forms.PictureBox pic_i4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pic_o4;
        private System.Windows.Forms.PictureBox pic_o3;
        private System.Windows.Forms.PictureBox pic_o2;
        private System.Windows.Forms.PictureBox pic_o1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ready;
        private System.Windows.Forms.Button btn_fault;
        private System.Windows.Forms.Button btn_estop;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl_order;
        private System.Windows.Forms.Button btn_startup;
    }
}

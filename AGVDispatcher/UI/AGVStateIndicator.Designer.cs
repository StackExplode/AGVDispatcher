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
            this.lbl_AGVID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pic_com = new System.Windows.Forms.PictureBox();
            this.lbl_comstate = new System.Windows.Forms.Label();
            this.pic_state = new System.Windows.Forms.PictureBox();
            this.lbl_state = new System.Windows.Forms.Label();
            this.lbl_ip = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_logi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_volt = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_battery = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pic_hook = new System.Windows.Forms.PictureBox();
            this.pic_io1 = new System.Windows.Forms.PictureBox();
            this.pic_io2 = new System.Windows.Forms.PictureBox();
            this.pic_io3 = new System.Windows.Forms.PictureBox();
            this.pic_io4 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_com)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_state)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_hook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_io1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_io2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_io3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_io4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "小车编号：";
            // 
            // lbl_AGVID
            // 
            this.lbl_AGVID.Font = new System.Drawing.Font("宋体", 25F);
            this.lbl_AGVID.ForeColor = System.Drawing.Color.Blue;
            this.lbl_AGVID.Location = new System.Drawing.Point(3, 29);
            this.lbl_AGVID.Name = "lbl_AGVID";
            this.lbl_AGVID.Size = new System.Drawing.Size(79, 35);
            this.lbl_AGVID.TabIndex = 0;
            this.lbl_AGVID.Text = "0";
            this.lbl_AGVID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::AGVDispatcher.Properties.Resources.sample_AGV;
            this.pictureBox1.Location = new System.Drawing.Point(4, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pic_com
            // 
            this.pic_com.BackColor = System.Drawing.Color.Red;
            this.pic_com.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_com.Location = new System.Drawing.Point(110, 2);
            this.pic_com.Name = "pic_com";
            this.pic_com.Size = new System.Drawing.Size(24, 24);
            this.pic_com.TabIndex = 2;
            this.pic_com.TabStop = false;
            // 
            // lbl_comstate
            // 
            this.lbl_comstate.AutoSize = true;
            this.lbl_comstate.Font = new System.Drawing.Font("宋体", 11.5F);
            this.lbl_comstate.Location = new System.Drawing.Point(139, 7);
            this.lbl_comstate.Name = "lbl_comstate";
            this.lbl_comstate.Size = new System.Drawing.Size(56, 16);
            this.lbl_comstate.TabIndex = 3;
            this.lbl_comstate.Text = "未连接";
            // 
            // pic_state
            // 
            this.pic_state.BackColor = System.Drawing.Color.Red;
            this.pic_state.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_state.Location = new System.Drawing.Point(110, 32);
            this.pic_state.Name = "pic_state";
            this.pic_state.Size = new System.Drawing.Size(24, 24);
            this.pic_state.TabIndex = 2;
            this.pic_state.TabStop = false;
            // 
            // lbl_state
            // 
            this.lbl_state.AutoSize = true;
            this.lbl_state.Font = new System.Drawing.Font("宋体", 11.5F);
            this.lbl_state.Location = new System.Drawing.Point(139, 37);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(56, 16);
            this.lbl_state.TabIndex = 3;
            this.lbl_state.Text = "未准备";
            this.lbl_state.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.ForeColor = System.Drawing.Color.Blue;
            this.lbl_ip.Location = new System.Drawing.Point(2, 182);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(47, 12);
            this.lbl_ip.TabIndex = 5;
            this.lbl_ip.Text = "0.0.0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "小车IP：";
            // 
            // lbl_logi
            // 
            this.lbl_logi.AutoSize = true;
            this.lbl_logi.Font = new System.Drawing.Font("宋体", 11.5F);
            this.lbl_logi.Location = new System.Drawing.Point(181, 66);
            this.lbl_logi.Name = "lbl_logi";
            this.lbl_logi.Size = new System.Drawing.Size(16, 16);
            this.lbl_logi.TabIndex = 3;
            this.lbl_logi.Text = "0";
            this.lbl_logi.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "逻辑站点：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11.5F);
            this.label4.Location = new System.Drawing.Point(181, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "0";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "物理站点：";
            // 
            // lbl_volt
            // 
            this.lbl_volt.AutoSize = true;
            this.lbl_volt.Font = new System.Drawing.Font("宋体", 11.5F);
            this.lbl_volt.Location = new System.Drawing.Point(124, 109);
            this.lbl_volt.Name = "lbl_volt";
            this.lbl_volt.Size = new System.Drawing.Size(48, 16);
            this.lbl_volt.TabIndex = 3;
            this.lbl_volt.Text = "24.1V";
            this.lbl_volt.Click += new System.EventHandler(this.label2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(85, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "电压：";
            // 
            // lbl_battery
            // 
            this.lbl_battery.AutoSize = true;
            this.lbl_battery.Font = new System.Drawing.Font("宋体", 11.5F);
            this.lbl_battery.Location = new System.Drawing.Point(214, 109);
            this.lbl_battery.Name = "lbl_battery";
            this.lbl_battery.Size = new System.Drawing.Size(40, 16);
            this.lbl_battery.TabIndex = 3;
            this.lbl_battery.Text = "100%";
            this.lbl_battery.Click += new System.EventHandler(this.label2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(178, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "电量：";
            // 
            // pic_hook
            // 
            this.pic_hook.BackColor = System.Drawing.Color.White;
            this.pic_hook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_hook.Location = new System.Drawing.Point(75, 166);
            this.pic_hook.Name = "pic_hook";
            this.pic_hook.Size = new System.Drawing.Size(16, 16);
            this.pic_hook.TabIndex = 2;
            this.pic_hook.TabStop = false;
            // 
            // pic_io1
            // 
            this.pic_io1.BackColor = System.Drawing.Color.Lime;
            this.pic_io1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_io1.Location = new System.Drawing.Point(156, 132);
            this.pic_io1.Name = "pic_io1";
            this.pic_io1.Size = new System.Drawing.Size(16, 16);
            this.pic_io1.TabIndex = 2;
            this.pic_io1.TabStop = false;
            // 
            // pic_io2
            // 
            this.pic_io2.BackColor = System.Drawing.Color.White;
            this.pic_io2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_io2.Location = new System.Drawing.Point(181, 132);
            this.pic_io2.Name = "pic_io2";
            this.pic_io2.Size = new System.Drawing.Size(16, 16);
            this.pic_io2.TabIndex = 2;
            this.pic_io2.TabStop = false;
            // 
            // pic_io3
            // 
            this.pic_io3.BackColor = System.Drawing.Color.White;
            this.pic_io3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_io3.Location = new System.Drawing.Point(206, 132);
            this.pic_io3.Name = "pic_io3";
            this.pic_io3.Size = new System.Drawing.Size(16, 16);
            this.pic_io3.TabIndex = 2;
            this.pic_io3.TabStop = false;
            // 
            // pic_io4
            // 
            this.pic_io4.BackColor = System.Drawing.Color.White;
            this.pic_io4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_io4.Location = new System.Drawing.Point(231, 132);
            this.pic_io4.Name = "pic_io4";
            this.pic_io4.Size = new System.Drawing.Size(16, 16);
            this.pic_io4.TabIndex = 2;
            this.pic_io4.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "挂钩状态";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(109, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "输入：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(160, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(184, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(208, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(233, 151);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 7;
            this.label14.Text = "4";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(231, 166);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(206, 166);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(181, 166);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Lime;
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(156, 166);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "输出：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AGVStateIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_logi);
            this.Controls.Add(this.lbl_state);
            this.Controls.Add(this.lbl_comstate);
            this.Controls.Add(this.pic_io4);
            this.Controls.Add(this.pic_io3);
            this.Controls.Add(this.pic_io2);
            this.Controls.Add(this.pic_io1);
            this.Controls.Add(this.pic_hook);
            this.Controls.Add(this.pic_state);
            this.Controls.Add(this.pic_com);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_AGVID);
            this.Controls.Add(this.label1);
            this.Name = "AGVStateIndicator";
            this.Size = new System.Drawing.Size(257, 203);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_com)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_state)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_hook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_io1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_io2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_io3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_io4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_AGVID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pic_com;
        private System.Windows.Forms.Label lbl_comstate;
        private System.Windows.Forms.PictureBox pic_state;
        private System.Windows.Forms.Label lbl_state;
        private System.Windows.Forms.Label lbl_ip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_logi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_volt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_battery;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pic_hook;
        private System.Windows.Forms.PictureBox pic_io1;
        private System.Windows.Forms.PictureBox pic_io2;
        private System.Windows.Forms.PictureBox pic_io3;
        private System.Windows.Forms.PictureBox pic_io4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label2;
    }
}

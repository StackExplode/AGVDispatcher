
namespace AGVDispatcher.UI
{
    partial class fm_run
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_run));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_map = new System.Windows.Forms.Panel();
            this.panel_agv = new System.Windows.Forms.Panel();
            this.panel_op = new System.Windows.Forms.Panel();
            this.mapView1 = new AGVDispatcher.UI.MapView();
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.btn_ready = new System.Windows.Forms.Button();
            this.btn_estop = new System.Windows.Forms.Button();
            this.btn_removeagv = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_map.SuspendLayout();
            this.panel_op.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel_map, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_agv, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_op, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.91018F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.08982F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1412, 876);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_map
            // 
            this.panel_map.Controls.Add(this.mapView1);
            this.panel_map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_map.Location = new System.Drawing.Point(272, 0);
            this.panel_map.Margin = new System.Windows.Forms.Padding(0);
            this.panel_map.Name = "panel_map";
            this.panel_map.Size = new System.Drawing.Size(1140, 393);
            this.panel_map.TabIndex = 0;
            // 
            // panel_agv
            // 
            this.panel_agv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_agv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_agv.Location = new System.Drawing.Point(0, 0);
            this.panel_agv.Margin = new System.Windows.Forms.Padding(0);
            this.panel_agv.Name = "panel_agv";
            this.tableLayoutPanel1.SetRowSpan(this.panel_agv, 2);
            this.panel_agv.Size = new System.Drawing.Size(272, 876);
            this.panel_agv.TabIndex = 1;
            // 
            // panel_op
            // 
            this.panel_op.Controls.Add(this.label6);
            this.panel_op.Controls.Add(this.label4);
            this.panel_op.Controls.Add(this.label5);
            this.panel_op.Controls.Add(this.label3);
            this.panel_op.Controls.Add(this.label2);
            this.panel_op.Controls.Add(this.label1);
            this.panel_op.Controls.Add(this.btn_exit);
            this.panel_op.Controls.Add(this.btn_removeagv);
            this.panel_op.Controls.Add(this.btn_estop);
            this.panel_op.Controls.Add(this.btn_ready);
            this.panel_op.Controls.Add(this.btn_pause);
            this.panel_op.Controls.Add(this.btn_run);
            this.panel_op.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_op.Location = new System.Drawing.Point(275, 396);
            this.panel_op.Name = "panel_op";
            this.panel_op.Size = new System.Drawing.Size(1134, 477);
            this.panel_op.TabIndex = 2;
            // 
            // mapView1
            // 
            this.mapView1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mapView1.BackgroundImage")));
            this.mapView1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapView1.Location = new System.Drawing.Point(0, 0);
            this.mapView1.Name = "mapView1";
            this.mapView1.Size = new System.Drawing.Size(1140, 393);
            this.mapView1.TabIndex = 0;
            // 
            // btn_run
            // 
            this.btn_run.BackColor = System.Drawing.Color.Lime;
            this.btn_run.Font = new System.Drawing.Font("黑体", 20F);
            this.btn_run.Location = new System.Drawing.Point(12, 12);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(181, 56);
            this.btn_run.TabIndex = 0;
            this.btn_run.Text = "开始运行";
            this.btn_run.UseVisualStyleBackColor = false;
            this.btn_run.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.BackColor = System.Drawing.Color.HotPink;
            this.btn_pause.Enabled = false;
            this.btn_pause.Font = new System.Drawing.Font("黑体", 20F);
            this.btn_pause.Location = new System.Drawing.Point(12, 170);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(181, 56);
            this.btn_pause.TabIndex = 0;
            this.btn_pause.Tag = "0";
            this.btn_pause.Text = "全部暂停";
            this.btn_pause.UseVisualStyleBackColor = false;
            // 
            // btn_ready
            // 
            this.btn_ready.BackColor = System.Drawing.Color.Turquoise;
            this.btn_ready.Font = new System.Drawing.Font("黑体", 20F);
            this.btn_ready.Location = new System.Drawing.Point(12, 91);
            this.btn_ready.Name = "btn_ready";
            this.btn_ready.Size = new System.Drawing.Size(181, 56);
            this.btn_ready.TabIndex = 0;
            this.btn_ready.Text = "全部准备";
            this.btn_ready.UseVisualStyleBackColor = false;
            this.btn_ready.Click += new System.EventHandler(this.btn_ready_Click);
            // 
            // btn_estop
            // 
            this.btn_estop.BackColor = System.Drawing.Color.Red;
            this.btn_estop.Enabled = false;
            this.btn_estop.Font = new System.Drawing.Font("黑体", 20F);
            this.btn_estop.Location = new System.Drawing.Point(12, 249);
            this.btn_estop.Name = "btn_estop";
            this.btn_estop.Size = new System.Drawing.Size(181, 56);
            this.btn_estop.TabIndex = 0;
            this.btn_estop.Text = "全部急停";
            this.btn_estop.UseVisualStyleBackColor = false;
            this.btn_estop.Click += new System.EventHandler(this.btn_estop_Click);
            // 
            // btn_removeagv
            // 
            this.btn_removeagv.BackColor = System.Drawing.Color.Orange;
            this.btn_removeagv.Enabled = false;
            this.btn_removeagv.Font = new System.Drawing.Font("黑体", 20F);
            this.btn_removeagv.Location = new System.Drawing.Point(12, 328);
            this.btn_removeagv.Name = "btn_removeagv";
            this.btn_removeagv.Size = new System.Drawing.Size(181, 56);
            this.btn_removeagv.TabIndex = 0;
            this.btn_removeagv.Text = "移除故障AGV";
            this.btn_removeagv.UseVisualStyleBackColor = false;
            this.btn_removeagv.Click += new System.EventHandler(this.btn_removeagv_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("黑体", 20F);
            this.btn_exit.Location = new System.Drawing.Point(12, 407);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(181, 56);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Text = "退出程序";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.button6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(199, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(772, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "请检查所有AGV、PLC的通信和状态均处于正常状态（绿色），并且已经放置于指定出发点。\r\n否则若部分设备异常，则须全部返回起点才能重新操作！";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(199, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "本功能尚未实现！";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(199, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(571, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "通常开始运行前不需要按这个，特殊情况有AGV未准备可批量准备。";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(199, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(541, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "一旦全体急停，所有任务将失效，必须返回起点方能重新操作！";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(199, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(658, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "请确保待移除AGV状态已经是故障或急停。移除运行中的AGV可能会导致失控！";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(199, 429);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(647, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "请确保所有任务完成后再退出。否则AGV不再受本程序控制，可能导致失控！";
            // 
            // fm_run
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 876);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fm_run";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AGV运行管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fm_run_FormClosing);
            this.Load += new System.EventHandler(this.fm_run_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_map.ResumeLayout(false);
            this.panel_op.ResumeLayout(false);
            this.panel_op.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_agv;
        private System.Windows.Forms.Panel panel_map;
        private MapView mapView1;
        private System.Windows.Forms.Panel panel_op;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_removeagv;
        private System.Windows.Forms.Button btn_estop;
        private System.Windows.Forms.Button btn_ready;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
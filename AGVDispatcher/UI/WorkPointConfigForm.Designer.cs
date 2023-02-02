
namespace AGVDispatcher.UI
{
    partial class WorkPointConfigForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_phy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_plc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_work = new System.Windows.Forms.TextBox();
            this.txt_finish = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_work = new System.Windows.Forms.ComboBox();
            this.cmb_finish = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(172, 148);
            // 
            // lbl_logi
            // 
            this.lbl_logi.Size = new System.Drawing.Size(29, 12);
            this.lbl_logi.Text = "null";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(12, 148);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "物理站号：";
            // 
            // txt_phy
            // 
            this.txt_phy.Location = new System.Drawing.Point(83, 27);
            this.txt_phy.Name = "txt_phy";
            this.txt_phy.Size = new System.Drawing.Size(103, 21);
            this.txt_phy.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "PLC序号：";
            // 
            // txt_plc
            // 
            this.txt_plc.Location = new System.Drawing.Point(75, 54);
            this.txt_plc.Name = "txt_plc";
            this.txt_plc.Size = new System.Drawing.Size(64, 21);
            this.txt_plc.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(145, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "注意是序号不是编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "作业IO号：";
            // 
            // txt_work
            // 
            this.txt_work.Location = new System.Drawing.Point(83, 82);
            this.txt_work.Name = "txt_work";
            this.txt_work.Size = new System.Drawing.Size(56, 21);
            this.txt_work.TabIndex = 12;
            // 
            // txt_finish
            // 
            this.txt_finish.Location = new System.Drawing.Point(83, 112);
            this.txt_finish.Name = "txt_finish";
            this.txt_finish.Size = new System.Drawing.Size(56, 21);
            this.txt_finish.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "完成IO号：";
            // 
            // cmb_work
            // 
            this.cmb_work.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_work.FormattingEnabled = true;
            this.cmb_work.Items.AddRange(new object[] {
            "高电平有效",
            "低电平有效"});
            this.cmb_work.Location = new System.Drawing.Point(145, 82);
            this.cmb_work.Name = "cmb_work";
            this.cmb_work.Size = new System.Drawing.Size(102, 20);
            this.cmb_work.TabIndex = 15;
            // 
            // cmb_finish
            // 
            this.cmb_finish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_finish.FormattingEnabled = true;
            this.cmb_finish.Items.AddRange(new object[] {
            "高电平有效",
            "低电平有效"});
            this.cmb_finish.Location = new System.Drawing.Point(145, 112);
            this.cmb_finish.Name = "cmb_finish";
            this.cmb_finish.Size = new System.Drawing.Size(102, 20);
            this.cmb_finish.TabIndex = 16;
            // 
            // WorkPointConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 183);
            this.Controls.Add(this.cmb_finish);
            this.Controls.Add(this.cmb_work);
            this.Controls.Add(this.txt_finish);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_work);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_plc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_phy);
            this.Controls.Add(this.label1);
            this.Name = "WorkPointConfigForm";
            this.Text = "作业站点设置";
            this.Load += new System.EventHandler(this.WorkPointConfigForm_Load);
            this.Controls.SetChildIndex(this.btn_ok, 0);
            this.Controls.SetChildIndex(this.btn_cancel, 0);
            this.Controls.SetChildIndex(this.label_logic_station_info, 0);
            this.Controls.SetChildIndex(this.lbl_logi, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txt_phy, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txt_plc, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txt_work, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txt_finish, 0);
            this.Controls.SetChildIndex(this.cmb_work, 0);
            this.Controls.SetChildIndex(this.cmb_finish, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_phy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_plc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_work;
        private System.Windows.Forms.TextBox txt_finish;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_work;
        private System.Windows.Forms.ComboBox cmb_finish;
    }
}
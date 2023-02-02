
namespace AGVDispatcher.UI
{
    partial class CheckPointConfigForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.txt_plc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_finish = new System.Windows.Forms.ComboBox();
            this.txt_finish = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_phy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(171, 123);
            // 
            // lbl_logi
            // 
            this.lbl_logi.Size = new System.Drawing.Size(29, 12);
            this.lbl_logi.Text = "null";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(12, 123);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(147, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "注意是序号不是编号";
            // 
            // txt_plc
            // 
            this.txt_plc.Location = new System.Drawing.Point(77, 56);
            this.txt_plc.Name = "txt_plc";
            this.txt_plc.Size = new System.Drawing.Size(64, 21);
            this.txt_plc.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "PLC序号：";
            // 
            // cmb_finish
            // 
            this.cmb_finish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_finish.FormattingEnabled = true;
            this.cmb_finish.Items.AddRange(new object[] {
            "高电平有效",
            "低电平有效"});
            this.cmb_finish.Location = new System.Drawing.Point(149, 88);
            this.cmb_finish.Name = "cmb_finish";
            this.cmb_finish.Size = new System.Drawing.Size(102, 20);
            this.cmb_finish.TabIndex = 21;
            // 
            // txt_finish
            // 
            this.txt_finish.Location = new System.Drawing.Point(83, 89);
            this.txt_finish.Name = "txt_finish";
            this.txt_finish.Size = new System.Drawing.Size(58, 21);
            this.txt_finish.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "完成IO号：";
            // 
            // txt_phy
            // 
            this.txt_phy.Location = new System.Drawing.Point(83, 29);
            this.txt_phy.Name = "txt_phy";
            this.txt_phy.Size = new System.Drawing.Size(103, 21);
            this.txt_phy.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "物理站号：";
            // 
            // CheckPointConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 158);
            this.Controls.Add(this.cmb_finish);
            this.Controls.Add(this.txt_finish);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_phy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_plc);
            this.Controls.Add(this.label2);
            this.Name = "CheckPointConfigForm";
            this.Text = "检测站点设置";
            this.Controls.SetChildIndex(this.btn_ok, 0);
            this.Controls.SetChildIndex(this.btn_cancel, 0);
            this.Controls.SetChildIndex(this.label_logic_station_info, 0);
            this.Controls.SetChildIndex(this.lbl_logi, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txt_plc, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txt_phy, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txt_finish, 0);
            this.Controls.SetChildIndex(this.cmb_finish, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_plc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_finish;
        private System.Windows.Forms.TextBox txt_finish;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_phy;
        private System.Windows.Forms.Label label1;
    }
}
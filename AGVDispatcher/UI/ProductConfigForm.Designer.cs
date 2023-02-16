
namespace AGVDispatcher.UI
{
    partial class ProductConfigForm
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
            this.lbl_prod_id = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_phy = new System.Windows.Forms.TextBox();
            this.rad_pick = new System.Windows.Forms.RadioButton();
            this.rad_put = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(130, 127);
            // 
            // lbl_logi
            // 
            this.lbl_logi.Size = new System.Drawing.Size(29, 12);
            this.lbl_logi.Text = "null";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(12, 127);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "货物编号：";
            // 
            // lbl_prod_id
            // 
            this.lbl_prod_id.AutoSize = true;
            this.lbl_prod_id.Location = new System.Drawing.Point(83, 32);
            this.lbl_prod_id.Name = "lbl_prod_id";
            this.lbl_prod_id.Size = new System.Drawing.Size(41, 12);
            this.lbl_prod_id.TabIndex = 7;
            this.lbl_prod_id.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "物理站号：";
            // 
            // txt_phy
            // 
            this.txt_phy.Location = new System.Drawing.Point(83, 53);
            this.txt_phy.Name = "txt_phy";
            this.txt_phy.Size = new System.Drawing.Size(122, 21);
            this.txt_phy.TabIndex = 0;
            // 
            // rad_pick
            // 
            this.rad_pick.AutoSize = true;
            this.rad_pick.Enabled = false;
            this.rad_pick.Location = new System.Drawing.Point(18, 80);
            this.rad_pick.Name = "rad_pick";
            this.rad_pick.Size = new System.Drawing.Size(59, 16);
            this.rad_pick.TabIndex = 10;
            this.rad_pick.TabStop = true;
            this.rad_pick.Text = "取货点";
            this.rad_pick.UseVisualStyleBackColor = true;
            // 
            // rad_put
            // 
            this.rad_put.AutoSize = true;
            this.rad_put.Enabled = false;
            this.rad_put.Location = new System.Drawing.Point(18, 102);
            this.rad_put.Name = "rad_put";
            this.rad_put.Size = new System.Drawing.Size(59, 16);
            this.rad_put.TabIndex = 11;
            this.rad_put.TabStop = true;
            this.rad_put.Text = "存货点";
            this.rad_put.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(127, 93);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "有货物";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ProductConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 162);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.rad_put);
            this.Controls.Add(this.rad_pick);
            this.Controls.Add(this.txt_phy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_prod_id);
            this.Controls.Add(this.label1);
            this.Name = "ProductConfigForm";
            this.Text = "货物站点设置";
            this.Controls.SetChildIndex(this.btn_ok, 0);
            this.Controls.SetChildIndex(this.btn_cancel, 0);
            this.Controls.SetChildIndex(this.label_logic_station_info, 0);
            this.Controls.SetChildIndex(this.lbl_logi, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lbl_prod_id, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txt_phy, 0);
            this.Controls.SetChildIndex(this.rad_pick, 0);
            this.Controls.SetChildIndex(this.rad_put, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_prod_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_phy;
        private System.Windows.Forms.RadioButton rad_pick;
        private System.Windows.Forms.RadioButton rad_put;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

namespace AGVDispatcher.UI
{
    partial class NormalPointConfigForm
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
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(135, 75);
            // 
            // lbl_logi
            // 
            this.lbl_logi.Location = new System.Drawing.Point(79, 9);
            this.lbl_logi.Size = new System.Drawing.Size(29, 12);
            this.lbl_logi.Text = "null";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(23, 75);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "物理站号：";
            // 
            // txt_phy
            // 
            this.txt_phy.Location = new System.Drawing.Point(81, 39);
            this.txt_phy.Name = "txt_phy";
            this.txt_phy.Size = new System.Drawing.Size(127, 21);
            this.txt_phy.TabIndex = 0;
            // 
            // NormalPointConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 110);
            this.Controls.Add(this.txt_phy);
            this.Controls.Add(this.label1);
            this.Name = "NormalPointConfigForm";
            this.Text = "一般站点设置";
            this.Controls.SetChildIndex(this.label_logic_station_info, 0);
            this.Controls.SetChildIndex(this.lbl_logi, 0);
            this.Controls.SetChildIndex(this.btn_ok, 0);
            this.Controls.SetChildIndex(this.btn_cancel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txt_phy, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_phy;
    }
}
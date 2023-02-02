using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGVDispatcher.UI
{
    [DesignTimeVisible(false)]
    public class PointConfigForm : Form
    {
        protected Button btn_cancel;
        protected Label label_logic_station_info;
        protected Label lbl_logi;
        protected Button btn_ok;
        protected IPoint Point { get; set; }

        public PointConfigForm()
        {
            InitializeComponent();
            btn_cancel.Click += (_,_) => this.Close();
            btn_ok.Click += (_, _) => { SetPointProperty(Point); this.Close(); };
            this.Load += (_, _) => 
            {
                lbl_logi.Text = Point?.LogicID.ToString() ?? "null";
                InitFormValue(Point);
            };
            this.AcceptButton = btn_ok;
            this.CancelButton = btn_cancel;
        }
        protected virtual void SetPointProperty(IPoint pt) => throw new NotImplementedException();
        protected virtual void InitFormValue(IPoint pt) 
        {
            
        }

        protected void InitializeComponent()
        {
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label_logic_station_info = new System.Windows.Forms.Label();
            this.lbl_logi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(113, 81);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(12, 81);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            // 
            // label_logic_station_info
            // 
            this.label_logic_station_info.AutoSize = true;
            this.label_logic_station_info.Location = new System.Drawing.Point(10, 9);
            this.label_logic_station_info.Name = "label_logic_station_info";
            this.label_logic_station_info.Size = new System.Drawing.Size(65, 12);
            this.label_logic_station_info.TabIndex = 4;
            this.label_logic_station_info.Text = "逻辑站号：";
            // 
            // lbl_logi
            // 
            this.lbl_logi.AutoSize = true;
            this.lbl_logi.Location = new System.Drawing.Point(81, 9);
            this.lbl_logi.Name = "lbl_logi";
            this.lbl_logi.Size = new System.Drawing.Size(11, 12);
            this.lbl_logi.TabIndex = 5;
            this.lbl_logi.Text = "0";
            // 
            // PointConfigForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 131);
            this.Controls.Add(this.lbl_logi);
            this.Controls.Add(this.label_logic_station_info);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PointConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }


       
    }


}

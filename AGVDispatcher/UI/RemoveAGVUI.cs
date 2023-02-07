using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AGVDispatcher.App;
using AGVDispatcher.Entity;
using AGVDispatcher.Util;

namespace AGVDispatcher.UI
{
    public partial class RemoveAGVUI : Form
    {
        int? ret = null;
        public int? Result => ret;

        public RemoveAGVUI(List<int> list)
        {
            InitializeComponent();
            comboBox1.DataSource = list;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ret = comboBox1.SelectedItem as int?;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ret = null;
            this.Close();
        }
    }
}

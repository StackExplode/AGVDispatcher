using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGVDispatcher.UI
{
    public partial class TurnPointConfigForm : NormalPointConfigForm
    {
        public TurnPointConfigForm(TurnPoint pt):base(pt)
        {
            InitializeComponent();
            this.Height = base.Height;
            this.Width = base.Width;
        }
    }
}

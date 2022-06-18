using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{
    public partial class Orders : Form
    {
        public static  Orders orders = new Orders();
        public Orders()
        {
            InitializeComponent();
            orders = this;
        }
        protected override CreateParams CreateParams  //防止界面闪烁  同时也去除了动画
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kojiro_ordering_management_system
{
    public partial class Main_interface : Form
    {
        public Ordering_food ordering_Food = new Ordering_food();//实例化
        public Main_interface()
        {
            InitializeComponent();
            
        }

        private void Main_interface_Load(object sender, EventArgs e)
        {
            
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            User_side.user_Side.loadform(My_information.my_Information);
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            User_side.user_Side.loadform(ordering_Food);//调用主窗体方法打开点餐窗体
        }
    }
}

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
    public partial class Shipping_address : Form
    {
        public Shipping_address()
        {
            InitializeComponent();
        }

        public void pictureBox2_Click(object sender, EventArgs e)
        {
            User_side.user_Side.loadform(My_information.my_Information);//打开窗体
            
        }
    }
}

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
    public partial class Retrieve_pwd : Form
    {
        public Retrieve_pwd()
        {
            InitializeComponent();
        }

        private void Retrieve_pwd_Load(object sender, EventArgs e)
        {
            Text = "找回密码";

            linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;//超链接文本去除下划线


        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}

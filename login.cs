using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "小次郎点餐系统";
            linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;//两个超链接文本去除下划线
            linkLabel2.LinkBehavior = LinkBehavior.NeverUnderline;
            statusStrip1.BackColor = Color.Transparent;


        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Retrieve_pwd retrieve = new Retrieve_pwd();//实例化密码框
            retrieve.Show();//打开密码框
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 enroll = new Form2();
            enroll.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}

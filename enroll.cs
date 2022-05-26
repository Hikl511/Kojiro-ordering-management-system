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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Text = "注册小次郎";
            statusStrip1.BackColor = Color.Transparent;//控件透明
            linkLabel2.LinkBehavior = LinkBehavior.NeverUnderline;//超链接文本去除下划线
            //显示时间
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //对timer1进行设置
            timer1.Interval = 1000;//1秒
            this.timer1.Start();//开启计时器

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
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
            label1.Visible = false;//加载时隐藏提示文本
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            
            if (textBox1.Text != "")
            {
                if (textBox2.Text!="")
                {
                    string Uid = textBox1.Text;
                    string Pwd = textBox2.Text;
                    string sql = string.Format("select* from Ustable where Uid = '{0}' and pwd = '{1}'", Uid,Pwd);//验证登录账号和密码是否一致
                    SqlDataReader dr = DBHelper.GDR(sql);
                    if (dr.HasRows)
                    {
                        DBHelper.conn.Close();//查询之后关闭
                        MessageBox.Show("成功");
                        label1.Visible = false;//成功后把错误提示文本隐藏
                    }
                    else
                    {
                        DBHelper.conn.Close();//查询之后关闭
                        label1.Text = "账号或密码错误！";
                        label1.Visible = true;
                        textBox1.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
                        textBox2.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
                    }

                }
                else
                {
                    label1.Text = "请输入密码！";
                    label1.Visible = true;
                }
            }
            else
            {
                label1.Text = "请输入用户名！";
                label1.Visible = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Retrieve_pwd retrieve = new Retrieve_pwd();//实例化找回密码框
            retrieve.Show();//打开找回密码框
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

        private void butClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//最小化
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{
    public partial class Change_Password : Form
    {

        public Change_Password()
        {
            InitializeComponent();
        }
        public string Uid = Form1.form1.textBox1.Text;
        public string Pwd = Form1.form1.textBox2.Text;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //复选框被勾选，明文显示
                textBox2.PasswordChar = new char();
                textBox3.PasswordChar = new char();
            }
            else
            {
                //复选框被取消勾选，密文显示
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }

        String newPwd;
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox2.Text!="" && textBox3.Text!="")
            {
                if (textBox2.Text==textBox3.Text)
                {
                    newPwd = textBox3.Text;//新密码
                    string Cpwd = string.Format("update Ustable set pwd='{0}' where Uid='{1}'", newPwd, Form1.form1.textBox1.Text);
                    if (DBHelper.ENQ(Cpwd))
                    {
                        DialogResult result = MessageBox.Show("修改成功！" + "\n" + "新密码：" + newPwd +"\n" + "点击确定返回登录！","修改密码", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result==DialogResult.OK)
                        {
                            User_side.user_Side.Close();
                            Form1.form1.Show();
                        }
                    }
                }
                else
                {
                    label1.Text = "两次密码输入不一致！";
                    label1.Visible = true;
                    textBox2.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
                    textBox3.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
                }
            }
            else
            {
                label1.Text = "密码框不能为空！";
                label1.Visible = true;
                textBox2.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
                textBox3.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
                My_information my_Information = new My_information();
                User_side.user_Side.loadform(my_Information);
        }
        

        private void Change_Password_Load(object sender, EventArgs e)
        {
            
        }
    }
}

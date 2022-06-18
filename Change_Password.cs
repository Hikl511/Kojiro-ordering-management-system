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
    public partial class Change_Password : Form
    {
        public Change_Password()
        {
            InitializeComponent();
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                string NewPwd = textBox3.Text;
                if (textBox2.Text==textBox3.Text)
                {
                    string sql = string.Format("update Ustable set pwd ={0}  where Uid = '{1}' and Phone = '{2}'", NewPwd, Form1.form1.textBox1.Text);
                    if (DBHelper.ENQ(sql))
                    {

                    }
                }
                else
                {
                    label1.Text = "两次密码不一致！";
                    label1.Visible = true;
                }
            }
            else
            {
                label1.Text = "密码框不能留空！";
                label1.Visible = true;
            }
        }
    }
}

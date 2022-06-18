using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system.用户端
{
    public partial class Change_Password : Form
    {
        public Change_Password()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            My_information my_Information = new My_information();
            User_side.user_Side.loadform(my_Information);
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
            if (textBox2.Text!=""&&textBox3.Text!="")
            {
                string newPwd = textBox2.Text;
                string sql = string.Format("update Ustable set pwd ={0}  where Uid = '{1}'", newPwd, Form1.form1.textBox1.Text);
                if (DBHelper.ENQ(sql))
                {
                    DialogResult result = MessageBox.Show("修改成功！" + "\n" + "新密码：" + newPwd + "即将返回登录", "修改密码", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        Form1 form = new Form1();
                        form.Show();
                        Close();
                    }
                }
                else
                {
                    label1.Text = "修改失败 两次密码不一致！";
                    label1.Visible = true;
                    textBox2.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
                    textBox3.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
                }
            }
            else
            {
                label1.Text = "请输入密码或确认密码！";
                label1.Visible = true;
                textBox2.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
                textBox3.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
            }
        }

        private void Change_Password_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Data.SqlClient;
using System.Drawing;
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

            //加载时显示验证码
            code = GenerateCheckCode();//生成4位数字符串
            Bitmap image = CreateCheckCodeImage(code, 64, 30);//生成图片
            pictureBox4.Image = image;//给控件赋值
        }


        ///验证码
        /// <summary>
        /// 得到验证码
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GenerateCheckCode()
        {
            int number;
            char code;
            string checkCode = String.Empty;

            Random random = new Random();

            for (int i = 0; i < 4; i++)//产生4个随机数
            {
                number = random.Next();

                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else if (number % 3 == 0)
                    code = (char)('A' + (char)(number % 26));
                else
                    code = (char)('a' + (char)(number % 26));
                checkCode += code.ToString();
            }
            return checkCode.ToUpper();
        }

        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <param name="checkCode"></param>
        /// <param name="context"></param>
        private Bitmap CreateCheckCodeImage(string checkCode, int w = 54, int h = 22)
        {
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(w, h);
            //新建GDI对象
            Graphics g = Graphics.FromImage(image);

            g.Clear(Color.White);//清除背景色

            Color[] color = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };//定义随机颜色

            string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };//定义随机字体
            Random rand = new Random();
            int z = 20;//干扰线条数
            for (int i = 0; i < z; i++)
            {
                int x1 = rand.Next(image.Width);//随机坐标
                int x2 = rand.Next(image.Width);
                int y1 = rand.Next(image.Height);
                int y2 = rand.Next(image.Height);
                g.DrawLine(new Pen(Color.LightGray, 2), x1, y1, x2, y2);//new一个pen 然后根据随机坐标画线  
            }

            for (int i = 0; i < checkCode.Length; i++)
            {
                int colorindex = rand.Next(7);//随机一个数 用来当颜色数组的下标
                int fontindex = rand.Next(5);// 当字体数组的下标
                Font f = new Font(font[fontindex], 12, FontStyle.Bold);//随机获取字体 并设置为粗体显示
                Brush b = new SolidBrush(color[colorindex]);//随机获取颜色
                int ii = 4;
                if ((i + 1) % 2 == 0)
                {
                    ii = 2;
                }
                g.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * (14)), ii);//生成验证码 把code传进来 设置字体 颜色 
            }
            g.DrawRectangle(new Pen(Color.White, 0), 0, 0, image.Width - 1, image.Height - 1);//画一个矩形
            return image;
        }
        string code;
        private void pictureBox4_Click(object sender, EventArgs e)
        {

            code = GenerateCheckCode();//生成4位数字符串
            Bitmap image = CreateCheckCodeImage(code, 64, 30);//生成图片
            pictureBox4.Image = image;//给控件赋值
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
            if (textBox1.Text != "")//判断用户名
            {

                if (textBox2.Text != "")//判断手机号不为空
                {
                    if (textBox2.Text.Length == 11)//手机号长度是否==11
                    {
                        if (textBox3.Text != "")//判断密码框是否输入
                        {
                            if (textBox4.Text != "")
                            {
                                if (textBox4.Text.Equals(code))//判断验证码是否正确
                                {
                                    string Uid = textBox1.Text;
                                    string Phone = textBox2.Text;
                                    string NewPwd = textBox3.Text;
                                    string sql = string.Format("update Ustable set pwd ={0}  where Uid = '{1}' and Phone = '{2}'", NewPwd, Uid, Phone);
                                    
                                    if (DBHelper.ENQ(sql))
                                    {
                                        label5.Text = "修改成功 请返回登录！";
                                        label5.Visible = true;
                                        //清空所有文本框
                                        textBox1.Text = "";
                                        textBox2.Text = "";
                                        textBox4.Text = "";
                                        textBox3.Text = "";
                                    }
                                    else
                                    {
                                        label5.Text = "修改失败 请检查用户名或手机号是否正确！";
                                        label5.Visible = true;
                                    }
                                }
                                else
                                {
                                    label5.Text = "验证码错误 请重新输入！";
                                    label5.Visible = true;
                                    textBox4.Text = "";//清空验证码框
                                                       //之后刷新验证码
                                    code = GenerateCheckCode();//生成4位数字符串
                                    Bitmap image = CreateCheckCodeImage(code, 64, 30);//生成图片
                                    pictureBox4.Image = image;//给控件赋值
                                }
                            }
                            else
                            {
                                label5.Text = "请输入验证码！";
                                label5.Visible = true;
                            }
                        }
                        else
                        {
                            label5.Text = "请输入新密码！";
                            label5.Visible = true;
                        }
                    }
                    else
                    {
                        label5.Text = "请输入正确的11位手机号！";
                        label5.Visible = true;
                    }
                }
                else
                {
                    label5.Text = "请输入手机号！";
                    label5.Visible = true;
                }
            }
            else
            {
                label5.Text = "请输入用户名！";
                label5.Visible = true;
            }
        }


    }
}

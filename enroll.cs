using System;
using System.Data.SqlClient;
using System.Drawing;
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

            //加载时生成验证码
            code = GenerateCheckCode();//生成4位数字符串
            Bitmap image = CreateCheckCodeImage(code, 64, 30);//生成图片
            pictureBox11.Image = image;//给控件赋值

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
            Close();//关闭当前窗口
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")//判断密码框
                {
                    if (textBox3.Text != "")
                    {
                        if (textBox2.Text == textBox3.Text)
                        {
                            if (textBox4.Text != "")
                            {
                                if (textBox5.Text != "")
                                {
                                    if (textBox6.Text != "")
                                    {
                                        if (textBox6.Text.Length == 11)//判断长度是否等于11
                                        {
                                            if (textBox7.Text != "")//判断验证码框是否为空
                                            {
                                                if (textBox7.Text.Equals(code))//判断验证码是否正确
                                                {

                                                    string Uid = textBox1.Text;//用户名
                                                    string Pwd = textBox2.Text;//密码
                                                    string Name = textBox4.Text;//姓名
                                                    string Addres = textBox5.Text;//地址
                                                    string Phone = textBox6.Text;//手机
                                                    string Addtime = DateTime.Now.ToString("yyyy-MM-dd"); //获取当前日期 年 - 月 - 日显示  //注册日期
                                                    string sql = string.Format("insert Ustable values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", Name, Phone, Uid, Pwd, Addres, Addtime);
                                                    string sql2 = string.Format("select* from Ustable where Uid = {0}", Uid);
                                                    string sql3 = string.Format("select* from Ustable where Phone = {0}", Phone);
                                                    SqlDataReader dr1 = DBHelper.GDR(sql2);
                                                    if (dr1.HasRows)//验证账户是否已注册
                                                    {
                                                        DBHelper.conn.Close();//查询之后关闭
                                                        label8.Text = "该账户已注册，无法再次注册！";
                                                        label8.Visible = true;//账号已注册时 显示错误文本
                                                        textBox1.Text = "";//清空文本框
                                                        textBox7.Text = "";//清空验证码框
                                                                           //然后刷新验证码
                                                        code = GenerateCheckCode();//生成4位数字符串
                                                        Bitmap image = CreateCheckCodeImage(code, 64, 30);//生成图片
                                                        pictureBox11.Image = image;//给控件赋值
                                                    }
                                                    else
                                                    {
                                                        DBHelper.conn.Close();//查询之后关闭
                                                        SqlDataReader dr2 = DBHelper.GDR(sql3);
                                                        if (dr2.HasRows)//验证手机是否注册
                                                        {
                                                            DBHelper.conn.Close();//查询之后关闭
                                                            label8.Text = "该手机号已注册，无法再次注册！";
                                                            label8.Visible = true;//手机号已注册显示错误文本
                                                            //然后把手机框清空
                                                            textBox6.Text = "";
                                                            textBox7.Text = "";//清空验证码框
                                                                              //然后刷新验证码
                                                            code = GenerateCheckCode();//生成4位数字符串
                                                            Bitmap image = CreateCheckCodeImage(code, 64, 30);//生成图片
                                                            pictureBox11.Image = image;//给控件赋值
                                                        }
                                                        else
                                                        {
                                                            if (DBHelper.ENQ(sql))//条件都满足就添加数据 提示注册成功
                                                            {
                                                                DBHelper.conn.Close();//查询之后关闭
                                                                MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                label8.Text = "注册成功 请返回登录！";
                                                                label8.Visible = true;
                                                                //注册成功后清空所有框
                                                                textBox1.Text = "";
                                                                textBox2.Text = "";
                                                                textBox3.Text = "";
                                                                textBox4.Text = "";
                                                                textBox5.Text = "";
                                                                textBox6.Text = "";
                                                                textBox7.Text = "";
                                                                textBox1.GotFocus += new EventHandler((obj, ex) => { label8.Visible = false; });//当用户文本框成为焦点时 隐藏返回登录文本
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    label8.Text = "验证码错误 请重新输入！";
                                                    label8.Visible = true;//验证码错误时 显示错误文本
                                                    textBox7.Text = "";//清空文本框
                                                    //然后刷新验证码
                                                    code = GenerateCheckCode();//生成4位数字符串
                                                    Bitmap image = CreateCheckCodeImage(code, 64, 30);//生成图片
                                                    pictureBox11.Image = image;//给控件赋值
                                                    textBox7.GotFocus += new EventHandler((obj, ex) => { label8.Visible = false; });//成为焦点时把错误文本隐藏
                                                }
                                            }
                                            else
                                            {
                                                label8.Text = "请输入验证码！";
                                                label8.Visible = true;//验证码错误时 显示错误文本
                                                textBox7.Text = "";//清空文本框

                                                //然后刷新验证码
                                                code = GenerateCheckCode();//生成4位数字符串
                                                Bitmap image = CreateCheckCodeImage(code, 64, 30);//生成图片
                                                pictureBox11.Image = image;//给控件赋值
                                                textBox7.GotFocus += new EventHandler((obj, ex) => { label8.Visible = false; });//成为焦点时把错误文本隐藏
                                            }

                                        }
                                        else
                                        {
                                            label8.Text = "请输入正确的11位手机号!";
                                            label8.Visible = true;//显示提示输入文本

                                            textBox7.Text = "";//清空验证码框
                                                               //然后刷新验证码
                                            code = GenerateCheckCode();//生成4位数字符串
                                            Bitmap image = CreateCheckCodeImage(code, 64, 30);//生成图片
                                            pictureBox11.Image = image;//给控件赋值
                                        }
                                    }
                                    else
                                    {
                                        label8.Text = "请输入手机号!";
                                        label8.Visible = true;//显示提示输入文本
                                    }
                                }
                                else
                                {
                                    label8.Text = "请输入地址!";
                                    label8.Visible = true;//显示提示输入文本
                                }
                            }
                            else
                            {
                                label8.Text = "请输入姓名!";
                                label8.Visible = true;//显示提示输入文本
                            }
                        }
                        else
                        {
                            label8.Text = "密码不一致!";
                            label8.Visible = true;//显示提示输入文本
                        }
                    }
                    else
                    {
                        label8.Text = "请确认密码!";
                        label8.Visible = true;//显示提示输入文本
                    }
                }
                else
                {
                    label8.Text = "请输入密码!";
                    label8.Visible = true;//显示提示输入文本
                }
            }
            else
            {
                label8.Text = "请输入用户名!";
                label8.Visible = true;//显示提示输入文本
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        //验证码
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

            System.Random random = new Random();

            for (int i = 0; i < 4; i++)
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
        private Bitmap CreateCheckCodeImage(string checkCode, int w = 54, int h = 30)
        {
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(w, h);
            Graphics g = Graphics.FromImage(image);

            g.Clear(Color.WhiteSmoke);//清除背景色

            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };//定义随机颜色

            string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
            Random rand = new Random();
            int z = 0;//干扰线条数
            for (int i = 0; i < z; i++)
            {
                int x1 = rand.Next(image.Width);
                int x2 = rand.Next(image.Width);
                int y1 = rand.Next(image.Height);
                int y2 = rand.Next(image.Height);
                g.DrawLine(new Pen(Color.LightGray, 1), x1, y1, x2, y2);//根据坐标画线
            }

            for (int i = 0; i < checkCode.Length; i++)
            {
                int cindex = rand.Next(7);
                int findex = rand.Next(5);

                Font f = new System.Drawing.Font(font[findex], 14, System.Drawing.FontStyle.Bold);
                Brush b = new System.Drawing.SolidBrush(c[cindex]);
                int ii = 4;
                if ((i + 1) % 2 == 0)
                {
                    ii = 2;
                }
                g.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * (14)), ii);
            }
            image = TwistImage(image, true, 5, 1);
            g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);
            return image;
        }


        private const double PI = 3.1415926535897932384626433832795;
        private const double PI2 = 6.283185307179586476925286766559;

        /// <summary>
        /// 正弦曲线Wave扭曲图片（Edit By 51aspx.com）
        /// </summary>
        /// <param name="srcBmp">图片路径</param>
        /// <param name="bXDir">如果扭曲则选择为True</param>
        /// <param name="nMultValue">波形的幅度倍数，越大扭曲的程度越高，一般为3</param>
        /// <param name="dPhase">波形的起始相位，取值区间[0-2*PI)</param>
        /// <returns></returns>
        public System.Drawing.Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            System.Drawing.Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);

            // 将位图背景填充为白色
            System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();

            double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;

            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    double dx = 0;
                    dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);

                    // 取得当前点的颜色
                    int nOldX = 0, nOldY = 0;
                    nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    nOldY = bXDir ? j : j + (int)(dy * dMultValue);

                    System.Drawing.Color color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width
                     && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }

            return destBmp;
        }

        string code;



        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            code = GenerateCheckCode();//生成4位数字符串
            Bitmap image = CreateCheckCodeImage(code, 64, 30);//生成图片
            pictureBox11.Image = image;//给控件赋值
        }
    }
}

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
            //进到登录页面时初始化验证码
            code = GenerateCheckCode();//获取生成4位数的字符串
            Bitmap image = CreateCheckCodeImage(code, 64, 30);//生成图片
            pictureBox1.Image = image;//把生成的图片赋值给pri那个控件

        }


        /// <summary>
        /// 验证码实现
        /// </summary>
        /// <returns></returns>
        /// 得到验证码
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

        /// 生成验证码图片
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
        private void button1_Click_1(object sender, EventArgs e)
        {
            code = GenerateCheckCode();//获取生成4位数的字符串
            Bitmap image = CreateCheckCodeImage(code, 64, 30);//生成图片
            pictureBox1.Image = image;//把生成的图片赋值给pri那个控件

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))//IsNullOrEmpty方法判断是否为空   为空是true 否则为false
            {
                MessageBox.Show("请输入验证码");
                return;
            }
            if (textBox3.Text.Equals(code))//equals方法比较字符串  如果输入的验证码对的上 就给注册
            {
                MessageBox.Show("成功");
                return;
            }
            else
            {
                MessageBox.Show("验证码错误");
                return;
            }
        }
    }
}

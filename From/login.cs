using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using Kojiro_ordering_management_system.用户端;

namespace Kojiro_ordering_management_system
{
    public partial class Form1 : Form
    {
        public static Form1 form1 = new Form1();//公开实例化这个窗体对象给其他窗体调用
        public Form1()
        {
            InitializeComponent();
            form1 = this;//当前窗体对象赋值给上面的窗体对象
        }

        protected override CreateParams CreateParams  //防止界面闪烁
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;//超链接文本去除下划线
            linkLabel2.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel3.LinkBehavior = LinkBehavior.NeverUnderline;
            label1.Visible = false;//加载时隐藏提示文本
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Retrieve_pwd retrieve = new Retrieve_pwd();//实例化找回密码框
            retrieve.Show();//打开找回密码框
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 enroll = new Form2();
            enroll.Show();
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            Application.Exit();//关闭
        }
        private void butMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//最小化
        }

        
        private Point mPoint = new Point();
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;//获取坐标
            mPoint.Y = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//鼠标左键按住拖拽
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }

        //设置圆角
        private void Form1_Resize(object sender, EventArgs e)
        {
            SetWindowRegion();
        }

        public void SetWindowRegion()
        {
            GraphicsPath FormPath;
            FormPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 10);
            this.Region = new Region(FormPath);

        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // 左上角
            path.AddArc(arcRect, 180, 90);

            // 右上角
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // 右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // 左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();//闭合曲线
            return path;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //勿删
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            string Uid = textBox1.Text;
            string Pwd = textBox2.Text;

            if (Uid != "" && Pwd != "")
            {
                string identity="";
                string sql = string.Format("select * from Ustable where Uid = '{0}' and pwd = '{1}'", Uid, Pwd);//验证登录账号和密码是否一致
                SqlDataReader dr = DBHelper.GDR(sql);
                while (dr.Read())
                {
                  identity = dr["identity"].ToString().Trim();
                }
                if (dr.HasRows && identity != "管理员")
                {

                    User_side user_Side = new User_side();
                    label1.Visible = false;//成功后把错误提示文本隐藏
                    dr.Close();//查询之后关闭
                    dr.Dispose();//释放资源
                    Hide();//隐藏
                    user_Side.Show();//打开窗口
                }
                else
                {
                    label1.Text = "请输入正确的账号密码！";
                    label1.Visible = true;
                    textBox1.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
                    textBox2.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
                    dr.Close();//查询之后关闭
                    dr.Dispose();//释放资源
                }


            }
            else if (Uid != "")
            {
                label1.Text = "请输入密码！";
                label1.Visible = true;
            }
            else
            {
                label1.Text = "请输入用户名！";
                label1.Visible = true;
            }
           
           

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //复选框被勾选，明文显示
                textBox2.PasswordChar = new char();
               
            }
            else
            {
                //复选框被取消勾选，密文显示
                textBox2.PasswordChar = '*';
            
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            Hide();
        }
        
    }
}

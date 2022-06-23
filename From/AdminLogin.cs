using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system.用户端
{
    public partial class AdminLogin : Form
    {
        public static AdminLogin adminLogin = new AdminLogin();
        public string identity = "";//身份信息
        public AdminLogin()
        {
            InitializeComponent();
            adminLogin = this;
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



        private void AdminLogin_Load(object sender, EventArgs e)
        {
            linkLabel3.LinkBehavior = LinkBehavior.NeverUnderline;
            label1.Visible = false;//加载时隐藏提示文本
        }

        //设置圆角
        private void AdminLogin_Resize(object sender, EventArgs e)
        {
            SetWindowRegion();
        }

        private Point mPoint = new Point();
        private void AdminLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//鼠标左键按住拖拽
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }

        private void AdminLogin_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;//获取坐标
            mPoint.Y = e.Y;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Close();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            Application.Exit();//关闭
        }

        private void butMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//最小化
        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string Uid = textBox1.Text;
            string Pwd = textBox2.Text;

            if (Uid != "" && Pwd != "")
            {
                string sql = string.Format("select * from Ustable where Uid = '{0}' and pwd = '{1}'", Uid, Pwd);//验证登录账号和密码是否一致
                SqlDataReader dr = DBHelper.GDR(sql);
                while (dr.Read())
                {
                    identity = dr["identity"].ToString().Trim();
                }
                if (dr.HasRows && identity == "管理员")
                {

                    label1.Visible = false;//成功后把错误提示文本隐藏
                    dr.Close();//查询之后关闭
                    dr.Dispose();//释放资源
                    Hide();//隐藏
                    AdminUser_side adminUser_Side = new AdminUser_side();
                    adminUser_Side.Show();//打开管理员端
                }
                else
                {
                    label1.Text = "请输入正确的管理员账号密码！";
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
    }
}


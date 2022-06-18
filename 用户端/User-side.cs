using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{



    public partial class User_side : Form
    {
        public static User_side user_Side;//公开

        //在函数外，命名空间内声明页面的变量，这样子我们可以做到重新加载页面的时候不会出现初始值
        //而是在打开上次切换前的页面
        //public Ordering_food  ordering_Food = new Ordering_food();
        public Orders orders = new Orders();
        public My_information  my_Information = new My_information();
        public More more = new More();
        //public Main_interface main_interface = new Main_interface();

       
        //窗体边框阴影动画效果移动改变大小
        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        //声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        [DllImport("user32")]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        /*

         * 函数功能：该函数能在显示与隐藏窗口时能产生特殊的效果。有两种类型的动画效果：滚动动画和滑动动画。

         * 函数原型：BOOL AnimateWindow（HWND hWnd，DWORD dwTime，DWORD dwFlags）；

         * hWnd：指定产生动画的窗口的句柄。

         * dwTime：指明动画持续的时间（以微秒计），完成一个动画的标准时间为200微秒。

         * dwFags：指定动画类型。这个参数可以是一个或多个下列标志的组合。

         * 返回值：如果函数成功，返回值为非零；如果函数失败，返回值为零。

         * 在下列情况下函数将失败：窗口使用了窗口边界；窗口已经可见仍要显示窗口；窗口已经隐藏仍要隐藏窗口。若想获得更多错误信息，请调用GetLastError函数。

         * 备注：可以将AW_HOR_POSITIVE或AW_HOR_NEGTVE与AW_VER_POSITVE或AW_VER_NEGATIVE组合来激活一个窗口。

         * 可能需要在该窗口的窗口过程和它的子窗口的窗口过程中处理WM_PRINT或WM_PRINTCLIENT消息。对话框，控制，及共用控制已处理WM_PRINTCLIENT消息，缺省窗口过程也已处理WM_PRINT消息。


         */

        //标志描述：

        public const int AW_SLIDE = 0x40000;//使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略。

        public const int AW_ACTIVATE = 0x20000;//激活窗口。在使用了AW_HIDE标志后不要使用这个标志。

        public const int AW_BLEND = 0x80000;//使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。

        public const int AW_HIDE = 0x10000;//隐藏窗口，缺省则显示窗口。(关闭窗口用)

        public const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展。

        public const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。

        public const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。

        public const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。

        public const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        [DllImport("user32.dll")]

        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]

        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        //常量

        public const int WM_SYSCOMMAND = 0x0112;

        //窗体移动

        public const int SC_MOVE = 0xF010;

        public const int HTCAPTION = 0x0002;

        //改变窗体大小
        public const int WMSZ_LEFT = 0xF001;

        public const int WMSZ_RIGHT = 0xF002;

        public const int WMSZ_TOP = 0xF003;

        public const int WMSZ_TOPLEFT = 0xF004;

        public const int WMSZ_TOPRIGHT = 0xF005;

        public const int WMSZ_BOTTOM = 0xF006;

        public const int WMSZ_BOTTOMLEFT = 0xF007;

        public const int WMSZ_BOTTOMRIGHT = 0xF008;

        public User_side()
        {
            InitializeComponent();
            user_Side = this;// 当前窗体对象赋值给上面的窗体对象
            this.Text = "小次郎点餐系统客户端";
            ControlBox = false;
            this.DoubleBuffered = true;
        }

        protected override CreateParams CreateParams  //防止界面闪烁  同时也去除了动画
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }

        public void loadform(object page)
        {
            //对panel里面的容器进行一个判定：如果容器里的空间数量大于0那么就清空容器里面的空间
            //为其腾出空间
            if (this.mainpanel.Controls.Count > 0)
            {
                this.mainpanel.Controls.Clear();
            }
            //判断传输进来的page类型是否是Form或其子类
            if (page is Form form)
            {
                //对画面的参数设置
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                //将容器的控件进行一个添加
                this.mainpanel.Controls.Add(form);
                //把容器的tag设置成我们传输进来的page
                this.mainpanel.Tag = form;
                form.Show();
            }
        }

       
      

        private void butClose_Click(object sender, EventArgs e)
        {
           System.Environment.Exit(0);//完全退出

            /* if (Form1.form1.WindowState == FormWindowState.Normal)//因为登录时隐藏了主窗口  所以在本程序关闭前判断一下主窗口是否时默认状态 如果是就关掉 以防有后台下次打不开
             {
                 Form1.form1.Close();
             }

             Close();*/
             //Application.Exit();
        }

        private void butMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//最小化
        }

        /*private void User_side_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //窗体关闭动画效果
            AnimateWindow(this.Handle, 400, AW_HIDE | AW_BLEND | AW_CENTER);
        }*/

        private void User_side_Load_1(object sender, EventArgs e)
        {
            Main_interface main_interface = new Main_interface();
            loadform(main_interface);//加载时显示主页面
            //窗体加载动画效果
            //AnimateWindow(this.Handle, 300, AW_BLEND | AW_CENTER);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Main_interface main_interface = new Main_interface();
            loadform(main_interface);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ordering_food ordering_Food = new Ordering_food();
            loadform(ordering_Food);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Orders orders = new Orders();
            loadform(orders);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            My_information my_information = new My_information();
            loadform(my_Information);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadform(more);
        }

        /// <summary>
        /// 获取游标位置并改变形状
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void User_side_MouseMove_1(object sender, MouseEventArgs e)
        {
            Point p = this.PointToClient(MousePosition);
            int xx = Width;
            int yy = Height;
            //TopLeft
            if (p.X <= 2 && p.Y <= 2)
            {
                this.Cursor = Cursors.SizeNWSE;
                wParam = (new IntPtr(WMSZ_TOPLEFT)).ToInt32();
            }
            //TopRight
            else if (p.X >= Width - 2 && p.Y <= 2)
            {
                this.Cursor = Cursors.SizeNESW;
                wParam = (new IntPtr(WMSZ_TOPRIGHT)).ToInt32();
            }
            //BottomLeft
            else if (p.X <= 2 && p.Y >= Height - 2)
            {
                this.Cursor = Cursors.SizeNESW;
                wParam = (new IntPtr(WMSZ_BOTTOMLEFT)).ToInt32();
            }
            //BottomRight
            else if (p.X >= Width - 2 && p.Y >= Height - 2)
            {
                this.Cursor = Cursors.SizeNWSE;
                wParam = (new IntPtr(WMSZ_BOTTOMRIGHT)).ToInt32();
            }
            //Left
            else if (p.Y > 2 && p.Y < Height - 2 && p.X < 2)
            {
                this.Cursor = Cursors.SizeWE;
                wParam = (new IntPtr(WMSZ_LEFT)).ToInt32();
            }
            //Up
            else if (p.X > 2 && p.X < Width - 2 && p.Y < 2)
            {
                this.Cursor = Cursors.SizeNS;
                wParam = (new IntPtr(WMSZ_TOP)).ToInt32();
            }
            //Bottom
            else if (p.X > 2 && p.X < Width - 2 && p.Y > Height - 2)
            {
                this.Cursor = Cursors.SizeNS;
                wParam = (new IntPtr(WMSZ_BOTTOM)).ToInt32();
            }
            //Right
            else if (p.Y > 2 && p.Y < Height - 2 && p.X > Width - 2)
            {
                this.Cursor = Cursors.SizeWE;
                wParam = (new IntPtr(WMSZ_RIGHT)).ToInt32();
            }
            else
                this.Cursor = Cursors.Default;
        }
        private int wParam = 0;
        private void User_side_MouseDown_1(object sender, MouseEventArgs e)
        {
            Point p = this.PointToClient(MousePosition);
            //Move
            if (p.X > 2 && p.X < Width - 2 && p.Y > 2 && p.Y < Height - 2)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
            else // ChangeSize
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, wParam, IntPtr.Zero.ToInt32());
            }
        }

   
    }
}

﻿using System;
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

        //窗体边框阴影动画效果移动改变大小
        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        //声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

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

         * 速查：WIDdOWS NT：5.0以上版本：Windows：98以上版本；Windows CE：不支持；头文件：Winuser.h；库文件：user32.lib。

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
        //需添加using System.Runtime.InteropServices
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
            this.Text = "客户端";
            ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;//限制最大化的大小
        }



        private void User_side_Load(object sender, EventArgs e)
        {
            //窗体加载动画效果
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_CENTER);
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

        private void User_side_FormClosing(object sender, FormClosingEventArgs e)
        {
            //窗体关闭动画效果
            AnimateWindow(this.Handle, 500, AW_HIDE | AW_BLEND | AW_CENTER);
        }

        private void User_side_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }


        private void butClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//最小化
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)//如果现在的窗口是默认大小
            {
                WindowState = FormWindowState.Maximized;//那就设置成最大化
            }
            else
            {
                WindowState = FormWindowState.Normal;//否则就默认显示
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

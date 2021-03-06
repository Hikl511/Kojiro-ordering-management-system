using Kojiro_ordering_management_system.用户端;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{
    public partial class My_information : Form
    {
        string photoname ="";
        string UserName = "";
        string Uid = Form1.form1.textBox1.Text;
        string Pwd = Form1.form1.textBox2.Text;
        string AdUid = AdminLogin.adminLogin.textBox1.Text;//管理员
        string AdPwd = AdminLogin.adminLogin.textBox1.Text;
     //   public static My_information my_Information = new My_information();//实例化当前窗体 把值传进来 防止再打开的时候是空间原始值
        public My_information()
        {
            InitializeComponent();
        }

        private void My_information_Load(object sender, EventArgs e)
        {
            // Ordering_food.ordering_Food.a = "";
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                PicShow();//从数据库中查找图片路径并给控件赋值
                UsName();
                button5.Text = "退出程序";
                button2.Visible = false;//如果是管理员 就隐藏掉一些管理员不必要的控件
                button4.Visible = false;
                button1.Location = new Point(344, 214);//并调整其他两个按钮的定位
                button3.Location = new Point(144, 214);
            }
            else
            {
                try
                {
                    PicShow();//从数据库中查找图片路径并给控件赋值
                    UsName();

                }
                catch (Exception)
                {

                    //	throw;
                }
            }

          

        }

        public void UsName()//显示用户名
        {
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                string cmdText = string.Format("select [identity] from Ustable where Uid='{0}' and Pwd='{1}'", AdUid, AdPwd);
                SqlDataReader dr = DBHelper.GDR(cmdText);
                while (dr.Read())
                {
                    label1.Text = dr["identity"].ToString();
                }
                dr.Close();
                
            } 
            else
            {
                string cmdText = string.Format("select Name from Ustable where Uid='{0}' and Pwd='{1}'", Uid, Pwd);
                SqlDataReader dr = DBHelper.GDR(cmdText);
                while (dr.Read())
                {
                    label1.Text = dr["Name"].ToString();
                }
                dr.Close();
              //  label1.Text = UserName;
            }
        }
        public void PicShow()//显示头像
        {

            if (AdminLogin.adminLogin.identity == "管理员")
            {
                photoname = "";//清空图片路径
                string cmdText = string.Format("select UserImag from Ustable where Uid='{0}' and Pwd='{1}'", AdUid, AdPwd);
                SqlDataReader dr2 = DBHelper.GDR(cmdText);
                while (dr2.Read())
                {
                    photoname = dr2["UserImag"].ToString().Trim();
                }

                dr2.Close();
                if (photoname != "")
                {
                    pictureBox1.Image = Image.FromFile(photoname);
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(@"D:\XiaoCiLang\Resources\用户.png");
                }
            }
            else//用户
            {
                photoname = "";//清空图片路径
                string cmdText = string.Format("select UserImag from Ustable where Uid='{0}' and Pwd='{1}'", Uid, Pwd);
                SqlDataReader dr2 = DBHelper.GDR(cmdText);
                while (dr2.Read())
                {
                    photoname = dr2["UserImag"].ToString().Trim();
                }
                dr2.Close();
                if (photoname != "")
                {
                    pictureBox1.Image = Image.FromFile(photoname);
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(@"D:\XiaoCiLang\Resources\用户.png");
                }
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Modify_data modify_Data = new Modify_data();
            User_side.user_Side.loadform(modify_Data);//打开界面

            /* OpenFileDialog openFileDialog1 = new OpenFileDialog();
             if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了图片
             {
                 photoname = openFileDialog1.FileName;
                 //文件路径
                 //MessageBox.Show(photoname);
                 // pictureBox1.Image = Image.FromFile(photoname);

                 string strconn = "server=.;database=Kojiror;uid=sa;pwd=1234";
                 SqlConnection conn = new SqlConnection(strconn);
                 string sql = string.Format("update Ustable set UserImag ='" + photoname + "'where Uid='{0}' and Pwd='{1}'", Uid, Pwd);
                 try
                 {
                     conn.Open();
                     if (DBHelper.ENQ(sql))
                     {

                         MessageBox.Show("成功！");
                     }
                 }
                 catch (Exception)
                 {

                 }
                 conn.Close();
                 pictureBox1.Image = Image.FromFile(photoname);
             }*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (AdminLogin.adminLogin.identity == "管理员")
            {

                System.Environment.Exit(0);//完全退出 退出所有进程
            }
            else
            {
                User_side.user_Side.Hide();//隐藏父窗体
                Form1.form1.Show();//打开登录页

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Shipping_address shipping_Address = new Shipping_address();
            User_side.user_Side.loadform(shipping_Address);
            //shipping_Address.Show();
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                Ordering_food ordering_Food = new Ordering_food();
                AdminUser_side.adminUser_Side.AdminLoadform(ordering_Food);
            }
            else
            {
                Main_interface main_Interface = new Main_interface();
                User_side.user_Side.loadform(main_Interface);//回主界面
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AdminLogin.adminLogin.identity == "管理员")//订单管理
            {
                Orders_Main orders_Main = new Orders_Main();
                AdminUser_side.adminUser_Side.AdminLoadform(orders_Main);
            }
            else
            {
                Orders_Main orders_Main = new Orders_Main();
                User_side.user_Side.loadform(orders_Main);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                Change_Password change_Password = new Change_Password();
                AdminUser_side.adminUser_Side.AdminLoadform(change_Password);
            }
            else
            {
                Change_Password change_Password = new Change_Password();
                User_side.user_Side.loadform(change_Password);

            }
        }
    }
}



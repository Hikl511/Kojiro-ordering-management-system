using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{
    public partial class My_information : Form
    {
        string photoname = "";
        string Uid = Form1.form1.textBox1.Text;
        string Pwd = Form1.form1.textBox2.Text;
        public static My_information my_Information = new My_information();//实例化当前窗体 把值传进来 防止再打开的时候是空间原始值
        public My_information()
        {
            InitializeComponent();
            my_Information = this;
        }

        private void My_information_Load(object sender, EventArgs e)
        {
           // Ordering_food.ordering_Food.a = "";
            PicShow();//从数据库中查找图片路径并给控件赋值
            UsName();
        }

        public void UsName()//显示用户名
        {
            string strconn = "server=.;database=Kojiror;uid=sa;pwd=1234";
            SqlConnection conn = new SqlConnection(strconn);
            string cmdText = string.Format("select * from Ustable where Uid='{0}' and Pwd='{1}'", Uid, Pwd);
            SqlDataReader dr = DBHelper.GDR(cmdText);
            while (dr.Read())
            {
                label1.Text = dr["Name"].ToString();
            }
            dr.Close();
            DBHelper.conn.Close();
        }
        public void PicShow()//显示头像
        {
            string strconn = "server=.;database=Kojiror;uid=sa;pwd=1234";
            SqlConnection conn = new SqlConnection(strconn);
            string cmdText = string.Format("select UserImag from Ustable where Uid='{0}' and Pwd='{1}'", Uid, Pwd);
            SqlDataReader dr = DBHelper.GDR(cmdText);
            while (dr.Read())
            {
                if (dr["UserImag"].ToString() != "")
                {
                    label2.Text = dr["UserImag"].ToString();
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmdText, conn);
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds);
                        photoname = ds.Tables[0].Rows[0][0].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                    pictureBox1.Image = Image.FromFile(photoname);
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(@"D:\XiaoCiLang\Resources\用户.png");
                }
            }
            DBHelper.conn.Close();
            conn.Close();

        }
        private void button4_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
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

                        MessageBox.Show("cg");
                    }
                }
                catch (Exception ex)
                {

                }
                conn.Close();
                pictureBox1.Image = Image.FromFile(photoname);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User_side.user_Side.Close();//关闭父窗体
            Form1.form1.Show();//打开登录页
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
            Main_interface main_Interface = new Main_interface();
            User_side.user_Side.loadform(main_Interface);//回主界面
        }
    }
}



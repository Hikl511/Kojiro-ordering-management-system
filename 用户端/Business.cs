using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{
    public partial class Business : Form
    {
       // Ordering_food ordering_Food = new Ordering_food();
        string name = Ordering_food.ordering_Food.a.ToString();
        public Business()
        {
          //  business = this;
            InitializeComponent();
        }

        private void Business_Load(object sender, EventArgs e)
        {
            label1.Text = name;
            PicShow();
            PicLableButtonShow();
            //PicShow();
        }
      
        
        //190, 41
        public void PicShow()//商家头像名字和介绍
        {
            string[] imag = new string[1];
            string[] lbltxt = new string[1];
            PictureBox[] pb = new PictureBox[1];
            Label[] lbl = new Label[1];
            string cmdText = string.Format("select introduce,Logo from Business where Name='{0}'", name);
            SqlDataReader dr = DBHelper.GDR(cmdText);
            int i = 0;
            while (dr.Read())
            {
                imag[i] = dr["Logo"].ToString();
                lbltxt[i] = dr["introduce"].ToString();
            }
            dr.Close();
            for (i = 0; i < 1; i++)
            {
                pb[i] = new PictureBox();
                lbl[i] = new Label();
                pb[i].Name = "b" + i;
                System.Drawing.Point p = new Point(70, 13 + i * 130);
                pb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pb[i].Location = p;
                pb[i].Size = new Size(110, 110);
                pb[i].BorderStyle = BorderStyle.None;
                panel1.Controls.Add(pb[i]);
                Image img = Image.FromFile(imag[i]);
                pb[i].Image = img;
                lbl[i].Name = lbltxt[i];
                System.Drawing.Point p2 = new Point(190, 41);//x宽 y高
                lbl[i].Location = p2;
                lbl[i].Size = new Size(250, 20);
                lbl[i].BorderStyle = BorderStyle.None;
                lbl[i].Font = new Font("微软雅黑", 11);
                lbl[i].Text = lbltxt[i];
                lbl[i].AutoEllipsis = true;//对超出lable宽度的文字自动处理
                panel1.Controls.Add(pb[i]);
                panel1.Controls.Add(lbl[i]);
                // pb[i].Click += new System.EventHandler(btn_click);
            }

        }

        public void PicLableButtonShow()
        {//对pic1操作
            try
            {
                string sql = "select Count(ClassID) from Dishes";//查询行数 
                int result = (int)DBHelper.ES(sql);
                string[] imag = new string[result];//图片路径
                string[] lbltxt = new string[result];//菜品名字
                string[] money = new string[result];//菜品价格
                PictureBox[] pb = new PictureBox[result];
                Label[] lbl = new Label[result];
                Label[] lbl2 = new Label[result];
                Button[] btu1 = new Button[result];
                string cmdText = string.Format("select image,Name,dumoney from Dishes where ClassID=(select id from Business Where Name='{0}')", name);
                // string cmdText = string.Format("select Logo,Name,ID from Business");
                SqlDataReader dr = DBHelper.GDR(cmdText);
                int i = 0;
                int x = 0;
                int y = 0;
                while (dr.Read())
                {

                    imag[i] = dr["image"].ToString();
                    lbltxt[i] = dr["Name"].ToString();
                    money[i] = dr["dumoney"].ToString();
                    i++;
                }
                dr.Close();

                for (i = 0; i < result; i++)
                {
                    pb[i] = new PictureBox();
                    lbl[i] = new Label();
                    btu1[i] = new Button();
                    lbl2[i] = new Label();
                    btu1[i].Name = "Button" + i + 1;
                    pb[i].Name = lbltxt[i];
                    System.Drawing.Point p = new Point(80 * x, 15 + y);
                    pb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    pb[i].Location = p;
                    pb[i].Size = new Size(90, 90);
                    pb[i].BorderStyle = BorderStyle.None;
                    Image img = Image.FromFile(imag[i]);
                    pb[i].Image = img;
                    lbl[i].Name = lbltxt[i];
                    System.Drawing.Point p2 = new Point(80 * x, 110 + y);//x宽 y高
                    lbl[i].Location = p2;
                    lbl[i].Size = new Size(100, 20);
                    lbl[i].BorderStyle = BorderStyle.None;
                    lbl[i].Font = new Font("微软雅黑", 9);
                    lbl[i].Text = lbltxt[i];
                    lbl[i].AutoEllipsis = true;//对超出lable宽度的文字自动处理//  事件 pb[i].Click += new System.EventHandler(btn_click);
                    lbl2[i].Name = "label" + i;
                    System.Drawing.Point p3 = new Point(80 * x, 130 + y);//x宽 y高
                    lbl2[i].Location = p3;
                    lbl2[i].Size = new Size(100, 20);
                    lbl2[i].BorderStyle = BorderStyle.None;
                    lbl2[i].Font = new Font("微软雅黑", 7);
                    lbl2[i].Text = "￥" + money[i].Substring(0, 4);//截取价格字符串 为4为 保留一个小数点
                                                                  // lbl2[i].Text = money[i];
                    lbl2[i].ForeColor = Color.Red;
                    btu1[i].Size = new Size(80, 20);
                    btu1[i].FlatAppearance.BorderSize = 0;//无边框
                    btu1[i].Text = "加入购物车";
                    btu1[i].Font = new Font("宋体", 9);
                    btu1[i].FlatStyle = FlatStyle.Flat;
                    System.Drawing.Point p4 = new Point(80 * x, 150 + y);//x宽 y高
                    btu1[i].Location = p4;
                    panel2.Controls.Add(pb[i]);
                    panel2.Controls.Add(lbl[i]);
                    panel2.Controls.Add(lbl2[i]);
                    panel2.Controls.Add(btu1[i]);
                    x++;
                    if (x++ >= 4)
                    {
                        x = 0;
                        y += 180;
                    }
                    //dr.Close();
                }
            }
            catch (Exception e)//捕获一异常然后抛出
            {

               // throw e;
            }
            finally
            {

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ordering_food ordering_Food = new Ordering_food();
            User_side.user_Side.loadform(ordering_Food);
            Close();
        }
    }
}

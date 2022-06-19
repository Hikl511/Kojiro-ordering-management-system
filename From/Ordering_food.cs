using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{

    public partial class Ordering_food : Form
    {
        public static Ordering_food ordering_Food = new Ordering_food();
        public string name ="";
        public Ordering_food()
        {
            ordering_Food = this;
            InitializeComponent();
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
        private void Ordering_food_Load(object sender, EventArgs e)
        {
            DelShoppingCart();//清空购物车
            PicLableShow();
        }



        public void DelShoppingCart()//加载商家界面时清空购物车
        {
            try
            {
                string DeleteSql = string.Format("delete from ShoppingCart");
                DBHelper.ENQ(DeleteSql);
            }
            catch (Exception)
            {

              //  throw;
            }
        }
        public void PicLableShow()
        {//对pic1操作
            try
            {
                string sqlcount = "select Count(Logo) from Business";//查询行数 
                int result = (int)DBHelper.ES(sqlcount);
                string[] imag = new string[result];
                PictureBox[] pb = new PictureBox[result];
                Label[] lbl = new Label[result];
                string[] lbltxt = new string[result];
                string cmdText = string.Format("select Logo,Name from Business");
                SqlDataReader dr = DBHelper.GDR(cmdText);
                int i = 0;
                int x = 0;
                int y = 0;
                while (dr.Read())
                {

                    imag[i] = dr["Logo"].ToString();
                    lbltxt[i] = dr["Name"].ToString();
                    i++;
                }
                dr.Close();
                for (i = 0; i < result; i++)
                {
                    pb[i] = new PictureBox();
                    pb[i].Name = lbltxt[i];
                    System.Drawing.Point p = new Point(120 * x, 15 + y);
                    pb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    pb[i].Location = p;
                    pb[i].Size = new Size(110, 110);
                    pb[i].BorderStyle = BorderStyle.None;
                    Image img = Image.FromFile(imag[i]);
                    pb[i].Image = img;
                    lbl[i] = new Label();
                    lbl[i].Name = lbltxt[i];
                    System.Drawing.Point p2 = new Point(120 * x, 140 + y);//x宽 y高
                    lbl[i].Location = p2;
                    lbl[i].Size = new Size(100, 20);
                    lbl[i].BorderStyle = BorderStyle.None;
                    lbl[i].Font = new Font("微软雅黑", 11);
                    lbl[i].Text = lbltxt[i];
                    lbl[i].AutoEllipsis = true;//对超出lable宽度的文字自动处理
                    pb[i].Click += new System.EventHandler(btn_click);
                    lbl[i].Click += new System.EventHandler(btn_click2);
                    panel1.Controls.Add(pb[i]);
                    panel1.Controls.Add(lbl[i]);
                    x++;
                    if (x++ >= 4)
                    {
                        x = 0;
                        y += 180;
                    }
                }
            }
            catch (Exception)
            {

               // throw;
            }
        }
        public void btn_click(object sender, System.EventArgs e)
        { 
                PictureBox b = (PictureBox)sender;
                name = b.Name.ToString();
                Business business = new Business();
                User_side.user_Side.loadform(business);//点控件 打开商家详情页
        }
           
        public void btn_click2(object sender, System.EventArgs e)
        {
                Label lbl = (Label)sender;
                name = lbl.Text;
                Business business = new Business();
                User_side.user_Side.loadform(business);
            
        }
    }
}


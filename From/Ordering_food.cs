using Kojiro_ordering_management_system.用户端;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{

    public partial class Ordering_food : Form
    {
        public static Ordering_food ordering_Food = new Ordering_food();
        public string name = "";
        public int ClassID;
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
            if (AdminLogin.adminLogin.identity == "管理员")//如果当前用户时管理员 就显示添加商家按钮
            {
                button5.Visible = true;
            }
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
                string[] imag = new string[result];//商家logo
                PictureBox[] pb = new PictureBox[result];
                Label[] lbl = new Label[result];
                Button[] btn = new Button[result];

                string[] lbltxt = new string[result];//商家名字
                string[] ID = new string[result];//商家ID
                string cmdText = string.Format("select ID,Logo,Name from Business");
                SqlDataReader dr = DBHelper.GDR(cmdText);
                int i = 0;
                int x = 0;
                int y = 0;
                while (dr.Read())
                {
                    ID[i] = dr["ID"].ToString();
                    imag[i] = dr["Logo"].ToString();
                    lbltxt[i] = dr["Name"].ToString();
                    i++;
                }
                dr.Close();
                for (i = 0; i < result; i++)
                {
                    pb[i] = new PictureBox();
                    lbl[i] = new Label();
                    btn[i] = new Button();
                    pb[i].Name = lbltxt[i];
                    pb[i].Tag = ID[i];
                    System.Drawing.Point p = new Point(120 * x, 15 + y);
                    pb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    pb[i].Location = p;
                    pb[i].Size = new Size(110, 110);
                    pb[i].BorderStyle = BorderStyle.None;
                    Image img = Image.FromFile(imag[i]);
                    pb[i].Image = img;
                    lbl[i].Name = lbltxt[i];
                    System.Drawing.Point p2 = new Point(120 * x, 140 + y);//x宽 y高
                    lbl[i].Location = p2;
                    lbl[i].Size = new Size(100, 20);
                    lbl[i].BorderStyle = BorderStyle.None;
                    lbl[i].Font = new Font("微软雅黑", 11);
                    lbl[i].Text = lbltxt[i];
                    lbl[i].Tag = ID[i];
                    lbl[i].AutoEllipsis = true;//对超出lable宽度的文字自动处理
                    pb[i].Click += new System.EventHandler(btn_click);
                    lbl[i].Click += new System.EventHandler(btn_click2);
                    if (AdminLogin.adminLogin.identity == "管理员")
                    {
                        btn[i].Size = new Size(80, 20);
                        btn[i].FlatAppearance.BorderSize = 0;//无边框 btu1[i].FlatStyle = FlatStyle.Flat;
                        btn[i].Name = lbltxt[i];//商家名字给按钮赋值
                        btn[i].Tag = ID[i];//商家ID给Tag赋值
                        btn[i].Text = "删除";
                        btn[i].Font = new Font("宋体", 9);
                        btn[i].FlatStyle = FlatStyle.Flat;
                        //btn[i].ForeColor = Color.White;//字体白色
                        // btn[i].BackColor = Color.SkyBlue;//背景蓝色
                        System.Drawing.Point p5 = new Point(120 * x, 170 + y);//x宽 y高
                        btn[i].Location = p5;
                        btn[i].Click += new System.EventHandler(del_click);
                        panel1.Controls.Add(btn[i]);
                    }

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
            ClassID = int.Parse(b.Tag.ToString());
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                Business business = new Business();
                AdminUser_side.adminUser_Side.AdminLoadform(business);


            }
            else
            {
                Business business = new Business();
                User_side.user_Side.loadform(business);//点控件 打开商家详情页
            }

        }

        public void btn_click2(object sender, System.EventArgs e)//打开点餐窗口事件
        {
            Label lbl = (Label)sender;
            name = lbl.Text;
            ClassID = int.Parse(lbl.Tag.ToString());
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                Business business = new Business();
                AdminUser_side.adminUser_Side.AdminLoadform(business);

            }
            else
            {
                Business business = new Business();
                User_side.user_Side.loadform(business);//点控件 打开商家详情页
            }
        }

        /// <summary>
        /// 管理员删除商家事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void del_click(object sender, System.EventArgs e)
        {
            Button b = (Button)sender;
            //DelOrderNumber = b.Name.ToString(); //单击时把当前单机按钮的值传给变量 给删除语句窗口调用
            DialogResult result = MessageBox.Show("确认删除此商家?" + "\n" + "该操作将会删除商家及所有菜品" + "\n" + "商家删除后将无法恢复", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                string DeleteBusiness = string.Format("delete from Business where Name='{0}'", b.Name.ToString());//删除商家
                string DeleteDishes = string.Format("delete from Dishes where ClassID='{0}'", b.Tag.ToString());//删除对应菜品
                if (DBHelper.ENQ(DeleteBusiness) && DBHelper.ENQ(DeleteDishes))
                {
                    Ordering_food ordering_Food = new Ordering_food();
                    AdminUser_side.adminUser_Side.AdminLoadform(ordering_Food);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddBusiness addBusiness = new AddBusiness();
            AdminUser_side.adminUser_Side.AdminLoadform(addBusiness);
        }
    }
}



using Kojiro_ordering_management_system.用户端;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{
    public partial class Business : Form
    {
        // Ordering_food ordering_Food = new Ordering_food();
        public static Business business = new Business();
        string name = Ordering_food.ordering_Food.name.ToString();
        public string OrderCmpName = Order_Completed.order_Completed.OrderCmpName;//获取从已完成界面传回来的商家名字
        public string OrderAllName = Orders_All.orders.OrderAllName;//获取从全部订单传回来的商家名字
        public string OrderMainName = Orders_Main.orders_Main.OrderMainName;//获取从订单主界面传回来的商家名字
        public string DishesName;//菜品名字
        public string OrderNumber;//订单编号
        public string Uid = Form1.form1.textBox1.Text;
        public string Pwd = Form1.form1.textBox2.Text;
        int i = 1;
        public Business()
        {
            business = this;
            InitializeComponent();
        }

        private void Business_Load(object sender, EventArgs e)
        {
            try
            {
                label1.Text = name;
                PicShow();
                PicLableButtonShow();
                LabelText();
                i = 1;//重新进入窗体时把i赋值为1  生成1次订单号
                      //PicShow();
                if (AdminLogin.adminLogin.identity == "管理员")
                {
                    pictureBox1.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                }
            }
            catch (Exception)
            {

                //throw;
            }

        }


        //190, 41
        public void LabelText()
        {
            try
            {
                string ShopCount = string.Format("select  sum(quantity) from ShoppingCart");//查个数
                label4.Text = DBHelper.ES(ShopCount).ToString();
            }
            catch (Exception)
            {

                //  throw;
            }
        }
        public void PicShow()//商家头像名字和介绍
        {
            string[] imag = new string[1];
            string[] lbltxt = new string[1];
            PictureBox[] pb = new PictureBox[1];
            Label[] lbl = new Label[1];
            string cmdText;
            if (OrderCmpName != "")//当名字不为空 就代表在已完成界面点击了再次购买按钮 就跳转到点单界面
            {
                cmdText = string.Format("select introduce,Logo from Business where Name='{0}'", OrderCmpName);
            }
            else if (OrderAllName != "")
            {
                cmdText = string.Format("select introduce,Logo from Business where Name='{0}'", OrderAllName);
            }
            else if (OrderMainName != "")
            {
                cmdText = string.Format("select introduce,Logo from Business where Name='{0}'", OrderMainName);
            }
            else
            {
                cmdText = string.Format("select introduce,Logo from Business where Name='{0}'", name);
            }
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

        /// <summary>
        /// 加载菜品方法
        /// </summary>
        public void PicLableButtonShow()
        {
            try
            {
                string sqlcount = "select Count(ClassID) from Dishes";//查询行数 
                int result = (int)DBHelper.ES(sqlcount);
                string[] imag = new string[result];//图片路径
                string[] lbltxt = new string[result];//菜品名字
                string[] money = new string[result];//菜品价格
                int[] Id=new int[result];
                PictureBox[] pb = new PictureBox[result];//图片数组
                Label[] lbl = new Label[result];
                Label[] lbl2 = new Label[result];
                Button[] btu1 = new Button[result];
                Button[] btn = new Button[result]; 
                string cmdText;
                if (OrderCmpName != "")
                {
                    cmdText = string.Format("select image,Name,dumoney,DishesID from Dishes where ClassID=(select id from Business Where Name='{0}')", OrderCmpName);
                }
                else if (OrderAllName != "")
                {
                    cmdText = string.Format("select image,Name,dumoney,DishesID from Dishes where ClassID=(select id from Business Where Name='{0}')", OrderAllName);
                }
                else if (OrderMainName != "")
                {
                    cmdText = string.Format("select image,Name,dumoney,DishesID from Dishes where ClassID=(select id from Business Where Name='{0}')", OrderMainName);
                }
                else
                {
                    cmdText = string.Format("select image,Name,dumoney,DishesID from Dishes where ClassID=(select id from Business Where Name='{0}')", name);

                }
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
                    Id[i] = int.Parse(dr["DishesID"].ToString());
                    i++;
                }
                for (i = 0; i < result; i++)
                {
                    pb[i] = new PictureBox();
                    lbl[i] = new Label();
                    btu1[i] = new Button();
                    lbl2[i] = new Label();
                    btn[i] = new Button();

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
                    lbl2[i].Text = "￥" + money[i].Substring(0, 4);//截取价格字符串 为4为 保留一个小数点                                               // lbl2[i].Text = money[i];
                    lbl2[i].ForeColor = Color.Red;

                    if (AdminLogin.adminLogin.identity == "管理员")
                    {
                        btu1[i].Text = "管理";
                        btu1[i].Click += new System.EventHandler(set_click);

                        btn[i].Size = new Size(80, 20);
                        btn[i].FlatAppearance.BorderSize = 0;//无边框 btu1[i].FlatStyle = FlatStyle.Flat;
                        btn[i].Name = lbltxt[i];//菜品名字给按钮赋值
                        btn[i].Tag = Id[i];//商家ID给Tag赋值      
                        btn[i].Text = "删除";
                        btn[i].Font = new Font("宋体", 9);
                        btn[i].FlatStyle = FlatStyle.Flat;
                        //btn[i].ForeColor = Color.White;//字体白色
                        // btn[i].BackColor = Color.SkyBlue;//背景蓝色
                        System.Drawing.Point p5 = new Point(80 * x, 170 + y);//x宽 y高
                        btn[i].Location = p5;
                        btn[i].Click += new System.EventHandler(del_click);
                        panel2.Controls.Add(btn[i]);
                    }
                    else
                    {
                        btu1[i].Text = "加入购物车";
                        btu1[i].Click += new System.EventHandler(btn_click);
                    }
                    btu1[i].Size = new Size(80, 20);
                    btu1[i].FlatAppearance.BorderSize = 0;//无边框 btu1[i].FlatStyle = FlatStyle.Flat;

                    btu1[i].Name = lbltxt[i];

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
                    dr.Close();
                }
            }
            catch (Exception)
            {

                //  throw;//抛出异常
            }
            finally
            {

            }
        }

        private void del_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            label1.Text = b.Tag.ToString();
            //DelOrderNumber = b.Name.ToString(); //单击时把当前单机按钮的值传给变量 给删除语句窗口调用
            DialogResult result = MessageBox.Show("确认删除此菜品?" + "\n" + "该操作将会删除此菜品" + "\n" + "菜品删除后将无法恢复", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
               // string DeleteBusiness = string.Format("delete from Business where Name='{0}'", b.Name.ToString());//删除商家
                string DeleteDishes = string.Format("delete from Dishes where DishesID='{0}' and Name = '{1}'", b.Tag.ToString(),b.Name.ToString());//删除对应菜品
                if ( DBHelper.ENQ(DeleteDishes))
                {
                    Business business = new Business();
                    AdminUser_side.adminUser_Side.AdminLoadform(business);//商家界面
                }
            }
        }

        public object Price;
        /// <summary>
        /// 添加购物车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_click(object sender, System.EventArgs e)
        {
            Button b = (Button)sender;
            DishesName = b.Name.ToString(); //单击时把当前单机按钮的值传给变量 给购物车窗口调用
            //添加到购物车表
            string sql = string.Format("select * from Dishes where Name='{0}'", b.Name.ToString());
            SqlDataReader dr = DBHelper.GDR(sql);
            string money = "";
            string Name = "";
            string image = "";
            while (dr.Read())
            {
                money = dr["dumoney"].ToString();//查单价
                Name = dr["Name"].ToString();//查单价
                image = dr["image"].ToString();//查单价  
            }
            dr.Close();//关闭DateReader对象
            string Yesno = string.Format("select * from ShoppingCart where Name='{0}'", b.Name.ToString());//查总价
            SqlCommand sqlCommand = new SqlCommand(Yesno, DBHelper.conn);
            SqlDataAdapter dr2 = new SqlDataAdapter(sqlCommand);
            DataTable dat = new DataTable();
            dr2.Fill(dat);
            if (dat.Rows.Count == 0)
            {
                if (i > 0)
                {
                    OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmss") + "0000" + (new Random()).Next(1, 10000).ToString().Trim(); ;//订单编号 当前时间+随机数生成
                    i--;//只生成一次编号
                }
                string setShopCart = string.Format("insert ShoppingCart values('{0}','{1}','{2}','{3}')", money, Name, image, 0);//加入购物车表
                DBHelper.ENQ(setShopCart);

            }
            dr2.Dispose();
            string OrdersCount = string.Format("select count(Name) from ShoppingCart where Name='{0}'", b.Name.ToString());//查菜品数量
            string orCount = DBHelper.ES(OrdersCount).ToString();
            //加入订单对应菜品表
            string TemporaryMenu = string.Format("insert TemporaryMenu values('{0}','{1}','{2}','{3}','{4}')", money, Name, image, orCount, OrderNumber);
            DBHelper.ENQ(TemporaryMenu);
            string update = string.Format("update ShoppingCart set quantity+=1 where Name='{0}'", b.Name.ToString());
            DBHelper.ENQ(update);
            string Count = string.Format("select count(*) from ShoppingCart where Name='{0}'", b.Name.ToString());//查数量
            int quantity = (int)DBHelper.ES(Count);//数量
            string Sum = string.Format("select sum(quantity* money) from ShoppingCart");//查总价
            string ShopCount = string.Format("select sum(quantity) from ShoppingCart");//查个数

            Price = DBHelper.ES(Sum);
            label2.Text = Price.ToString();
            label4.Text = DBHelper.ES(ShopCount).ToString();
        }

        /// <summary>
        /// 修改商品事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void set_click(object sender, System.EventArgs e)
        {
            Button b = (Button)sender;
            DishesName = b.Name.ToString(); //单击时把当前单机按钮的值传给变量 给购物车窗口调用
            UpdateDishes updateDishes = new UpdateDishes();
            AdminUser_side.adminUser_Side.AdminLoadform(updateDishes);
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                Ordering_food ordering_Food = new Ordering_food();
                AdminUser_side.adminUser_Side.AdminLoadform(ordering_Food);
                Close();
            }
            else
            {
                //当返回时把已完成界面或主界面赋值过的用来查询的商家名字 和订单编号清空清空  以免查不到其他商家
                Order_Completed.order_Completed.OrderCmpName = "";
                Orders_All.orders.OrderAllName = "";
                Orders_Main.orders_Main.OrderMainName = "";
                Ordering_food ordering_Food = new Ordering_food();
                User_side.user_Side.loadform(ordering_Food);
                Close();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (AdminLogin.adminLogin.identity == "管理员")
            {


            }
            else
            {
                ShoppingCart shoppingCart = new ShoppingCart();
                User_side.user_Side.loadform(shoppingCart);//打开购物车
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            User_side.user_Side.loadform(shoppingCart);
        }
    }
}

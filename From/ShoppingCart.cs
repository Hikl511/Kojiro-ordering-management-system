using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system.用户端
{
    public partial class ShoppingCart : Form
    {
        public static ShoppingCart shoppingCart = new ShoppingCart();
        string Uid = Form1.form1.textBox1.Text;
        string Pwd = Form1.form1.textBox2.Text;

        public ShoppingCart()
        {
            InitializeComponent();
            shoppingCart = this;
        }

        private void ShoppingCart_Load(object sender, EventArgs e)
        {
            try
            {
                PicLableButtonShow();
                SetlLeAccountsButton();//结账按钮
                LabelText();
                linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;//超链接文本去除下划线
                comboxShow();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void UsAddress()//查询用户收货地址
        {
            string SetSql = string.Format("select * from");
        }

        public void PicLableButtonShow()
        {//对pic1操作
            try
            {
                string sqlcount = "select Count(Name) from ShoppingCart";//查询行数 
                int result = (int)DBHelper.ES(sqlcount);
                string[] imag = new string[result];//图片路径
                string[] lbltxt = new string[result];//菜品名字
                string[] money = new string[result];//菜品价格
                string[] shopcount = new string[result];//菜品数量

                PictureBox[] pb = new PictureBox[result];
                Label[] lbl = new Label[result];
                Label[] lbl2 = new Label[result];
                Button[] btu1 = new Button[result];
                string cmdText = string.Format("select * from ShoppingCart");
                // string cmdText = string.Format("select Logo,Name,ID from Business");
                SqlDataReader dr = DBHelper.GDR(cmdText);
                int i = 0;
                int x = 0;
                int y = 0;
                while (dr.Read())
                {
                    imag[i] = dr["image"].ToString();
                    lbltxt[i] = dr["Name"].ToString();
                    money[i] = dr["money"].ToString();
                    shopcount[i] = dr["quantity"].ToString();
                    i++;
                }
                dr.Close();
                for (i = 0; i < result; i++)
                {
                    pb[i] = new PictureBox();
                    lbl[i] = new Label();
                    btu1[i] = new Button();
                    lbl2[i] = new Label();
                    btu1[i].Name = lbltxt[i];
                    pb[i].Name = lbltxt[i];
                    System.Drawing.Point p = new Point(80 * x, 15 + y);
                    pb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    pb[i].Location = p;
                    pb[i].Size = new Size(100, 100);
                    pb[i].BorderStyle = BorderStyle.None;
                    Image img = Image.FromFile(imag[i]);
                    pb[i].Image = img;
                    lbl[i].Name = lbltxt[i];
                    System.Drawing.Point p2 = new Point(80 * x, 120 + y);//x宽 y高
                    lbl[i].Location = p2;
                    lbl[i].Size = new Size(100, 20);
                    lbl[i].BorderStyle = BorderStyle.None;
                    lbl[i].Font = new Font("微软雅黑", 9);
                    lbl[i].Text = lbltxt[i];
                    lbl[i].AutoEllipsis = false;//对超出lable宽度的文字自动处理//  事件 pb[i].Click += new System.EventHandler(btn_click);
                    lbl2[i].Name = "label" + i;
                    System.Drawing.Point p3 = new Point(80 * x, 140 + y);//x宽 y高
                    lbl2[i].Location = p3;
                    lbl2[i].Size = new Size(100, 20);
                    lbl2[i].BorderStyle = BorderStyle.None;
                    lbl2[i].Font = new Font("宋体", 9);
                    lbl2[i].Text = "￥" + money[i].Substring(0, 4) + "   *" + shopcount[i];//截取价格字符串  保留一个小数点                                               // lbl2[i].Text = money[i];
                    lbl2[i].ForeColor = Color.Red;
                    btu1[i].Size = new Size(80, 20);
                    btu1[i].FlatAppearance.BorderSize = 0;//无边框
                    btu1[i].Name = lbltxt[i];
                    btu1[i].Text = "删除";
                    btu1[i].Font = new Font("宋体", 9);
                    btu1[i].FlatStyle = FlatStyle.Flat;
                    System.Drawing.Point p4 = new Point(80 * x, 160 + y);//x宽 y高
                    btu1[i].Location = p4;
                    btu1[i].Click += new System.EventHandler(del_click);//添加删除事件
                    panel1.Controls.Add(pb[i]);
                    panel1.Controls.Add(lbl[i]);
                    panel1.Controls.Add(lbl2[i]);
                    panel1.Controls.Add(btu1[i]);
                    x++;
                    if (x++ >= 4)
                    {
                        x = 0;
                        y += 180;
                    }
                    dr.Close();
                }
            }
            catch (Exception)//捕获一异常然后抛出
            {

                // throw e;
            }
            finally
            {

            }
        }

        public void SetlLeAccountsButton()//结账按钮
        {
            try
            {
                Button[] btu = new Button[1];
                int i = 0;
                for (i = 0; i < 1; i++)
                {
                    btu[i] = new Button();
                    btu[i].Name = "button" + i;
                    System.Drawing.Point p = new Point(490, 490);
                    btu[i].Location = p;
                    btu[i].Anchor = (AnchorStyles)Bottom;
                    btu[i].Size = new Size(70, 30);
                    btu[i].BackColor = Color.White;
                    btu[i].FlatStyle = FlatStyle.Flat;
                    btu[i].FlatAppearance.BorderSize = 0;//无边框
                    btu[i].Text = "结账";
                    btu[i].Font = new Font("微软雅黑", 11);
                    panel2.Controls.Add(btu[i]);
                    btu[i].Click += new System.EventHandler(checkout_click);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string DelName;
        public void del_click(object sender, System.EventArgs e)//删除事件
        {
            Button b = (Button)sender;
            DelName = b.Name.ToString(); //单击时把当前单机按钮的值传给变量 给删除语句窗口调用
            //添加到购物车表
            string DeleteSql = string.Format("delete from ShoppingCart where Name='{0}'", b.Name.ToString());
            if (DBHelper.ENQ(DeleteSql))
            {
                ShoppingCart shoppingCart = new ShoppingCart();
                User_side.user_Side.loadform(shoppingCart);
            }
        }
        public void checkout_click(object sender, System.EventArgs e)//打开结账界面
        {
            string sqlcount = "select Count(Name) from ShoppingCart";//查询行数 
            int result = (int)DBHelper.ES(sqlcount);
            if (comboBox1.Text != "")
            {
                if (result > 0)//判断购物车是否有商品
                {
                    Checkout checkout = new Checkout();
                    User_side.user_Side.loadform(checkout);
                    //如果有商品 就添加到订单表
                    /*[ID]//主键
                      [BusinessName]//商家名称
                      [State]//State//订单状态
                      [ReturnTime]//下单时间
                      [CompletionTime]//完成时间
                      [Address]//地址
                      [OrderNumber]//订单编号
                      [Price]//总价格
                      [ClassID] *///用户ID
                    string setUsID =string.Format("select ID from Ustable where Uid='{0}' and Pwd='{1}'",Uid,Pwd);
                    SqlDataReader dr = DBHelper.GDR(setUsID);
                    string ClassID="";
                    while (dr.Read())
                    {
                        ClassID = dr["ID"].ToString();
                    }
                    dr.Close();
                    string BusinessName = Ordering_food.ordering_Food.name;
                    int state = 0;//订单状态先默认为0
                    string ReturnTime = DateTime.Now.ToString();//获取到秒
                    string Address = comboBox1.Text;
                    string OrderNumber = Business.business.OrderNumber;
                    string Price = DiscountedPrice.ToString().Substring(0, 4);//总价格
                    string setOrders = string.Format("insert Orders values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",BusinessName,state,ReturnTime,Address,OrderNumber,Price,ClassID);
                    DBHelper.ENQ(setOrders);//添加到订单表
                    //打开购物车时  关闭订单主界面 防止支付成功后订单状态没有修改  因为修改状态的代码 写在订单主界面的加载方法里 所以要写
                    Orders_Main orders_Main = new Orders_Main();
                    orders_Main.Close();
                }
                else
                {
                    MessageBox.Show("您还没有选择商品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("请选择或添加收货地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public void DelShopCart()//清空购物车方法
        {
            try
            {
                //清空购物车
                string deletesql = string.Format("delete from ShoppingCart");
                DBHelper.ENQ(deletesql);
                MessageBox.Show("清空购物车成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Business business = new Business();
                User_side.user_Side.loadform(business);
            }
            catch (Exception)
            {

                // throw;
            }
        }


        public double DiscountedPrice;
        public void LabelText()//获取数量和总价
        {
            string sqlcount = "select Count(Name) from ShoppingCart";//查询行数 
            int result = (int)DBHelper.ES(sqlcount);
            if (result > 0)//大于0就代表购物车有数据了
            {
                string Sum = string.Format("select sum(quantity* money)Sum from ShoppingCart");//查总价
                string ShopCount = string.Format("select sum(quantity) from ShoppingCart");//查个数
                object Price = DBHelper.ES(Sum);
                string sum = Price.ToString();
                string PriceSum = DBHelper.ES(ShopCount).ToString();
                SqlDataReader dr = DBHelper.GDR(Sum);
                while (dr.Read())
                {
                    DiscountedPrice = double.Parse(dr["Sum"].ToString()) * 0.0008;
                    label3.Text = "商品数量:" + PriceSum + " ￥:" + sum.Substring(0, 5) + "  (0.0008折后价)￥:" + DiscountedPrice.ToString().Substring(0, 4);// + DiscountedPrice
                }
                dr.Close();


            }
            else
            {
                label3.Text = "购物车空空如也(ˉ▽ˉ；)...";
            }
        }
        int i = 0;
        public void comboxShow()//收货地址方法
        {
            string sqlcount = string.Format("select count(ClassID) from UserAddress where ClassID=(select ID from Ustable Where Uid='{0}' and pwd='{1}')", Uid, Pwd); //查询行数 
            int result = (int)DBHelper.ES(sqlcount);
            if (result > 0)
            {
                string[] Address = new string[result];
                string[] Name = new string[result];
                string[] Sex = new string[result];
                string[] Phone = new string[result];
                string[] UserAddress = new string[result];
                string setAres = string.Format("select * from UserAddress where ClassID=(select ID from Ustable Where Uid='{0}' and pwd='{1}')", Uid, Pwd);
                SqlDataReader dr = DBHelper.GDR(setAres);
                while (dr.Read())
                {
                    Address[i] = dr["Address"].ToString();
                    Name[i] = dr["Name"].ToString();
                    Sex[i] = dr["Sex"].ToString();
                    Phone[i] = dr["Phone"].ToString();
                    i++;
                }
                dr.Close();
                for (int i = 0; i < result; i++)
                {
                    UserAddress[i] = Address[i] + "  " + Name[i].Trim() + "  (" + Sex[i].Trim() + ")  " + Phone[i].Trim();
                }
                foreach (var item in UserAddress)
                {
                    comboBox1.Items.Add(item);
                }
                comboBox1.Text = UserAddress[0];//给下拉框赋值查询出来的第一个地址
            }
            else
            {
                comboBox1.Text = "请先添加收货地址！";//如果没有查询到地址就提示用户去添加
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Business business = new Business();
            User_side.user_Side.loadform(business);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DelShopCart();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DelShopCart();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUsAddress addUsAddress = new AddUsAddress();
            User_side.user_Side.loadform(addUsAddress); //打开添加地址
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

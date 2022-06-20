using Kojiro_ordering_management_system.用户端;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{
    public partial class Orders_Main : Form
    {
        public static Orders_Main orders_Main = new Orders_Main();
        public string OrderMainName = "";
        string Uid = Form1.form1.textBox1.Text;
        string Pwd = Form1.form1.textBox2.Text;
        public Orders_Main()
        {
            InitializeComponent();
            orders_Main = this;
        }

        private void Orders_Main_Load(object sender, EventArgs e)
        {
            //comboBox1.SelectedIndex = 0;
            try
            {

                if (Checkout.checkout.label6.Text == "1")//1是支付成功
                {
                    string OrderNumber = Business.business.OrderNumber;//Business窗体里生成的订单编号
                    string updateOrder = string.Format("update Orders set State='{0}' where OrderNumber='{1}'", 1, OrderNumber);
                    DBHelper.ENQ(updateOrder);
                    // AddOrders();
                }
                OrdersShow();//加载全部订单
                // label2.Text = Checkout.checkout.label6.Text;
            }
            catch (System.Exception)
            {

               // throw;
            }
        }

        /// <summary>
        /// 查询全部订单
        /// </summary>
        public void OrdersShow()
        {
            string sqlcount = string.Format("select count(BusinessName) from Orders where ClassID=(select ID from Ustable Where Uid='{0}' and pwd='{1}')", Uid, Pwd); //查询用户订单行数 
            int result = (int)DBHelper.ES(sqlcount);
            if (result > 0)
            {

                string[] ID = new string[result];//ID
                string[] BusinessName = new string[result];//商家名字
                string[] State = new string[result];//订单状态
                string[] ReturnTime = new string[result];//下单时间
                string[] OrderNumber = new string[result];//订单编号
                string[] Price = new string[result];//合计价格
                string[] OrderName = new string[result];//查菜品名字
                string[] OrdersImage = new string[result];//查订单表对应菜品物品图片
                string[] SumCount = new string[result];//菜品数量
                Label[] lbl1 = new Label[result];//商家名字 + 状态
                PictureBox[] pic = new PictureBox[result];//商品图片
                Label[] lbl2 = new Label[result];//下单时间
                Label[] lbl3 = new Label[result];//  数量 + 总价格  共2件  ￥：.。。
                Button[] btu1 = new Button[result];
                // Button[] btu2 = new Button[result];
                // string cmdText = string.Format("select Logo,Name,ID from Business");
                int i = 0;
                int x = 0;
                int y = 0;
                string setAres = string.Format("select * from Orders where ClassID=(select ID from Ustable Where Uid='{0}' and pwd='{1}')", Uid, Pwd);
                SqlDataReader dr = DBHelper.GDR(setAres);
                while (dr.Read())
                {
                    ID[i] = dr["ID"].ToString();
                    BusinessName[i] = dr["BusinessName"].ToString();
                    State[i] = dr["State"].ToString();
                    ReturnTime[i] = dr["ReturnTime"].ToString();
                    OrderNumber[i] = dr["OrderNumber"].ToString();
                    Price[i] = dr["Price"].ToString();
                    i++;
                }
                dr.Close();
                for (i = 0; i < result; i++)
                {
                    lbl1[i] = new Label();
                    lbl2[i] = new Label();
                    lbl3[i] = new Label();
                    btu1[i] = new Button();
                    pic[i] = new PictureBox();
                    string sum = string.Format("select sum(quantity) from TemporaryMenu where OrderNumber = '{0}'", OrderNumber[i]);
                    int OrdersSum = (int)DBHelper.ES(sum);//查每个订单编号的菜品个数
                    SumCount[i] = OrdersSum.ToString();
                    //label2.Text = State[i].ToString();
                    //获取状态信息并修改值   //支付状态 0已取消 1 已付款  2待确认  3已接单 4派送中 5已完成



                    if (State[i].Equals("0"))
                    {
                        State[i] = "已取消";
                        btu1[i].Text = "删除";//已取消的订单可以删除
                        btu1[i].Click += new System.EventHandler(del_click);
                    }
                    else if (State[i] == "1")
                    {
                        State[i] = "已付款";
                        btu1[i].Text = "取消";//已付款订单名字改成待商家接单
                        btu1[i].Click += new System.EventHandler(Cancel_click);
                    }
                    else if (State[i] == "3")
                    {
                        State[i] = "已接单";
                        btu1[i].Text = "确认收货";//已接单改成待送达
                        btu1[i].Click += new System.EventHandler(Comple_click);
                    }
                    else if (State[i] == "4")
                    {
                        State[i] = "派送中";
                        btu1[i].Text = "确认收货";//已付款订单名字改成待商家接单
                        btu1[i].Click += new System.EventHandler(Comple_click);
                    }
                    else if (State[i] == "5")
                    {
                        State[i] = "已完成";
                        btu1[i].Text = "再次购买";//已付款订单名字改成待商家接单
                        btu1[i].Click += new System.EventHandler(Shops_click);
                    }



                    string SetTpm = string.Format("select * from TemporaryMenu where OrderNumber='{0}'", OrderNumber[i]);//通过订单号查订单对应菜品
                    SqlDataReader dr2 = DBHelper.GDR(SetTpm);
                    while (dr2.Read())
                    {
                        OrderName[i] = dr2["Name"].ToString();
                        OrdersImage[i] = dr2["image"].ToString();
                    }
                    dr2.Close();

                    pic[i].Name = OrderName[i];
                    System.Drawing.Point p = new Point(80 * x, 15 + y);
                    pic[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    pic[i].Location = p;
                    pic[i].Size = new Size(90, 90);
                    pic[i].BorderStyle = BorderStyle.None;
                    Image img = Image.FromFile(OrdersImage[i]);
                    pic[i].Image = img;
                    lbl1[i].Name = "lbl3" + i;
                    System.Drawing.Point p2 = new Point(80 * x, 110 + y);//x宽 y高
                    lbl1[i].Location = p2;
                    lbl1[i].Size = new Size(100, 20);
                    lbl1[i].BorderStyle = BorderStyle.None;
                    lbl1[i].Font = new Font("微软雅黑", 9);
                    lbl1[i].Text = "商家:" + BusinessName[i].Trim() + "订单状态:" + State[i].Trim();//商家名字 + 状态
                    lbl1[i].AutoEllipsis = true;//对超出lable宽度的文字自动处理//  事件 pb[i].Click += new System.EventHandler(btn_click);


                    lbl2[i].Name = "labe2" + i;
                    System.Drawing.Point p3 = new Point(80 * x, 130 + y);//x宽 y高
                    lbl2[i].Location = p3;
                    lbl2[i].Size = new Size(100, 20);
                    lbl2[i].BorderStyle = BorderStyle.None;
                    lbl2[i].Font = new Font("微软雅黑", 7);
                    lbl2[i].Text = "下单时间:" + ReturnTime[i].Substring(0, 9);//下单时间
                    lbl2[i].ForeColor = Color.DimGray;



                    lbl3[i].Name = "labe3" + i;
                    System.Drawing.Point p4 = new Point(80 * x, 150 + y);//x宽 y高
                    lbl3[i].Location = p4;
                    lbl3[i].Size = new Size(100, 20);
                    lbl3[i].BorderStyle = BorderStyle.None;
                    lbl3[i].Font = new Font("微软雅黑", 7);
                    lbl3[i].Text = "共 " + SumCount[i].Trim() + " 件 " + "合计 ￥ " + Price[i].Trim().Substring(0, 4);//数量 金额
                    lbl3[i].AutoEllipsis = true;//对超出lable宽度的文字自动处理//  事件 pb[i].Click += new System.EventHandler(btn_click);
                    lbl3[i].ForeColor = Color.DimGray;



                    btu1[i].Size = new Size(80, 20);
                    btu1[i].FlatAppearance.BorderSize = 0;//无边框 btu1[i].FlatStyle = FlatStyle.Flat;
                    btu1[i].Name = OrderNumber[i];
                    btu1[i].Tag = BusinessName[i];//Tag 用户自定义绑定的值
                    btu1[i].Font = new Font("宋体", 9);
                    btu1[i].FlatStyle = FlatStyle.Flat;
                    System.Drawing.Point p5 = new Point(80 * x, 170 + y);//x宽 y高
                    btu1[i].Location = p5;
                    //btu1[i].Click += new System.EventHandler(btn_click);
                    // btu1[i].Click += new System.EventHandler(checkout_click);
                    panel1.Controls.Add(pic[i]);
                    panel1.Controls.Add(lbl1[i]);
                    panel1.Controls.Add(lbl2[i]);
                    panel1.Controls.Add(lbl3[i]);
                    panel1.Controls.Add(btu1[i]);
                    //   panel1.Controls.Add(txb3[i]);
                    //   panel1.Controls.Add(txb4[i]);
                    //  panel1.Controls.Add(btu1[i]);
                    x++;
                    if (x++ >= 4)
                    {
                        x = 0;
                        y += 180;
                    }
                    dr.Close();
                }
            }
            else
            {
                // 没有订单提示文本
                label2.Visible = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                Orders_All orders_All = new Orders_All();
                AdminUser_side.adminUser_Side.AdminLoadform(orders_All);

            }
            else
            {
                Orders_All orders_All = new Orders_All();
                User_side.user_Side.loadform(orders_All);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                Order_Paid order_Paid = new Order_Paid();
                AdminUser_side.adminUser_Side.AdminLoadform(order_Paid);

            }
            else
            {
                Order_Paid order_Paid = new Order_Paid();
                User_side.user_Side.loadform(order_Paid);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                Order_Completed order_Completed = new Order_Completed();
                AdminUser_side.adminUser_Side.AdminLoadform(order_Completed);

            }
            else
            {
                Order_Completed order_Completed = new Order_Completed();
                User_side.user_Side.loadform(order_Completed);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                Order_Close order_Close = new Order_Close();
                AdminUser_side.adminUser_Side.AdminLoadform(order_Close);

            }
            else
            {
                Order_Close order_Close = new Order_Close();
                User_side.user_Side.loadform(order_Close);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                Orders_Delivery orders_Delivery = new Orders_Delivery();
                AdminUser_side.adminUser_Side.AdminLoadform(orders_Delivery);

            }
            else
            {
                Orders_Delivery orders_Delivery = new Orders_Delivery();
                User_side.user_Side.loadform(orders_Delivery);
            }

        }

        public void del_click(object sender, System.EventArgs e)//删除事件
        {
            Button b = (Button)sender;
            //DelOrderNumber = b.Name.ToString(); //单击时把当前单机按钮的值传给变量 给删除语句窗口调用
            DialogResult result = MessageBox.Show("确认删除此订单?" + "\n" + "订单删除后将无法恢复", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
            {
                string DeleteSql = string.Format("delete from Orders where OrderNumber='{0}'", b.Name.ToString());
                if (DBHelper.ENQ(DeleteSql))
                {
                    Orders_Main orders_Main = new Orders_Main();
                    User_side.user_Side.loadform(orders_Main);
                }
            }
        }

        public void Cancel_click(object sender, System.EventArgs e)//取消事件
        {
            Button b = (Button)sender;
            //DelOrderNumber = b.Name.ToString(); //单击时把当前单机按钮的值传给变量 给删除语句窗口调用
            string DeleteSql = string.Format("update Orders set State = 0 where OrderNumber='{0}'", b.Tag.ToString());
            if (DBHelper.ENQ(DeleteSql))
            {
                MessageBox.Show("订单已取消!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Orders_Main orders_Main = new Orders_Main();
                User_side.user_Side.loadform(orders_Main);
            }
        }

        /// <summary>
        /// 再次购买事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Shops_click(object sender, System.EventArgs e)
        {
            Button b = (Button)sender;
            OrderMainName = b.Tag.ToString(); //单击时把当前单机按钮的值传给变量 给删除语句窗口调用
            Business business = new Business();//打开商家窗口
            User_side.user_Side.loadform(business);
        }


        /// <summary>
        /// 确认收货事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Comple_click(object sender, System.EventArgs e)
        {
            Button b = (Button)sender;
            //DelOrderNumber = b.Name.ToString(); //单击时把当前单机按钮的值传给变量 给删除语句窗口调用
            DialogResult result = MessageBox.Show("确认收到货了吗" + "\n" + "为了保证您的权益，请收到商品确认无误后再确认收货!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                string DeleteSql = string.Format("update Orders set State = '5' where OrderNumber='{0}'", b.Name.ToString());//根据订单编号修改状态
                if (DBHelper.ENQ(DeleteSql))
                {
                    Orders_Main orders_Main = new Orders_Main();
                    User_side.user_Side.loadform(orders_Main);
                }

            }
        }
    }
}

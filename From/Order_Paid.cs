using Kojiro_ordering_management_system.用户端;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{
    public partial class Order_Paid : Form
    {
        string Uid = Form1.form1.textBox1.Text;
        string Pwd = Form1.form1.textBox2.Text;
        public Order_Paid()
        {
            InitializeComponent();
        }

        private void Order_Paid_Load(object sender, EventArgs e)
        {
            try
            {
                State1();
            }
            catch (Exception)
            {

                //throw;
            }
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                label1.Text = "已付款订单";
            }
        }

        /// <summary>
        /// 已付款
        /// </summary>
        public void State1()
        {
            int result;
            if (AdminLogin.adminLogin.identity == "管理员")
            {
                string sqlcount = string.Format("select count(BusinessName) from Orders "); //查询用户订单行数 
                result = (int)DBHelper.ES(sqlcount);
            }
            else
            {
                string sqlcount = string.Format("select count(BusinessName) from Orders where ClassID=(select ID from Ustable Where Uid='{0}' and pwd='{1}')", Uid, Pwd); //查询用户订单行数 
                result = (int)DBHelper.ES(sqlcount);
            }

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
                string[] UserName = new string[result];//用户名字
                string[] UserPhone = new string[result];//用户电话
                string[] UserAddress = new string[result];//用户收货地址


                Label[] lbl1 = new Label[result];//商家名字 + 状态
                PictureBox[] pic = new PictureBox[result];//商品图片
                Label[] lbl2 = new Label[result];//下单时间
                Label[] lbl3 = new Label[result];//  数量 + 总价格  共2件  ￥：.。。
                Button[] btu1 = new Button[result];
                Button[] btu2 = new Button[result];
                // Button[] btu2 = new Button[result];
                // string cmdText = string.Format("select Logo,Name,ID from Business");
                int i = 0;
                int x = 0;
                int y = 0;
                string setAres;
                if (AdminLogin.adminLogin.identity == "管理员")
                {
                    setAres = string.Format("select * from Orders where State='{0}'",1);
                }
                else
                {
                    setAres = string.Format("select * from Orders where ClassID=(select ID from Ustable Where Uid='{0}' and pwd='{1}') and State='{2}'", Uid, Pwd, 1);//根据状态查询出来的结果
                }
               
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
                    btu2[i] = new Button();
                    pic[i] = new PictureBox();
                    string sum = string.Format("select sum(quantity) from TemporaryMenu where OrderNumber = '{0}'", OrderNumber[i]);
                    int OrdersSum = (int)DBHelper.ES(sum);//查每个订单编号的菜品个数
                    SumCount[i] = OrdersSum.ToString();
                    //label2.Text = State[i].ToString();
                    //获取状态信息并修改值   //支付状态 0已取消 1 已付款  2待确认  3已接单 4派送中 5已完成
                    if (AdminLogin.adminLogin.identity == "管理员")
                    {
                        if (State[i].Equals("0"))
                        {
                            State[i] = "已取消";
                            btu1[i].Text = "删除";//已取消的订单可以删除
                         //   btu1[i].Click += new System.EventHandler(del_click);
                        }
                        else if (State[i] == "1")
                        {
                            State[i] = "客户已付款 待商家接单";
                            btu1[i].Text = "接单";
                            //如果是管理员 就在已付款的订单加上取消按钮
                            btu2[i].Text = "取消";
                            btu2[i].Size = new Size(80, 20);
                            btu2[i].FlatAppearance.BorderSize = 0;//无边框 btu1[i].FlatStyle = FlatStyle.Flat;
                            btu2[i].Name = OrderNumber[i];
                            btu2[i].Tag = BusinessName[i];//Tag 用户自定义绑定的值
                            btu2[i].Font = new Font("宋体", 9);

                            btu2[i].FlatStyle = FlatStyle.Flat;
                            System.Drawing.Point p6 = new Point(80 * x, 170 + y);//x宽 y高
                            btu2[i].Location = p6;
                            btu1[i].Click += new System.EventHandler(Take_orders_click);
                            btu2[i].Click += new System.EventHandler(Cancel_click);
                            panel1.Controls.Add(btu2[i]);
                        }
                        else if (State[i] == "3")
                        {
                            State[i] = "已接单";
                            btu1[i].Text = "派送";//已接单改成确认收货
                         //   btu1[i].Click += new System.EventHandler(Comple_click);
                        }
                        else if (State[i] == "4")
                        {
                            State[i] = "派送中";
                            btu1[i].Text = "待收货";//派送中改确认收货
                          //  btu1[i].Click += new System.EventHandler(Comple_click);
                        }
                        else if (State[i] == "5")
                        {
                            State[i] = "已完成";
                            btu1[i].Text = "用户信息";
                       

                        }
                    }
                    else { 


                    if (State[i].Equals("0"))
                    {
                        State[i] = "已取消";
                        btu1[i].Text = "删除";//已取消的订单可以删除
                    }
                    else if (State[i] == "1")
                    {
                        State[i] = "已付款 待商家接单";
                        btu1[i].Text = "取消";//已付款订单名字改成待商家接单
                        btu1[i].Click += new System.EventHandler(Cancel_click);
                    }
                    else if (State[i] == "3")
                    {
                        State[i] = "已接单";
                        btu1[i].Text = "确认收货";//已接单改成待送达
                    }
                    else if (State[i] == "4")
                    {
                        State[i] = "派送中";
                        btu1[i].Text = "催促";//已付款订单名字改成待商家接单
                    }
                    else if (State[i] == "5")
                    {
                        State[i] = "已完成";
                        btu1[i].Text = "再来一单";//已付款订单名字改成待商家接单
                    }

                    }




                    string SetTpm = string.Format("select * from TemporaryMenu where OrderNumber='{0}'", OrderNumber[i]);//通过订单号查订单对应菜品
                    SqlDataReader dr2 = DBHelper.GDR(SetTpm);
                    while (dr2.Read())
                    {
                        OrderName[i] = dr2["Name"].ToString();
                        OrdersImage[i] = dr2["image"].ToString();
                    }
                    dr2.Close();
                    //  btu1[i].Name = "Button" + i + 1;
                    pic[i].Name = OrderName[i];
                    System.Drawing.Point p = new Point(80 * x, 15 + y);
                    pic[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    pic[i].Location = p;
                    pic[i].Size = new Size(90, 90);
                    pic[i].BorderStyle = BorderStyle.None;
                    Image img = Image.FromFile(OrdersImage[i]);
                    pic[i].Image = img;
                    lbl1[i].Name = "lbl3" + i;
                    System.Drawing.Point p2 = new Point(80 * x, 105 + y);//x宽 y高
                    lbl1[i].Location = p2;
                    lbl1[i].Size = new Size(100, 15);
                    lbl1[i].BorderStyle = BorderStyle.None;
                    lbl1[i].Font = new Font("微软雅黑", 9);
                    lbl1[i].Text = "商家:" + BusinessName[i].Trim() + "  状态:" + State[i].Trim();//商家名字 + 状态
                    lbl1[i].AutoEllipsis = true;//对超出lable宽度的文字自动处理//  事件 pb[i].Click += new System.EventHandler(btn_click);


                    lbl2[i].Name = "labe2" + i;
                    System.Drawing.Point p3 = new Point(80 * x, 118 + y);//x宽 y高
                    lbl2[i].Location = p3;
                    lbl2[i].Size = new Size(100, 13);
                    lbl2[i].BorderStyle = BorderStyle.None;
                    lbl2[i].Font = new Font("微软雅黑", 7);
                    lbl2[i].Text = "下单时间:" + ReturnTime[i].Substring(0, 9);//下单时间
                    lbl2[i].ForeColor = Color.DimGray;



                    if (AdminLogin.adminLogin.identity == "管理员")//如果是管理员端 就查询用户名字+电话+收货地址 并在界面显示
                    {
                        string SrtNamePhone = string.Format("select * from Ustable where ID=(select ClassID from Orders where OrderNumber='{0}')", OrderNumber[i]);
                        SqlDataReader dr3 = DBHelper.GDR(SrtNamePhone);
                        while (dr3.Read())
                        {
                            UserName[i] = dr3["Name"].ToString().Trim();
                            UserPhone[i] = dr3["Phone"].ToString();
                        }
                        dr3.Close();

                        string SetUserAddress = string.Format("select Address from UserAddress where ClassID=(select ClassID from Orders where OrderNumber='{0}')", OrderNumber[i]);
                        SqlDataReader dr4 = DBHelper.GDR(SetUserAddress);
                        while (dr4.Read())
                        {
                            UserAddress[i] = dr4["Address"].ToString().Trim();
                        }
                        dr4.Close();
                        lbl3[i].Name = "labe3" + i;
                        System.Drawing.Point p4 = new Point(80 * x, 130 + y);//x宽 y高
                        lbl3[i].Location = p4;
                        lbl3[i].Size = new Size(100, 13);
                        lbl3[i].BorderStyle = BorderStyle.None;
                        lbl3[i].Font = new Font("微软雅黑", 7);
                        lbl3[i].Text = "用户名字: " + UserName[i] + "  用户电话: " + UserPhone[i] + "\n" + "收货地址:" + UserAddress[i];
                        lbl3[i].AutoEllipsis = true;//对超出lable宽度的文字自动处理//  事件 pb[i].Click += new System.EventHandler(btn_click);
                        lbl3[i].ForeColor = Color.DimGray;
                    }
                    else
                    {
                        lbl3[i].Name = "labe3" + i;
                        System.Drawing.Point p4 = new Point(80 * x, 130 + y);//x宽 y高
                        lbl3[i].Location = p4;
                        lbl3[i].Size = new Size(100, 13);
                        lbl3[i].BorderStyle = BorderStyle.None;
                        lbl3[i].Font = new Font("微软雅黑", 7);
                        lbl3[i].Text = "共 " + SumCount[i].Trim() + " 件 " + "合计 ￥ " + Price[i].Trim().Substring(0, 4);//数量 金额
                        lbl3[i].AutoEllipsis = true;//对超出lable宽度的文字自动处理//  事件 pb[i].Click += new System.EventHandler(btn_click);
                        lbl3[i].ForeColor = Color.DimGray;
                    }
                



                    btu1[i].Size = new Size(80, 20);
                    btu1[i].FlatAppearance.BorderSize = 0;//无边框 btu1[i].FlatStyle = FlatStyle.Flat;
                    btu1[i].Name = OrderNumber[i];
                    btu1[i].Tag = BusinessName[i];//Tag 用户自定义绑定的值
                    btu1[i].Font = new Font("宋体", 9);
                    btu1[i].FlatStyle = FlatStyle.Flat;
                    System.Drawing.Point p5 = new Point(80 * x, 145 + y);//x宽 y高
                    btu1[i].Location = p5;
                    //btu1[i].Click += new System.EventHandler(btn_click);
                    // btu1[i].Click += new System.EventHandler(checkout_click);

                    panel1.Controls.Add(pic[i]);
                    panel1.Controls.Add(lbl1[i]);
                    panel1.Controls.Add(lbl2[i]);
                    panel1.Controls.Add(lbl3[i]);
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
               // Orders_Main orders_Main = new Orders_Main();
                Orders_All orders_All = new Orders_All();
                User_side.user_Side.loadform(orders_All);
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

        private void button3_Click(object sender, EventArgs e)
        {

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
        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Cancel_click(object sender, System.EventArgs e)//取消事件
        {
            Button b = (Button)sender;
            //DelOrderNumber = b.Name.ToString(); //单击时把当前单机按钮的值传给变量 给删除语句窗口调用
            string DeleteSql = string.Format("update Orders set State = 0 where OrderNumber='{0}'", b.Name.ToString());
            if (DBHelper.ENQ(DeleteSql))
            {
                if (AdminLogin.adminLogin.identity == "管理员")
                {
                    MessageBox.Show("订单已取消!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Order_Paid order_Paid = new Order_Paid();
                    AdminUser_side.adminUser_Side.AdminLoadform(order_Paid);
                }
                else
                {
                    MessageBox.Show("订单已取消!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Order_Paid order_Paid = new Order_Paid(); 
                    User_side.user_Side.loadform(order_Paid);
                }
            }
        }


        /// <summary>
        /// 管理员端 接单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Take_orders_click(object sender, System.EventArgs e)
        {
            Button b = (Button)sender;
            //DelOrderNumber = b.Name.ToString(); //单击时把当前单机按钮的值传给变量 给删除语句窗口调用
            string DeleteSql = string.Format("update Orders set State = '3' where OrderNumber='{0}'", b.Name.ToString());//根据订单编号修改状态
            if (DBHelper.ENQ(DeleteSql))
            {
                MessageBox.Show("接单成功!请尽快派送！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Orders_Main orders_Main = new Orders_Main();
                AdminUser_side.adminUser_Side.AdminLoadform(orders_Main);
            }

        }
    }
}

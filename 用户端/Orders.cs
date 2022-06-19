using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{
    public partial class Orders : Form
    {
        public static Orders orders = new Orders();
        string Uid = Form1.form1.textBox1.Text;
        string Pwd = Form1.form1.textBox2.Text;
        public Orders()
        {
            InitializeComponent();
            orders = this;
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

        private void Orders_Load(object sender, System.EventArgs e)
        {
            /* if (Checkout.checkout.label6.Text == "1")//1是支付成功
             {
                 string OrderNumber = Business.business.OrderNumber;
                 string updateOrder = string.Format("update Orders set State='{0}' where OrderNumber='{1}'", 1, OrderNumber);
                 DBHelper.ENQ(updateOrder);
                 // AddOrders();
             }
             label2.Text = Checkout.checkout.label6.Text;
            */
            OrdersShow();
        }

        public void OrdersShow()
        {//对pic1操作
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
                    //获取状态信息并修改值   //支付状态 0已取消 1 已付款  2待确认  3已接单 4已完成
                    if (State[i].Equals("0"))
                    {
                        State[i] = "已取消";
                    }
                    else if (State[i] == "1")
                    {
                        State[i] = "已付款";
                    }
                    else if (State[i] == "2")
                    {
                        State[i] = "待确认";
                    }
                    else if (State[i] == "3")
                    {
                        State[i] = "已接单";
                    }
                    else if (State[i] == "4")
                    {
                        State[i] = "已完成";
                    }
                    string SetTpm = string.Format("select * from TemporaryMenu where OrderNumber='{0}'", OrderNumber[i]);//通过订单号查订单对应菜品
                    SqlDataReader dr2 = DBHelper.GDR(SetTpm);
                    while (dr2.Read())
                    {
                        OrderName[i] = dr2["Name"].ToString();
                        OrdersImage[i] = dr2["image"].ToString();
                    }
                    dr2.Close();
                    if (pic[i] == pic[3])
                    {
                        y += 50;
                    }
                    //  btu1[i].Name = "Button" + i + 1;
                    lbl1[i].Name = "txb1" + i;
                    lbl2[i].Name = "txb2" + i;
                    lbl3[i].Name = "txb3" + i;
                    System.Drawing.Point p = new Point(80 * x, 115 + y);
                    lbl1[i].Location = p;
                    lbl1[i].Size = new Size(100, 30);
                    lbl1[i].BorderStyle = BorderStyle.None;
                    lbl1[i].Text = "商家:" + BusinessName[i].Trim() + "\n" + "订单状态:" + State[i].Trim();//商家名字 + 状态
                    lbl1[i].Font = new Font("宋体", 9);
                    

                    pic[i].Name = BusinessName[i];
                    System.Drawing.Point p2 = new Point(80 * x, 15 + y);
                    pic[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    pic[i].Location = p2;
                    pic[i].Size = new Size(100, 100);
                    pic[i].BorderStyle = BorderStyle.None;
                    Image img = Image.FromFile(OrdersImage[i]);
                    pic[i].Image = img;

                    System.Drawing.Point p3 = new Point(80 * x, 150 + y);
                    lbl2[i].Location = p3;
                    lbl2[i].Size = new Size(100, 30);
                    lbl2[i].BorderStyle = BorderStyle.None;
                    lbl2[i].Text = "下单时间:" + "\n" + ReturnTime[i].Substring(0, 9);//下单时间
                    lbl2[i].Font = new Font("宋体", 9);



                    System.Drawing.Point p4 = new Point(80 * x, 180 + y);
                    lbl3[i].Location = p4;
                    lbl3[i].Size = new Size(100, 30);
                    lbl3[i].BorderStyle = BorderStyle.None;
                    lbl3[i].Text = "共" + SumCount[i].Trim() + "件" + "\n" + "合计 ￥" + Price[i].Trim().Substring(0, 4);//数量 金额
                    lbl3[i].Font = new Font("宋体", 9);

                    btu1[i].Name = "button" + i;
                    System.Drawing.Point p5 = new Point(80 * x, 200 + y);
                    btu1[i].Location = p5;
                    btu1[i].Anchor = (AnchorStyles)Bottom;
                    btu1[i].Size = new Size(100, 20);
                    btu1[i].BackColor = Color.White;
                    btu1[i].FlatStyle = FlatStyle.Flat;
                    btu1[i].FlatAppearance.BorderSize = 0;//无边框
                    btu1[i].Text = "删除";
                    btu1[i].Font = new Font("宋体", 9);
                    // btu1[i].Click += new System.EventHandler(checkout_click);
                    panel1.Controls.Add(lbl1[i]);
                    panel1.Controls.Add(lbl2[i]);
                    panel1.Controls.Add(lbl3[i]);
                    panel1.Controls.Add(pic[i]);
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
        }

    }
}

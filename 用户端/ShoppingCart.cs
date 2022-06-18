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

namespace Kojiro_ordering_management_system.用户端
{
    public partial class ShoppingCart : Form
    {
        public static  ShoppingCart shoppingCart = new ShoppingCart();
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


            }
            catch (Exception)
            {

                //throw;
            }
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
                    lbl2[i].Text = "￥" + money[i].Substring(0, 4)+"   *" +shopcount[i];//截取价格字符串  保留一个小数点                                               // lbl2[i].Text = money[i];
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

        public  void  SetlLeAccountsButton()//结账按钮
        {
            try
            {
                Button[] btu = new Button[1];
                int i = 0;
                for (i = 0; i < 1; i++)
                {
                    btu[i] = new Button();
                    btu[i].Name = "button" + i;
                    System.Drawing.Point p = new Point(460, 480);
                    btu[i].Location = p;
                    btu[i].Anchor = (AnchorStyles)Bottom;
                    btu[i].Size = new Size(80, 40);
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
            Checkout checkout = new Checkout();
            User_side.user_Side.loadform(checkout);
            
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
                string ShopCount = string.Format("select  sum(quantity) from ShoppingCart");//查个数
                object Price = DBHelper.ES(Sum);
                string sum = Price.ToString();
                string PriceSum = DBHelper.ES(ShopCount).ToString();
                SqlDataReader dr = DBHelper.GDR(Sum);
                while (dr.Read())
                {
                   DiscountedPrice = double.Parse(dr["Sum"].ToString()) * 0.0008;
                   label3.Text = "商品数量:" + PriceSum + " ￥:" + sum.Substring(0, 5) +"  (0.0008折后价)￥:" + DiscountedPrice.ToString().Substring(0, 4);// + DiscountedPrice
                }
              dr.Close();
              
               
            }
            else
            {
                label3.Text = "购物车空空如也(ˉ▽ˉ；)...";
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

    }
}

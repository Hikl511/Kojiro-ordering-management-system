using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{
    public partial class Shipping_address : Form
    {
        string Uid = Form1.form1.textBox1.Text;
        string Pwd = Form1.form1.textBox2.Text;
        public Shipping_address()
        {
            InitializeComponent();
        }

        public void pictureBox2_Click(object sender, EventArgs e)
        {
            User_side.user_Side.loadform(My_information.my_Information);//打开窗体

        }

        private void Shipping_address_Load(object sender, EventArgs e)
        {
            PicLableButtonShow();
        }

        public void PicLableButtonShow()
        {//对pic1操作
            string sqlcount = string.Format("select count(ClassID) from UserAddress where ClassID=(select ID from Ustable Where Uid='{0}' and pwd='{1}')", Uid, Pwd); //查询行数 
            int result = (int)DBHelper.ES(sqlcount);
            if (result > 0)
            {
                string[] Address = new string[result];
                string[] Name = new string[result];
                string[] Sex = new string[result];
                string[] Phone = new string[result];
                string[] ID = new string[result];//唯一ID 
                TextBox[] txb1 = new TextBox[result];
                TextBox[] txb2 = new TextBox[result];
                TextBox[] txb3 = new TextBox[result];
                TextBox[] txb4 = new TextBox[result];
                Button[] btu1 = new Button[result];
                //   Button[] btu2 = new Button[result];
                // string cmdText = string.Format("select Logo,Name,ID from Business");
                int i = 0;
                int x = 0;
                int y = 0;
                string setAres = string.Format("select * from UserAddress where ClassID=(select ID from Ustable Where Uid='{0}' and pwd='{1}')", Uid, Pwd);
                SqlDataReader dr = DBHelper.GDR(setAres);
                while (dr.Read())
                {
                    Address[i] = dr["Address"].ToString();
                    Name[i] = dr["Name"].ToString();
                    Sex[i] = dr["Sex"].ToString();
                    Phone[i] = dr["Phone"].ToString();
                    ID[i] = dr["ID"].ToString();
                    i++;
                }
                dr.Close();
                for (i = 0; i < result; i++)
                {
                    txb1[i] = new TextBox();
                    txb2[i] = new TextBox();
                    txb3[i] = new TextBox();
                    txb4[i] = new TextBox();
                    btu1[i] = new Button();
                    //  btu2[i] = new Button();
                    btu1[i].Name = "Button" + i + 1;
                    //  btu2[i].Name = "Button2" + i + 1;
                    txb1[i].Name = "txb1" + i;
                    txb2[i].Name = "txb2" + i;
                    txb3[i].Name = "txb3" + i;
                    System.Drawing.Point p = new Point(80 * x * 2, 15 + y);
                    txb1[i].Location = p;
                    txb1[i].Size = new Size(300, 10);
                    txb1[i].BorderStyle = BorderStyle.None;
                    txb1[i].Text = Address[i];//地址
                    txb1[i].Font = new Font("宋体", 9);

                    System.Drawing.Point p2 = new Point(80 * x * 2, 30 + y);
                    txb2[i].Location = p2;
                    txb2[i].Size = new Size(40, 10);
                    txb2[i].BorderStyle = BorderStyle.None;
                    txb2[i].Text = Name[i];//名字
                    txb2[i].Font = new Font("宋体", 9);

                    System.Drawing.Point p3 = new Point(80 * x * 2, 45 + y);
                    txb3[i].Location = p3;
                    txb3[i].Size = new Size(30, 10);
                    txb3[i].BorderStyle = BorderStyle.None;
                    txb3[i].Text = Sex[i];//性别
                    txb3[i].Font = new Font("宋体", 9);

                    System.Drawing.Point p4 = new Point(80 * x * 2, 60 + y);
                    txb4[i].Location = p4;
                    txb4[i].Size = new Size(100, 10);
                    txb4[i].BorderStyle = BorderStyle.None;
                    txb4[i].Text = Phone[i];//电话
                    txb4[i].Font = new Font("宋体", 9);


                    btu1[i].Size = new Size(50, 20);
                    btu1[i].FlatAppearance.BorderSize = 0;//无边框
                    btu1[i].BackColor = Color.DodgerBlue;
                    btu1[i].ForeColor = Color.White;//字体颜色
                    btu1[i].Name = ID[i];
                    btu1[i].Text = "删除";
                    btu1[i].Font = new Font("宋体", 9);
                    btu1[i].FlatStyle = FlatStyle.Flat;
                    System.Drawing.Point p5 = new Point(80 * x * 2, 75 + y);//x宽 y高
                    btu1[i].Location = p5;
                    btu1[i].Click += new System.EventHandler(del_click);
                    /*
                    btu2[i].Size = new Size(50, 20);
                    btu2[i].FlatAppearance.BorderSize = 0;//无边框
                    btu2[i].BackColor = Color.DodgerBlue;
                    btu2[i].ForeColor = Color.White;//字体颜色
                    btu2[i].Name = ID[i];
                    btu2[i].Text = "删除";
                    btu2[i].Font = new Font("宋体", 9);
                    btu2[i].FlatStyle = FlatStyle.Flat;
                    System.Drawing.Point p6 = new Point(80 * x * 2, 100 + y);//x宽 y高
                    btu2[i].Location = p6;*/

                    panel1.Controls.Add(txb1[i]);
                    panel1.Controls.Add(txb2[i]);
                    panel1.Controls.Add(txb3[i]);
                    panel1.Controls.Add(txb4[i]);
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
                label2.Visible = true;
            }
        }

        public string ID;
        public void del_click(object sender, System.EventArgs e)//删除事件
        {
            Button b = (Button)sender;
            ID = b.Name.ToString(); //单击时把当前单机按钮的值传给变量 给删除语句窗口调用
            //删除表数据
            string DeleteSql = string.Format("delete from UserAddress where ID='{0}'", b.Name.ToString());
            if (DBHelper.ENQ(DeleteSql))
            {
                Shipping_address shipping_Address = new Shipping_address();
                User_side.user_Side.loadform(shipping_Address);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateDishes addUsAddress_My = new UpdateDishes();
            User_side.user_Side.loadform(addUsAddress_My);//打开添加地址
        }
    }
}

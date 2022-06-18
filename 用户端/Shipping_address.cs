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
            string[] Address = new string[result];
            string[] Name = new string[result];
            string[] Sex = new string[result];
            string[] Phone = new string[result];
            TextBox[] txb1 = new TextBox[result];
            TextBox[] txb2 = new TextBox[result];
            TextBox[] txb3 = new TextBox[result];
            TextBox[] txb4 = new TextBox[result];
            Button[] btu1 = new Button[result];
            Button[] btu2 = new Button[result];
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
                btu2[i] = new Button();
                btu1[i].Name = "Button" + i + 1;
                btu2[i].Name = "Button2" + i + 1;
                txb1[i].Name = "txb1" + i;
                txb2[i].Name = "txb2" + i;
                txb3[i].Name = "txb3" + i;
                System.Drawing.Point p = new Point(80 * x, 15 + y);
                txb1[i].Location = p;
                txb1[i].Size = new Size(100, 18);
                txb1[i].BorderStyle = BorderStyle.FixedSingle;
                txb1[i].Text = Address[i];//地址
                System.Drawing.Point p2 = new Point(80 * x, 40 + y);
                txb2[i].Location = p2;
                txb2[i].Size = new Size(40, 18);
                txb2[i].BorderStyle = BorderStyle.FixedSingle;
                txb2[i].Text = Name[i];//名字


                System.Drawing.Point p3 = new Point(80 * x, 62 + y);
                txb3[i].Location = p3;
                txb3[i].Size = new Size(30, 18);
                txb3[i].BorderStyle = BorderStyle.FixedSingle;
                txb3[i].Text = Sex[i];//性别


                System.Drawing.Point p4 = new Point(80 * x, 110 + y);
                txb4[i].Location = p4;
                txb4[i].Size = new Size(140, 18);
                txb4[i].BorderStyle = BorderStyle.FixedSingle;
                txb4[i].Text = Phone[i];//电话


                /* lbl[i].Name = lbltxt[i];
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
                 btu1[i].Size = new Size(80, 20);
                 btu1[i].FlatAppearance.BorderSize = 0;//无边框
                 btu1[i].Name = lbltxt[i];
                 btu1[i].Text = "加入购物车";
                 btu1[i].Font = new Font("宋体", 9);
                 btu1[i].FlatStyle = FlatStyle.Flat;
                 System.Drawing.Point p4 = new Point(80 * x, 150 + y);//x宽 y高
                 btu1[i].Location = p4;
                 btu1[i].Click += new System.EventHandler(btn_click);
                 panel1.Controls.Add(pb[i]);*/
                panel1.Controls.Add(txb1[i]);
                panel1.Controls.Add(txb2[i]);
                panel1.Controls.Add(txb3[i]);
                panel1.Controls.Add(txb4[i]);
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

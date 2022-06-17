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
    public partial class Business : Form
    {
       public static Business business = new Business();
        public Business()
        {
            business = this;
            InitializeComponent();
        }

        private void Business_Load(object sender, EventArgs e)
        {
            label1.Text = name;
            PicShow();
            //PicShow();
        }
        string name = Ordering_food.ordering_Food.a.ToString(); 
        //190, 41
        public void PicShow()
        {//对pic1操作
            string[] imag = new string[1];
            string[] lbltxt = new string[1];
            PictureBox[] pb = new PictureBox[1];
            Label[] lbl = new Label[1];
            string cmdText = string.Format("select introduce,Logo from Business where Name='{0}'", name);
            SqlDataReader dr = DBHelper.GDR(cmdText);
            int i = 0;
            while (dr.Read())
            {
                imag[i] = dr["Logo"].ToString();
                lbltxt[i] = dr["introduce"].ToString();
            }

            for (i = 0; i < 1; i++)
            {
                pb[i] = new PictureBox();
                lbl[i]= new Label();
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
            dr.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ordering_food ordering_Food = new Ordering_food();
            User_side.user_Side.loadform(ordering_Food);
            Close();
        }

    }
}

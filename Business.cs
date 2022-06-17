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
       
        public Business()
        {
            InitializeComponent();
        }

        private void Business_Load(object sender, EventArgs e)
        {
           
            
            if (label1.Text=="")
            {
                string name = Ordering_food.ordering_Food.a.ToString();
                label1.Text = name;
            }
            else
            {
                label1.Text = "";
                string name = Ordering_food.ordering_Food.a.ToString();
                label1.Text = name;
            }
            //PicShow();
        }

        public void PicShow()
        {//对pic1操作
            string[] imag = new string[1];
            PictureBox[] pb = new PictureBox[1];
            string cmdText = string.Format("select Logo from Business where=''");
            SqlDataReader dr = DBHelper.GDR(cmdText);
            int i = 0;
            while (dr.Read())
            {
                imag[i] = dr["Logo"].ToString();
            }

            for (i = 0; i < 1; i++)
            {
                pb[i] = new PictureBox();
                pb[i].Name = "b" + i;
                System.Drawing.Point p = new Point(50, 13 + i * 130);
                pb[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pb[i].Location = p;
                pb[i].Size = new Size(110, 110);
                pb[i].BorderStyle = BorderStyle.None;
                panel1.Controls.Add(pb[i]);
                Image img = Image.FromFile(imag[i]);
                pb[i].Image = img;
               // pb[i].Click += new System.EventHandler(btn_click);
            }
            dr.Close();
        }
    }
}

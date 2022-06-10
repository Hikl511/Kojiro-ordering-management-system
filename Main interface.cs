using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kojiro_ordering_management_system
{
    public partial class Main_interface : Form
    {
        public Ordering_food ordering_Food = new Ordering_food();//实例化
        public Main_interface()
        {
            InitializeComponent();
        }

        private void Main_interface_Load(object sender, EventArgs e)
        {
            /*
            string Uid = Form1.form1.textBox1.Text;//获取登录窗口两个文本框的值
            string Pwd = Form1.form1.textBox2.Text;
            
            string sql = string.Format("select Name from Ustable where Uid='{0}' and Pwd = '{1}'",Uid,Pwd);//查询对应用户名
            SqlDataReader reader = DBHelper.GDR(sql);
            while (reader.Read())
            {
                label1.Text = reader["Name"].ToString();
            }
            reader.Close();//关闭reader对象
            reader.Dispose();//释放
            */
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            User_side.user_Side.loadform(ordering_Food);//调用主窗体方法打开点餐窗体
        }
    }
}

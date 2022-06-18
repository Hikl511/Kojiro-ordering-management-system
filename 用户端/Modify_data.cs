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
    public partial class Modify_data : Form
    {
        string photoname = "";
        string Uid = Form1.form1.textBox1.Text;
        string Pwd = Form1.form1.textBox2.Text;
        public Modify_data()
        {
            InitializeComponent();
        }

        private void Modify_data_Load(object sender, EventArgs e)
        {
            PicShow();
            UsName();
        }

        public void PicShow()//显示头像 用户名
        {
            string strconn = "server=.;database=Kojiror;uid=sa;pwd=1234";
            SqlConnection conn = new SqlConnection(strconn);
            string cmdText = string.Format("select UserImag,Uid from Ustable where Uid='{0}' and Pwd='{1}'", Uid, Pwd);
            SqlDataReader dr = DBHelper.GDR(cmdText);
            while (dr.Read())
            {
                label1.Text = "账号:"+dr["Uid"].ToString();
                if (dr["UserImag"].ToString() != "")
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmdText, conn);
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds);
                        photoname = ds.Tables[0].Rows[0][0].ToString();
                    }
                    catch (Exception)
                    {

                    }
                    pictureBox1.Image = Image.FromFile(photoname);
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(@"D:\XiaoCiLang\Resources\用户.png");
                }
            }
            dr.Close();
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了图片
            {
                photoname = openFileDialog1.FileName;
                //文件路径
                //MessageBox.Show(photoname);
                // pictureBox1.Image = Image.FromFile(photoname);
                string sql = string.Format("update Ustable set UserImag ='" + photoname + "'where Uid='{0}' and Pwd='{1}'", Uid, Pwd);
                try
                {
                    if (DBHelper.ENQ(sql))
                    {

                        MessageBox.Show("头像修改成功！");
                    }
                }
                catch (Exception)
                {

                }
                pictureBox1.Image = Image.FromFile(photoname);
            }
        }

        public void UsName()//显示用户信息
        {
            string cmdText = string.Format("select Name,Phone from Ustable where Uid='{0}' and Pwd='{1}'", Uid, Pwd);
            SqlDataReader dr = DBHelper.GDR(cmdText);
            while (dr.Read())
            {
              textBox1.Text = dr["Name"].ToString();
              textBox2.Text = dr["Phone"].ToString();
            }
            dr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <=10)
            {
                if (textBox2.Text.Length == 11)
                {
                    string Name = textBox1.Text;
                    string Phone = textBox2.Text;
                    string selectUs = string.Format("update Ustable set Name='{0}',Phone='{1}' where Uid={2} and Pwd='{3}'",Name,Phone, Uid, Pwd);
                    if (DBHelper.ENQ(selectUs))
                    {
                        MessageBox.Show("修改成功！", "修改资料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Modify_data modify_Data = new Modify_data();
                        User_side.user_Side.loadform(modify_Data);//刷新当前窗口
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                }
                else
                {
                    label2.Text = "请输入正确的11位手机号!";
                    label2.Visible = true;
                    textBox1.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
                    textBox2.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
                }
            }
            else
            {
                label2.Text = "用户名长度不能超过10!";
                label2.Visible = true;
                textBox1.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
                textBox2.GotFocus += new EventHandler((obj, ex) => { label1.Visible = false; });//成为焦点时把错误文本隐藏
            }
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            My_information my_Information = new My_information();
            User_side.user_Side.loadform(my_Information);
        }
    }
}

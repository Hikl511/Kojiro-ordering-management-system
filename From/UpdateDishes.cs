using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{
    public partial class UpdateDishes : Form
    {
        string Uid = Form1.form1.textBox1.Text;
        string Pwd = Form1.form1.textBox2.Text;
        string photoname = "";
        public string name1 = "";
        public UpdateDishes()
        {
            InitializeComponent();
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Business business = new Business();
            AdminUser_side.adminUser_Side.AdminLoadform(business);//返回商品界面
        }

        private void button3_Click(object sender, EventArgs e)
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

                        MessageBox.Show("图片修改成功！");
                        textBox2.Text = label7.Text;
                    }
                }
                catch (Exception)
                {

                }
                pictureBox1.Image = Image.FromFile(photoname);
            }
        }
        string ID = "";
        private void UpdateDishes_Load(object sender, EventArgs e)
        {
            name1 = textBox1.Text;
            try
            {
                //待完善
                string setDishes = string.Format("select Name,image,dumoney,DishesID from Dishes where Name='{0}'", Business.business.DishesName);
                SqlDataReader dr = DBHelper.GDR(setDishes);

                while (dr.Read())
                {
                    textBox1.Text = dr["Name"].ToString().Trim();
                    name1 = textBox1.Text;
                    label7.Text = dr["dumoney"].ToString().Substring(0, 5);
                    label7.Visible = true;
                    ID = dr["DishesID"].ToString();
                    photoname = dr["image"].ToString();
                }
                dr.Close();
                pictureBox1.Image = Image.FromFile(photoname);
            }
            catch (Exception)
            {

                //throw;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = textBox1.Text;
                double duMoney = double.Parse(textBox2.Text.ToString().Trim());
                string updaDis = $"update Dishes set Name='{Name}',image='{photoname}',dumoney={duMoney} where DishesID='{ID}' and Name='{name1}' ";
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    if (DBHelper.ENQ(updaDis))
                    {
                        MessageBox.Show("商品信息修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Business business = new Business();
                        AdminUser_side.adminUser_Side.AdminLoadform(business);//商家界面
                    }
                    else
                    {
                        MessageBox.Show("商品信息修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("请将信息填写完整!");
                }
            }
            catch (Exception)
            {

                //  throw;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string duMoney = textBox2.Text.ToString();
            string updaDis = string.Format("insert Dishes values('{0}','{1}','{2}','{3}')", textBox1.Text, photoname, duMoney, Ordering_food.ordering_Food.ClassID);
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (DBHelper.ENQ(updaDis))
                {
                    MessageBox.Show("商品信息添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Business business = new Business();
                    AdminUser_side.adminUser_Side.AdminLoadform(business);//商家界面
                }
                else
                {
                    MessageBox.Show("商品信息添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("请将信息填写完成!");
            }
        }
    }
}

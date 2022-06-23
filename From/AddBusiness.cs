using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Kojiro_ordering_management_system
{
    public partial class AddBusiness : Form
    {
        //xml文件再debug目录下
        XmlDocument doc = new XmlDocument();//定义一个XML的操作对象
        List<string> allprovince;//省份集合
        List<string> allcity;//城市集合
        List<string> allcounty;//县 区集合
        string BusinessImage = "";//选择的图片路径
        public AddBusiness()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Ordering_food ordering_Food = new Ordering_food();
            AdminUser_side.adminUser_Side.AdminLoadform(ordering_Food);
        }

        private void AddBusiness_Load(object sender, EventArgs e)
        {
            //进入窗口就加载
            doc.Load("province.xml");//加载XML文件  在debug目录下

            allprovince = getProvince(doc);//调用getProvinc方法 给省级下拉框 赋值所有省份及自治区

            allcity = getCity(doc, "广西壮族自治区");//调用getCityc方法 给市级下拉框 赋值这个省份的所有城市

            allcounty = getCounty(doc, "广西壮族自治区", "南宁市");

            comboBox_Pro.DataSource = allprovince;//省  赋值
            comboBox_City.DataSource = allcity;//市
            comboBox_Dist.DataSource = allcounty;//区
        }

        public static List<String> getProvince(XmlDocument doc)
        {
            List<String> provincelist = new List<string>();//创建泛型List集合
            XmlNode provinces = doc.SelectSingleNode("/root");//查询xml文件里root根节点
            foreach (XmlNode province1 in provinces.ChildNodes)//遍历所有provinces节点的值   //这里找的是省   provinces省份
            {
                provincelist.Add(province1.Attributes["name"].Value);//将属性添加到集合节点上面
            }
            return provincelist;
        }

        public static List<String> getCity(XmlDocument doc, String provincestr)//传入xml文档 和 provincestr集合
        {
            List<String> citylist = new List<string>();//创建泛型List集合
            //遍历xml文件里root根节点下的provinces子节点的city的值  city 城市
            string xpath = string.Format("/root/province[@name='{0}']/city", provincestr);//比如provincestr传的值是安徽省 这里查的就是 安徽省下的所有的city城市节点
            XmlNodeList cities = doc.SelectNodes(xpath);//选择匹配查询语句的节点列表。
            foreach (XmlNode city1 in cities)//遍历
            {
                citylist.Add(city1.Attributes["name"].Value);//将属性添加到集合节点上面
            }
            return citylist;
        }

        public static List<String> getCounty(XmlDocument doc, String provincestr, String citystr)
        {
            List<String> qulist = new List<string>();//创建泛型List集合
            //遍历xml文件里root根节点下的provinces子节点的city的子节点下district节点的值  district 县  区

            string xpath = string.Format("/root/province[@name='{0}']/city[@name='{1}']/district", provincestr, citystr);//比如provincestr传的值是安徽省 citystr穿的值是安庆市 
                                                                                                                         //这里查的就是安徽省安庆市下的所有区或县
            XmlNodeList area = doc.SelectNodes(xpath);//选择匹配查询语句的节点列表。
            foreach (XmlNode area1 in area)//遍历
            {
                qulist.Add(area1.Attributes["name"].Value);//将属性添加到集合节点上面
            }
            return qulist;
        }
        private void comboBox_Pro_SelectedIndexChanged(object sender, EventArgs e)
        {
            allcity = getCity(doc, this.comboBox_Pro.SelectedValue.ToString());//调用getCity方法 传入当前省份下拉框的值  这里方法传回的是 城市
            comboBox_City.DataSource = allcity;//给市 下拉框赋值
        }

        private void comboBox_City_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //调用getCity方法 传入省份下拉框的值和城市下拉框的值  这里传回的是 县 区
            allcounty = getCounty(doc, this.comboBox_Pro.SelectedValue.ToString(), this.comboBox_City.SelectedValue.ToString());
            comboBox_Dist.DataSource = allcounty; //给县 区 下拉框赋值
        }

        private void button2_Click(object sender, EventArgs e)//选择图片
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了图片
            {
                BusinessImage = openFileDialog1.FileName;
                pictureBox6.Image = Image.FromFile(BusinessImage);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BusinessImage!="")
            {
                if (textBox1.Text!="")//商家名字
                {
                    if (textBox2.Text!="")//电话
                    {
                        if (textBox4.Text!="")//介绍
                        {
                            string BussName = textBox1.Text;
                            string BussPhone = textBox2.Text;
                            string BussAddress = comboBox_Pro.Text + comboBox_City.Text + comboBox_Dist.Text + textBox3.Text;//商家地址拼接
                            string BussAddTime = DateTime.Now.ToString("yyyy-MM-dd");//获取时间  2022-02-03
                            string BussIntroduce = textBox4.Text;
                            string InsertBuss = string.Format("insert Business values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",BussName, BusinessImage, BussAddress,BussPhone, BussAddTime,BussIntroduce,0);
                            if (DBHelper.ENQ(InsertBuss))
                            {
                                MessageBox.Show("商家添加成功！", "添加商家", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            label2.Text = "请输入商家介绍！";
                            label2.Visible = true;
                        }
                    }
                    else
                    {
                        label2.Text = "请输入商家电话！";
                        label2.Visible = true;
                    }
                }
                else
                {
                    label2.Text = "请输入商家名字！";
                    label2.Visible = true;
                }
            }
            else
            {
                label2.Text = "请选择商家头像！";
                label2.Visible = true;
            }
        }
    }
}

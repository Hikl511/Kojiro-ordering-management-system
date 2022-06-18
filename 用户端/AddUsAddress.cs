using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Kojiro_ordering_management_system.用户端
{
    public partial class AddUsAddress : Form
    {
        public AddUsAddress()
        {
            InitializeComponent();
        }
        //xml文件再debug目录下
        XmlDocument doc = new XmlDocument();//定义一个XML的操作对象
        List<string> allprovince;//省份集合
        List<string> allcity;//城市集合
        List<string> allcounty;//县 区集合
        private void AddUsAddress_Load(object sender, EventArgs e)
        {
            //进入窗口就加载
            doc.Load("province.xml");//加载XML文件 

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

        private void comboBox_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            //调用getCity方法 传入省份下拉框的值和城市下拉框的值  这里传回的是 县 区
            allcounty = getCounty(doc, this.comboBox_Pro.SelectedValue.ToString(), this.comboBox_City.SelectedValue.ToString());
            comboBox_Dist.DataSource = allcounty; //给县 区 下拉框赋值

        }
    }
}

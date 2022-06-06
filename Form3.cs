using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kojiro_ordering_management_system
{
    public partial class Form3 : Form
    {

        private User_side User_Side = new User_side();
        private Ordering_food ordering_Food = new Ordering_food();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void loadform(object page)
        {
            //对panel里面的容器进行一个判定：如果容器里的空间数量大于0那么就清空容器里面的空间
            //为其腾出空间
            if (this.panel1.Controls.Count > 0)
            {
                this.panel1.Controls.Clear();
            }
            //判断传输进来的page类型是否是Form或其子类
            if (page is Form form)
            {
                //对画面的参数设置
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                //将容器的控件进行一个添加
                this.panel1.Controls.Add(form);
                //把容器的tag设置成我们传输进来的page
                this.panel1.Tag = form;
                //进行一个page的一个展示
                form.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadform(ordering_Food);
        }
    }
}

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
    public partial class Ordering_food : Form
    {
        public Ordering_food()
        {
            InitializeComponent();
        }

        private void Ordering_food_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            ShaXian shaXian = new ShaXian();
            shaXian.Show();
            
        }
    }
}

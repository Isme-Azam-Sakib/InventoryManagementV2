using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementV2
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void btn_menu_Click(object sender, EventArgs e)
        {

        }

        private void btn_mobile_Click(object sender, EventArgs e)
        {
            laptopCon1.Hide();
            mobileCon1.Show();
            salesCon1.Hide();
            gadgetCon1.Hide();
            mobileCon1.BringToFront();
        }

        private void btn_laptop_Click(object sender, EventArgs e)
        {
            mobileCon1.Hide();
            laptopCon1.Show();
            salesCon1.Hide();
            gadgetCon1.Hide();
            laptopCon1.BringToFront();
        }

        private void btn_accessories_Click(object sender, EventArgs e)
        {
            laptopCon1.Hide();
            salesCon1.Hide();
            mobileCon1.Hide();
            gadgetCon1.Show();
            gadgetCon1.BringToFront();
        }

        private void btn_bill_Click(object sender, EventArgs e)
        {
            gadgetCon1.Hide();
            laptopCon1.Hide();
            mobileCon1.Hide();
            salesCon1.Show();
            salesCon1.BringToFront();
        }
    }
}

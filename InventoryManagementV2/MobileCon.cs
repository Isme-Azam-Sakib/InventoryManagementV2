using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Collections;
using System.Xml.Linq;

namespace InventoryManagementV2
{
    public partial class MobileCon : UserControl
    {
        public MobileCon()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\SDP 200\InventoryManagementV2\InventoryManagementV2\inventory_db.mdf"";Integrated Security=True");

        private void populate()
        {
            Con.Open();
            string query = "SELECT * from mobile";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            mobile_dgv.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        /* clear button */
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            mcode.Text = "";
            mname.Text = "";
            mspec.Text = "";
            mprice.Text = "";
            mstock.Text = "";
        }



        /* Add button */
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (mcode.Text == "" || mname.Text == "" || mspec.Text == "" || mstock.Text == "" || mprice.Text == "")
            {
                MessageBox.Show("Missing Information :( ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "Insert Into Mobile values(" + mcode.Text + ", '" + mname.Text + "', '" + mspec.Text + "' , " + mprice.Text + ", " + mstock.Text + ")";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item added successfully :)");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

    
        private void MobileCon_Load(object sender, EventArgs e)
        {
            populate();
        }


        /* Update button */
        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (mcode.Text == "" || mname.Text == "" || mspec.Text == "" || mstock.Text == "" || mprice.Text == "")
            {
                MessageBox.Show("Missing Information :( ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "UPDATE mobile SET MobileName= '" + mname.Text + "', Specification='" + mspec.Text + "' , Price=" + mprice.Text + ", Stock=" + mstock.Text + " WHERE ProductCode=" + mcode.Text + " ; ";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Updated successfully :)");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        /* Delete button */
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (mcode.Text == "")
            {
                MessageBox.Show("Select the item to be deleted:");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "DELETE FROM mobile WHERE ProductCode=" + mcode.Text + " ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Deleted");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void mobile_dgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            mcode.Text = mobile_dgv.SelectedRows[0].Cells[0].Value.ToString();
            mname.Text = mobile_dgv.SelectedRows[0].Cells[1].Value.ToString();
            mspec.Text = mobile_dgv.SelectedRows[0].Cells[2].Value.ToString();
            mprice.Text = mobile_dgv.SelectedRows[0].Cells[3].Value.ToString();
            mstock.Text = mobile_dgv.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}

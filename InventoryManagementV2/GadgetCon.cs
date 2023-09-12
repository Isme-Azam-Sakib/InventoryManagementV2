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

namespace InventoryManagementV2
{
    public partial class GadgetCon : UserControl
    {
        public GadgetCon()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\SDP 200\InventoryManagementV2\InventoryManagementV2\inventory_db.mdf"";Integrated Security=True");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }




        /* clear button */
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            acode.Text = "";
            aname.Text = "";
            aspec.Text = "";
            aprice.Text = "";
            astock.Text = "";
        }


        /* delete button */
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (acode.Text == "")
            {
                MessageBox.Show("Select the item to be deleted:");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "DELETE FROM accessories WHERE ProductCode=" + acode.Text + " ";
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


        /* Update button */
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (acode.Text == "" || aname.Text == "" || aspec.Text == "" || astock.Text == "" || aprice.Text == "")
            {
                MessageBox.Show("Missing Information :( ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "UPDATE accessories SET AccessoriesName= '" + aname.Text + "', Specification='" + aspec.Text + "' , Price=" + aprice.Text + ", Stock=" + astock.Text + " WHERE ProductCode=" + acode.Text + " ; ";
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

        private void populate()
        {
            Con.Open();
            string query = "SELECT * from accessories";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            accessories_dgv.DataSource = ds.Tables[0];
            Con.Close();
        }

        /* Add button */
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (acode.Text == "" || aname.Text == "" || aspec.Text == "" || astock.Text == "" || aprice.Text == "")
            {
                MessageBox.Show("Missing Information :( ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "Insert Into accessories values(" + acode.Text + ", '" + aname.Text + "', '" + aspec.Text + "' , " + aprice.Text + ", " + astock.Text + ")";
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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            acode.Text = accessories_dgv.SelectedRows[0].Cells[0].Value.ToString();
            aname.Text = accessories_dgv.SelectedRows[0].Cells[1].Value.ToString();
            aspec.Text = accessories_dgv.SelectedRows[0].Cells[2].Value.ToString();
            aprice.Text = accessories_dgv.SelectedRows[0].Cells[3].Value.ToString();
            astock.Text = accessories_dgv.SelectedRows[0].Cells[4].Value.ToString();
        }


        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void GadgetCon_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}

using System;
using System.Collections;
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
using System.Xml.Linq;

namespace InventoryManagementV2
{
    public partial class LaptopCon : UserControl
    {
        public LaptopCon()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\SDP 200\InventoryManagementV2\InventoryManagementV2\inventory_db.mdf"";Integrated Security=True");

        private void populate()
        {
            Con.Open();
            string query = "SELECT * from laptop";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            laptop_dgv.DataSource = ds.Tables[0];
            Con.Close();
        }

        /* Add button */
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (lcode.Text == "" || lname.Text == "" || lspec.Text == "" || lstock.Text == "" || lprice.Text == "")
            {
                MessageBox.Show("Missing Information :( ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "Insert Into laptop values(" + lcode.Text + ", '" + lname.Text + "', '" + lspec.Text + "' , " + lprice.Text + ", " + lstock.Text + ")";
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


        /* Update button */
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (lcode.Text == "" || lname.Text == "" || lspec.Text == "" || lstock.Text == "" || lprice.Text == "")
            {
                MessageBox.Show("Missing Information :( ");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "UPDATE laptop SET LaptopName= '" + lname.Text + "', Specification='" + lspec.Text + "' , Price=" + lprice.Text + ", Stock=" + lstock.Text + " WHERE ProductCode=" + lcode.Text + " ; ";
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

        private void laptop_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lcode.Text = laptop_dgv.SelectedRows[0].Cells[0].Value.ToString();
            lname.Text = laptop_dgv.SelectedRows[0].Cells[1].Value.ToString();
            lspec.Text = laptop_dgv.SelectedRows[0].Cells[2].Value.ToString();
            lprice.Text = laptop_dgv.SelectedRows[0].Cells[3].Value.ToString();
            lstock.Text = laptop_dgv.SelectedRows[0].Cells[4].Value.ToString();
        }

        /* Clear button */
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            lcode.Text = "";
            lname.Text = "";
            lspec.Text = "";
            lprice.Text = "";
            lstock.Text = "";
        }


        /* Delete button*/
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (lcode.Text == "")
            {
                MessageBox.Show("Select the item to be deleted:");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "DELETE FROM laptop WHERE ProductCode=" + lcode.Text + " ";
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

        private void LaptopCon_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}

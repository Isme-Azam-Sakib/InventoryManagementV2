using InventoryManagementV2;

namespace Inventory_Management_System
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        int startpos = 15;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 3;
            progressBar1.Value = startpos;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                Home home = new Home();
                home.Show();
                this.Hide();
            }
        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
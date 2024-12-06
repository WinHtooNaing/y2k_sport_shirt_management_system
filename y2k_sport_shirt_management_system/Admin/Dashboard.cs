using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace y2k_sport_shirt_management_system.Admin
{
    public partial class Dashboard : Form
    {
        private string _userName;
        public Dashboard(string userName)
        {
            InitializeComponent();
            _userName = userName;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            admin_name.Text = _userName;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

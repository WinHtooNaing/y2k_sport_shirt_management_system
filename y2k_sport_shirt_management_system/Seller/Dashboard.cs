using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace y2k_sport_shirt_management_system.Seller
{
    public partial class Dashboard : Form
    {
        private string _username;
        public Dashboard(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            seller_name.Text = _username;
        }
    }
}

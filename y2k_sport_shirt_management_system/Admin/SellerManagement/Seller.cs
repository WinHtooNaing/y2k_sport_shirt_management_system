using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using y2k_sport_shirt_management_system.Model;
using y2k_sport_shirt_management_system.Repository;

namespace y2k_sport_shirt_management_system.Admin.SellerManagement
{
    public partial class Seller : Form
    {
        private readonly SellerRepository sellerRepository;
        private readonly DatabaseConnection dbConnection;
        public Seller()
        {
            InitializeComponent();
            sellerRepository = new SellerRepository();
            dbConnection = new DatabaseConnection();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
            this.Hide();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void admin_name_Click(object sender, EventArgs e)
        {

        }

        private void Seller_Load(object sender, EventArgs e)
        {
            admin_name.Text = SessionStorage.Session.userName;
            LoadUserIntoGrid();
        }
        private void LoadUserIntoGrid()
        {
            try
            {
                var sellers = sellerRepository.GetAllSellers();
                sellersGridView.DataSource = sellers;
                if (!sellersGridView.Columns.Contains("No"))
                {
                    DataGridViewTextBoxColumn noColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "No",
                        HeaderText = "No",
                        ReadOnly = true
                    };
                    sellersGridView.Columns.Insert(0, noColumn);
                }
                if (!sellersGridView.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
                    {
                        Name = "Edit",
                        HeaderText = "",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true
                    };

                    sellersGridView.Columns.Add(editColumn);
                    editColumn.DefaultCellStyle.BackColor = Color.Orange;
                    editColumn.DefaultCellStyle.ForeColor = Color.White;
                }
                if (!sellersGridView.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    sellersGridView.Columns.Add(deleteColumn);
                    deleteColumn.DefaultCellStyle.BackColor = Color.Red;
                    deleteColumn.DefaultCellStyle.ForeColor = Color.White;
                }

                for (int i = 0; i < sellersGridView.Rows.Count; i++)
                {
                    sellersGridView.Rows[i].Cells["No"].Value = i + 1;
                }
                // Customize the DataGridView
                sellersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Hide the "Id" column
                if (sellersGridView.Columns.Contains("Id"))
                {
                    sellersGridView.Columns["Id"].Visible = false; // Hide the ID column
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void sellersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked cell is a button
            if (e.RowIndex >= 0 && (e.ColumnIndex == sellersGridView.Columns["Edit"].Index || e.ColumnIndex == sellersGridView.Columns["Delete"].Index))
            {
                // Get the selected product's ID
                int productId = Convert.ToInt32(sellersGridView.Rows[e.RowIndex].Cells["Id"].Value);

                if (e.ColumnIndex == sellersGridView.Columns["Edit"].Index)
                {
                    // Edit button clicked
                    EditSeller(productId);
                }
                else if (e.ColumnIndex == sellersGridView.Columns["Delete"].Index)
                {
                    // Delete button clicked
                    DeleteSeller(productId);
                }
            }
        }
        private void EditSeller(int productId)
        {
            EditSeller seller = new EditSeller(productId);
            seller.Show();
            this.Hide();
        }
        private void DeleteSeller(int productId)
        {
            
            if (sellerRepository.DeleteSeller(productId)) { 
                MessageBox.Show("Seller deleted successfully", "Seller Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserIntoGrid();
            }
            else
            {
                MessageBox.Show("Seller deleted fail","Seller Delete",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            CreateSeller seller = new CreateSeller();
            seller.Show();
        }
    }
}

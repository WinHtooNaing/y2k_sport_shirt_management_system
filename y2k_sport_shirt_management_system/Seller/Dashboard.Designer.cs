namespace y2k_sport_shirt_management_system.Seller
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            panel2 = new Panel();
            seller_name = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            iconButton6 = new FontAwesome.Sharp.IconButton();
            productsGridView = new DataGridView();
            clearBtn = new Button();
            serachBtn = new Button();
            searchTxt = new TextBox();
            fakeProductsGridView = new DataGridView();
            cancleBtn = new Button();
            sellBtn = new Button();
            label1 = new Label();
            totalPriceTxt = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fakeProductsGridView).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.RoyalBlue;
            panel2.Controls.Add(seller_name);
            panel2.Controls.Add(iconButton1);
            panel2.Location = new Point(278, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(929, 54);
            panel2.TabIndex = 4;
            // 
            // seller_name
            // 
            seller_name.AutoSize = true;
            seller_name.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            seller_name.ForeColor = Color.White;
            seller_name.Location = new Point(736, 19);
            seller_name.Name = "seller_name";
            seller_name.Size = new Size(81, 22);
            seller_name.TabIndex = 3;
            seller_name.Text = "Hi Seller";
            // 
            // iconButton1
            // 
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            iconButton1.ForeColor = Color.White;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.User;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(887, 11);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(30, 30);
            iconButton1.TabIndex = 0;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(280, 54);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint_1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(280, 53);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // iconButton6
            // 
            iconButton6.FlatStyle = FlatStyle.Flat;
            iconButton6.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton6.ForeColor = Color.Crimson;
            iconButton6.IconChar = FontAwesome.Sharp.IconChar.Lock;
            iconButton6.IconColor = Color.Crimson;
            iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton6.IconSize = 40;
            iconButton6.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton6.Location = new Point(12, 563);
            iconButton6.Name = "iconButton6";
            iconButton6.Size = new Size(160, 49);
            iconButton6.TabIndex = 7;
            iconButton6.Text = "Logout";
            iconButton6.UseVisualStyleBackColor = true;
            iconButton6.Click += iconButton6_Click;
            // 
            // productsGridView
            // 
            productsGridView.BackgroundColor = Color.White;
            productsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productsGridView.Location = new Point(12, 118);
            productsGridView.Name = "productsGridView";
            productsGridView.Size = new Size(788, 381);
            productsGridView.TabIndex = 14;
            productsGridView.CellContentClick += productsGridView_CellContentClick;
            // 
            // clearBtn
            // 
            clearBtn.BackColor = Color.Crimson;
            clearBtn.Cursor = Cursors.Hand;
            clearBtn.FlatAppearance.BorderSize = 0;
            clearBtn.FlatStyle = FlatStyle.Flat;
            clearBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clearBtn.ForeColor = Color.White;
            clearBtn.Location = new Point(711, 69);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(87, 42);
            clearBtn.TabIndex = 17;
            clearBtn.Text = "clear";
            clearBtn.UseVisualStyleBackColor = false;
            clearBtn.Click += clearBtn_Click;
            // 
            // serachBtn
            // 
            serachBtn.BackColor = Color.RoyalBlue;
            serachBtn.Cursor = Cursors.Hand;
            serachBtn.FlatAppearance.BorderSize = 0;
            serachBtn.FlatStyle = FlatStyle.Flat;
            serachBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serachBtn.ForeColor = Color.White;
            serachBtn.Location = new Point(618, 69);
            serachBtn.Name = "serachBtn";
            serachBtn.Size = new Size(87, 42);
            serachBtn.TabIndex = 16;
            serachBtn.Text = "Search";
            serachBtn.UseVisualStyleBackColor = false;
            serachBtn.Click += serachBtn_Click;
            // 
            // searchTxt
            // 
            searchTxt.Location = new Point(406, 70);
            searchTxt.Multiline = true;
            searchTxt.Name = "searchTxt";
            searchTxt.Size = new Size(206, 42);
            searchTxt.TabIndex = 15;
            // 
            // fakeProductsGridView
            // 
            fakeProductsGridView.BackgroundColor = Color.White;
            fakeProductsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            fakeProductsGridView.Location = new Point(818, 118);
            fakeProductsGridView.Name = "fakeProductsGridView";
            fakeProductsGridView.Size = new Size(377, 381);
            fakeProductsGridView.TabIndex = 18;
            fakeProductsGridView.CellContentClick += fakeProductsGridView_CellContentClick;
            // 
            // cancleBtn
            // 
            cancleBtn.BackColor = Color.Crimson;
            cancleBtn.Cursor = Cursors.Hand;
            cancleBtn.FlatAppearance.BorderSize = 0;
            cancleBtn.FlatStyle = FlatStyle.Flat;
            cancleBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancleBtn.ForeColor = Color.White;
            cancleBtn.Location = new Point(1008, 563);
            cancleBtn.Name = "cancleBtn";
            cancleBtn.Size = new Size(87, 42);
            cancleBtn.TabIndex = 19;
            cancleBtn.Text = "Cancle";
            cancleBtn.UseVisualStyleBackColor = false;
            cancleBtn.Click += cancleBtn_Click;
            // 
            // sellBtn
            // 
            sellBtn.BackColor = Color.RoyalBlue;
            sellBtn.Cursor = Cursors.Hand;
            sellBtn.FlatAppearance.BorderSize = 0;
            sellBtn.FlatStyle = FlatStyle.Flat;
            sellBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sellBtn.ForeColor = Color.White;
            sellBtn.Location = new Point(1108, 563);
            sellBtn.Name = "sellBtn";
            sellBtn.Size = new Size(87, 42);
            sellBtn.TabIndex = 20;
            sellBtn.Text = "Sell";
            sellBtn.UseVisualStyleBackColor = false;
            sellBtn.Click += sellBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(973, 523);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 21;
            label1.Text = "Total Price  -";
            // 
            // totalPriceTxt
            // 
            totalPriceTxt.AutoSize = true;
            totalPriceTxt.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalPriceTxt.ForeColor = Color.RoyalBlue;
            totalPriceTxt.Location = new Point(1054, 516);
            totalPriceTxt.Name = "totalPriceTxt";
            totalPriceTxt.Size = new Size(50, 22);
            totalPriceTxt.TabIndex = 22;
            totalPriceTxt.Text = "1000";
            totalPriceTxt.Click += totalPriceTxt_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1207, 648);
            Controls.Add(totalPriceTxt);
            Controls.Add(label1);
            Controls.Add(sellBtn);
            Controls.Add(cancleBtn);
            Controls.Add(fakeProductsGridView);
            Controls.Add(clearBtn);
            Controls.Add(serachBtn);
            Controls.Add(searchTxt);
            Controls.Add(productsGridView);
            Controls.Add(iconButton6);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)productsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)fakeProductsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private Label seller_name;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton6;
        private PictureBox pictureBox1;
        private DataGridView productsGridView;
        private Button clearBtn;
        private Button serachBtn;
        private TextBox searchTxt;
        private DataGridView fakeProductsGridView;
        private Button cancleBtn;
        private Button sellBtn;
        private Label label1;
        private Label totalPriceTxt;
    }
}
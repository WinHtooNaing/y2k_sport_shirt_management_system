namespace y2k_sport_shirt_management_system.Admin
{
    partial class EditProduct
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
            label5 = new Label();
            qtyTxt = new TextBox();
            label4 = new Label();
            priceTxt = new TextBox();
            label3 = new Label();
            loginBtn = new Button();
            nameTxt = new TextBox();
            label2 = new Label();
            label1 = new Label();
            categoryTxt = new ComboBox();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.RoyalBlue;
            label5.Location = new Point(130, 368);
            label5.Name = "label5";
            label5.Size = new Size(121, 19);
            label5.TabIndex = 30;
            label5.Text = "product category";
            // 
            // qtyTxt
            // 
            qtyTxt.BackColor = Color.White;
            qtyTxt.BorderStyle = BorderStyle.FixedSingle;
            qtyTxt.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            qtyTxt.ForeColor = Color.RoyalBlue;
            qtyTxt.Location = new Point(130, 307);
            qtyTxt.Multiline = true;
            qtyTxt.Name = "qtyTxt";
            qtyTxt.Size = new Size(232, 40);
            qtyTxt.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.RoyalBlue;
            label4.Location = new Point(130, 276);
            label4.Name = "label4";
            label4.Size = new Size(117, 19);
            label4.TabIndex = 28;
            label4.Text = "product quantity";
            // 
            // priceTxt
            // 
            priceTxt.BackColor = Color.White;
            priceTxt.BorderStyle = BorderStyle.FixedSingle;
            priceTxt.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            priceTxt.ForeColor = Color.RoyalBlue;
            priceTxt.Location = new Point(130, 217);
            priceTxt.Multiline = true;
            priceTxt.Name = "priceTxt";
            priceTxt.Size = new Size(232, 40);
            priceTxt.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.RoyalBlue;
            label3.Location = new Point(130, 184);
            label3.Name = "label3";
            label3.Size = new Size(96, 19);
            label3.TabIndex = 26;
            label3.Text = "product price";
            // 
            // loginBtn
            // 
            loginBtn.BackColor = Color.RoyalBlue;
            loginBtn.Cursor = Cursors.Hand;
            loginBtn.FlatAppearance.BorderColor = Color.RoyalBlue;
            loginBtn.FlatAppearance.BorderSize = 0;
            loginBtn.FlatStyle = FlatStyle.Flat;
            loginBtn.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginBtn.ForeColor = Color.White;
            loginBtn.Location = new Point(130, 459);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(232, 45);
            loginBtn.TabIndex = 25;
            loginBtn.Text = "Edit";
            loginBtn.UseVisualStyleBackColor = false;
            loginBtn.Click += loginBtn_Click;
            // 
            // nameTxt
            // 
            nameTxt.BackColor = Color.White;
            nameTxt.BorderStyle = BorderStyle.FixedSingle;
            nameTxt.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameTxt.ForeColor = Color.RoyalBlue;
            nameTxt.Location = new Point(130, 128);
            nameTxt.Multiline = true;
            nameTxt.Name = "nameTxt";
            nameTxt.Size = new Size(232, 40);
            nameTxt.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.RoyalBlue;
            label2.Location = new Point(130, 95);
            label2.Name = "label2";
            label2.Size = new Size(99, 19);
            label2.TabIndex = 23;
            label2.Text = "product name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20F, FontStyle.Bold);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(158, 22);
            label1.Name = "label1";
            label1.Size = new Size(165, 31);
            label1.TabIndex = 22;
            label1.Text = "Edit Product";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // categoryTxt
            // 
            categoryTxt.FormattingEnabled = true;
            categoryTxt.Items.AddRange(new object[] { "XL", "L", "M" });
            categoryTxt.Location = new Point(130, 406);
            categoryTxt.Name = "categoryTxt";
            categoryTxt.Size = new Size(232, 23);
            categoryTxt.TabIndex = 31;
            // 
            // EditProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(493, 527);
            Controls.Add(categoryTxt);
            Controls.Add(label5);
            Controls.Add(qtyTxt);
            Controls.Add(label4);
            Controls.Add(priceTxt);
            Controls.Add(label3);
            Controls.Add(loginBtn);
            Controls.Add(nameTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditProduct";
            Load += EditProduct_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private TextBox qtyTxt;
        private Label label4;
        private TextBox priceTxt;
        private Label label3;
        private Button loginBtn;
        private TextBox nameTxt;
        private Label label2;
        private Label label1;
        private ComboBox categoryTxt;
    }
}
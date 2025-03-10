﻿namespace y2k_sport_shirt_management_system.Admin
{
    partial class CreateProduct
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
            components = new System.ComponentModel.Container();
            loginBtn = new Button();
            nameTxt = new TextBox();
            label2 = new Label();
            label1 = new Label();
            priceTxt = new TextBox();
            label3 = new Label();
            qtyTxt = new TextBox();
            label4 = new Label();
            label5 = new Label();
            productBindingSource = new BindingSource(components);
            sizeTxt = new ComboBox();
            label6 = new Label();
            categoryTxt = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            SuspendLayout();
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
            loginBtn.Location = new Point(138, 532);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(232, 45);
            loginBtn.TabIndex = 14;
            loginBtn.Text = "Add";
            loginBtn.UseVisualStyleBackColor = false;
            loginBtn.Click += loginBtn_Click;
            // 
            // nameTxt
            // 
            nameTxt.BackColor = Color.White;
            nameTxt.BorderStyle = BorderStyle.FixedSingle;
            nameTxt.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameTxt.ForeColor = Color.RoyalBlue;
            nameTxt.Location = new Point(135, 128);
            nameTxt.Multiline = true;
            nameTxt.Name = "nameTxt";
            nameTxt.Size = new Size(232, 40);
            nameTxt.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.RoyalBlue;
            label2.Location = new Point(135, 95);
            label2.Name = "label2";
            label2.Size = new Size(99, 19);
            label2.TabIndex = 9;
            label2.Text = "product name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20F, FontStyle.Bold);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(163, 22);
            label1.Name = "label1";
            label1.Size = new Size(164, 31);
            label1.TabIndex = 8;
            label1.Text = "Add Product";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // priceTxt
            // 
            priceTxt.BackColor = Color.White;
            priceTxt.BorderStyle = BorderStyle.FixedSingle;
            priceTxt.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            priceTxt.ForeColor = Color.RoyalBlue;
            priceTxt.Location = new Point(138, 290);
            priceTxt.Multiline = true;
            priceTxt.Name = "priceTxt";
            priceTxt.Size = new Size(232, 40);
            priceTxt.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.RoyalBlue;
            label3.Location = new Point(138, 257);
            label3.Name = "label3";
            label3.Size = new Size(96, 19);
            label3.TabIndex = 15;
            label3.Text = "product price";
            // 
            // qtyTxt
            // 
            qtyTxt.BackColor = Color.White;
            qtyTxt.BorderStyle = BorderStyle.FixedSingle;
            qtyTxt.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            qtyTxt.ForeColor = Color.RoyalBlue;
            qtyTxt.Location = new Point(138, 380);
            qtyTxt.Multiline = true;
            qtyTxt.Name = "qtyTxt";
            qtyTxt.Size = new Size(232, 40);
            qtyTxt.TabIndex = 18;
            qtyTxt.TextChanged += textBox2_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.RoyalBlue;
            label4.Location = new Point(138, 349);
            label4.Name = "label4";
            label4.Size = new Size(117, 19);
            label4.TabIndex = 17;
            label4.Text = "product quantity";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.RoyalBlue;
            label5.Location = new Point(138, 441);
            label5.Name = "label5";
            label5.Size = new Size(88, 19);
            label5.TabIndex = 20;
            label5.Text = "product size";
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Model.Product);
            // 
            // sizeTxt
            // 
            sizeTxt.FormattingEnabled = true;
            sizeTxt.Items.AddRange(new object[] { "XL", "L", "M" });
            sizeTxt.Location = new Point(138, 485);
            sizeTxt.Name = "sizeTxt";
            sizeTxt.Size = new Size(232, 23);
            sizeTxt.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.RoyalBlue;
            label6.Location = new Point(135, 181);
            label6.Name = "label6";
            label6.Size = new Size(126, 19);
            label6.TabIndex = 22;
            label6.Text = "Product Category";
            // 
            // categoryTxt
            // 
            categoryTxt.FormattingEnabled = true;
            categoryTxt.Items.AddRange(new object[] { "Home", "Away" });
            categoryTxt.Location = new Point(138, 217);
            categoryTxt.Name = "categoryTxt";
            categoryTxt.Size = new Size(232, 23);
            categoryTxt.TabIndex = 24;
            // 
            // CreateProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(498, 597);
            Controls.Add(categoryTxt);
            Controls.Add(label6);
            Controls.Add(sizeTxt);
            Controls.Add(label5);
            Controls.Add(qtyTxt);
            Controls.Add(label4);
            Controls.Add(priceTxt);
            Controls.Add(label3);
            Controls.Add(loginBtn);
            Controls.Add(nameTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateProduct";
            Load += CreateProduct_Load;
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginBtn;
        private TextBox nameTxt;
        private Label label2;
        private Label label1;
        private TextBox priceTxt;
        private Label label3;
        private TextBox qtyTxt;
        private Label label4;
        private Label label5;
        private BindingSource productBindingSource;
        private ComboBox sizeTxt;
        private Label label6;
        private ComboBox categoryTxt;
    }
}
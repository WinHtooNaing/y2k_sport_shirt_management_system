namespace y2k_sport_shirt_management_system.Admin.SellerManagement
{
    partial class CreateSeller
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
            passwordTxt = new TextBox();
            label4 = new Label();
            accountIdTxt = new TextBox();
            label3 = new Label();
            loginBtn = new Button();
            nameTxt = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // passwordTxt
            // 
            passwordTxt.BackColor = Color.White;
            passwordTxt.BorderStyle = BorderStyle.FixedSingle;
            passwordTxt.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordTxt.ForeColor = Color.RoyalBlue;
            passwordTxt.Location = new Point(130, 307);
            passwordTxt.Multiline = true;
            passwordTxt.Name = "passwordTxt";
            passwordTxt.Size = new Size(232, 40);
            passwordTxt.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.RoyalBlue;
            label4.Location = new Point(130, 276);
            label4.Name = "label4";
            label4.Size = new Size(112, 19);
            label4.TabIndex = 28;
            label4.Text = "seller password";
            // 
            // accountIdTxt
            // 
            accountIdTxt.BackColor = Color.White;
            accountIdTxt.BorderStyle = BorderStyle.FixedSingle;
            accountIdTxt.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accountIdTxt.ForeColor = Color.RoyalBlue;
            accountIdTxt.Location = new Point(130, 217);
            accountIdTxt.Multiline = true;
            accountIdTxt.Name = "accountIdTxt";
            accountIdTxt.Size = new Size(232, 40);
            accountIdTxt.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.RoyalBlue;
            label3.Location = new Point(130, 184);
            label3.Name = "label3";
            label3.Size = new Size(119, 19);
            label3.TabIndex = 26;
            label3.Text = "seller account Id";
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
            loginBtn.Location = new Point(130, 381);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(232, 45);
            loginBtn.TabIndex = 25;
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
            label2.Size = new Size(86, 19);
            label2.TabIndex = 23;
            label2.Text = "seller name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20F, FontStyle.Bold);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(172, 22);
            label1.Name = "label1";
            label1.Size = new Size(137, 31);
            label1.TabIndex = 22;
            label1.Text = "Add Seller";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // CreateSeller
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(493, 527);
            Controls.Add(passwordTxt);
            Controls.Add(label4);
            Controls.Add(accountIdTxt);
            Controls.Add(label3);
            Controls.Add(loginBtn);
            Controls.Add(nameTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateSeller";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateSeller";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordTxt;
        private Label label4;
        private TextBox accountIdTxt;
        private Label label3;
        private Button loginBtn;
        private TextBox nameTxt;
        private Label label2;
        private Label label1;
    }
}
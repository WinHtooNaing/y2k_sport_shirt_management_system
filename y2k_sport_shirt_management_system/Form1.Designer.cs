namespace y2k_sport_shirt_management_system
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            linkLabel1 = new LinkLabel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            panel2 = new Panel();
            linkLabel2 = new LinkLabel();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(234, 54);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(348, 88);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(iconButton1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(80, 198);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 154);
            panel1.TabIndex = 1;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.RoyalBlue;
            linkLabel1.Location = new Point(93, 124);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(65, 15);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Login Here";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // iconButton1
            // 
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.User;
            iconButton1.IconColor = Color.RoyalBlue;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(93, 22);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(75, 51);
            iconButton1.TabIndex = 1;
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(84, 76);
            label1.Name = "label1";
            label1.Size = new Size(93, 31);
            label1.TabIndex = 0;
            label1.Text = "Admin";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BackgroundImageLayout = ImageLayout.None;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(linkLabel2);
            panel2.Controls.Add(iconButton2);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(453, 198);
            panel2.Name = "panel2";
            panel2.Size = new Size(259, 154);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.LinkColor = Color.RoyalBlue;
            linkLabel2.Location = new Point(103, 124);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(65, 15);
            linkLabel2.TabIndex = 5;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Login Here";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked_1;
            // 
            // iconButton2
            // 
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.Users;
            iconButton2.IconColor = Color.RoyalBlue;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.Location = new Point(93, 22);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(75, 51);
            iconButton2.TabIndex = 1;
            iconButton2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(84, 76);
            label2.Name = "label2";
            label2.Size = new Size(106, 31);
            label2.TabIndex = 0;
            label2.Text = "Cashier";
            // 
            // iconButton3
            // 
            iconButton3.Cursor = Cursors.Hand;
            iconButton3.FlatAppearance.BorderColor = Color.Black;
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.Font = new Font("Segoe UI", 5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.Close;
            iconButton3.IconColor = Color.RoyalBlue;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.Location = new Point(749, 2);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(53, 42);
            iconButton3.TabIndex = 3;
            iconButton3.UseVisualStyleBackColor = true;
            iconButton3.Click += iconButton3_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(iconButton3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            ForeColor = Color.RoyalBlue;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Label label2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
    }
}

namespace _01_DiyetProjesi.UI
{
    partial class Form1
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
            groupBox1 = new GroupBox();
            cbBeniHatirla = new CheckBox();
            cbSifreGor = new CheckBox();
            btnGiris = new Button();
            label2 = new Label();
            label1 = new Label();
            tbEmail = new TextBox();
            tbSifre = new TextBox();
            btnUyeOl = new Button();
            lblTutucu = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbBeniHatirla);
            groupBox1.Controls.Add(cbSifreGor);
            groupBox1.Controls.Add(btnGiris);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tbEmail);
            groupBox1.Controls.Add(tbSifre);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(429, 230);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giriş Ekranı";
            // 
            // cbBeniHatirla
            // 
            cbBeniHatirla.AutoSize = true;
            cbBeniHatirla.Location = new Point(268, 116);
            cbBeniHatirla.Name = "cbBeniHatirla";
            cbBeniHatirla.Size = new Size(109, 24);
            cbBeniHatirla.TabIndex = 4;
            cbBeniHatirla.Text = "Beni Hatırla";
            cbBeniHatirla.UseVisualStyleBackColor = true;
            // 
            // cbSifreGor
            // 
            cbSifreGor.AutoSize = true;
            cbSifreGor.Location = new Point(153, 116);
            cbSifreGor.Name = "cbSifreGor";
            cbSifreGor.Size = new Size(100, 24);
            cbSifreGor.TabIndex = 3;
            cbSifreGor.Text = "Şifreyi Gör";
            cbSifreGor.UseVisualStyleBackColor = true;
            cbSifreGor.CheckedChanged += cbSifreGor_CheckedChanged;
            // 
            // btnGiris
            // 
            btnGiris.Location = new Point(153, 157);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(157, 51);
            btnGiris.TabIndex = 2;
            btnGiris.Text = "Giriş";
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += btnGiris_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 83);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 1;
            label2.Text = "Şifre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 40);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 1;
            label1.Text = "Email:";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(153, 40);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(250, 27);
            tbEmail.TabIndex = 0;
            // 
            // tbSifre
            // 
            tbSifre.Location = new Point(153, 83);
            tbSifre.Name = "tbSifre";
            tbSifre.PasswordChar = '*';
            tbSifre.Size = new Size(250, 27);
            tbSifre.TabIndex = 0;
            // 
            // btnUyeOl
            // 
            btnUyeOl.Location = new Point(139, 267);
            btnUyeOl.Name = "btnUyeOl";
            btnUyeOl.Size = new Size(171, 47);
            btnUyeOl.TabIndex = 1;
            btnUyeOl.Text = "Üye Ol";
            btnUyeOl.UseVisualStyleBackColor = true;
            btnUyeOl.Click += btnUyeOl_Click;
            // 
            // lblTutucu
            // 
            lblTutucu.AutoSize = true;
            lblTutucu.Location = new Point(408, 294);
            lblTutucu.Margin = new Padding(1, 0, 1, 0);
            lblTutucu.Name = "lblTutucu";
            lblTutucu.Size = new Size(0, 20);
            lblTutucu.TabIndex = 2;
            lblTutucu.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 332);
            Controls.Add(lblTutucu);
            Controls.Add(btnUyeOl);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Sağlıklı Yaşam";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnGiris;
        private Label label2;
        private Label label1;
        private TextBox tbEmail;
        private TextBox tbSifre;
        private CheckBox cbBeniHatirla;
        private CheckBox cbSifreGor;
        private Button btnUyeOl;
        private Label lblTutucu;
    }
}

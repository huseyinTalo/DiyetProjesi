namespace _01_DiyetProjesi.UI
{
    partial class Form2
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
            groupBox1 = new GroupBox();
            cbSifreGor = new CheckBox();
            btnUyeOl = new Button();
            dtpDogum = new DateTimePicker();
            cbCinsiyet = new ComboBox();
            label9 = new Label();
            label1 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tbSoyisim = new TextBox();
            tbEmail = new TextBox();
            tbBoy = new TextBox();
            tbMevcutKilo = new TextBox();
            tbHedefKilo = new TextBox();
            tbIsim = new TextBox();
            tbSifre = new TextBox();
            btnGirisDon = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbSifreGor);
            groupBox1.Controls.Add(btnUyeOl);
            groupBox1.Controls.Add(dtpDogum);
            groupBox1.Controls.Add(cbCinsiyet);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbSoyisim);
            groupBox1.Controls.Add(tbEmail);
            groupBox1.Controls.Add(tbBoy);
            groupBox1.Controls.Add(tbMevcutKilo);
            groupBox1.Controls.Add(tbHedefKilo);
            groupBox1.Controls.Add(tbIsim);
            groupBox1.Controls.Add(tbSifre);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(437, 582);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Üye ol";
            // 
            // cbSifreGor
            // 
            cbSifreGor.AutoSize = true;
            cbSifreGor.Location = new Point(145, 107);
            cbSifreGor.Margin = new Padding(1);
            cbSifreGor.Name = "cbSifreGor";
            cbSifreGor.Size = new Size(106, 24);
            cbSifreGor.TabIndex = 10;
            cbSifreGor.Text = "Şifremi Gör";
            cbSifreGor.UseVisualStyleBackColor = true;
            cbSifreGor.CheckedChanged += cbSifreGor_CheckedChanged;
            // 
            // btnUyeOl
            // 
            btnUyeOl.Location = new Point(16, 497);
            btnUyeOl.Name = "btnUyeOl";
            btnUyeOl.Size = new Size(389, 47);
            btnUyeOl.TabIndex = 9;
            btnUyeOl.Text = "Üyeliği Tamamla";
            btnUyeOl.UseVisualStyleBackColor = true;
            btnUyeOl.Click += btnUyeOl_Click;
            // 
            // dtpDogum
            // 
            dtpDogum.Location = new Point(145, 411);
            dtpDogum.Name = "dtpDogum";
            dtpDogum.Size = new Size(260, 27);
            dtpDogum.TabIndex = 8;
            // 
            // cbCinsiyet
            // 
            cbCinsiyet.FormattingEnabled = true;
            cbCinsiyet.Location = new Point(145, 361);
            cbCinsiyet.Name = "cbCinsiyet";
            cbCinsiyet.Size = new Size(260, 28);
            cbCinsiyet.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 35);
            label9.Name = "label9";
            label9.Size = new Size(49, 20);
            label9.TabIndex = 1;
            label9.Text = "Email:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 411);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 1;
            label1.Text = "Doğum Tarihi:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 361);
            label8.Name = "label8";
            label8.Size = new Size(63, 20);
            label8.TabIndex = 1;
            label8.Text = "Cinsiyet:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 316);
            label7.Name = "label7";
            label7.Size = new Size(67, 20);
            label7.TabIndex = 1;
            label7.Text = "Boy(cm):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 274);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 1;
            label6.Text = "Mevcut Kilo(kg):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 230);
            label5.Name = "label5";
            label5.Size = new Size(109, 20);
            label5.TabIndex = 1;
            label5.Text = "Hedef Kilo(kg):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 185);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 1;
            label4.Text = "Soyisim:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 140);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 1;
            label3.Text = "İsim:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 73);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 1;
            label2.Text = "Şifre:";
            // 
            // tbSoyisim
            // 
            tbSoyisim.Location = new Point(145, 185);
            tbSoyisim.Name = "tbSoyisim";
            tbSoyisim.Size = new Size(260, 27);
            tbSoyisim.TabIndex = 3;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(145, 28);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(260, 27);
            tbEmail.TabIndex = 0;
            // 
            // tbBoy
            // 
            tbBoy.Location = new Point(145, 316);
            tbBoy.Name = "tbBoy";
            tbBoy.Size = new Size(260, 27);
            tbBoy.TabIndex = 6;
            // 
            // tbMevcutKilo
            // 
            tbMevcutKilo.Location = new Point(145, 274);
            tbMevcutKilo.Name = "tbMevcutKilo";
            tbMevcutKilo.Size = new Size(260, 27);
            tbMevcutKilo.TabIndex = 5;
            // 
            // tbHedefKilo
            // 
            tbHedefKilo.Location = new Point(145, 230);
            tbHedefKilo.Name = "tbHedefKilo";
            tbHedefKilo.Size = new Size(260, 27);
            tbHedefKilo.TabIndex = 4;
            // 
            // tbIsim
            // 
            tbIsim.Location = new Point(145, 140);
            tbIsim.Name = "tbIsim";
            tbIsim.Size = new Size(260, 27);
            tbIsim.TabIndex = 2;
            // 
            // tbSifre
            // 
            tbSifre.Location = new Point(145, 70);
            tbSifre.Name = "tbSifre";
            tbSifre.PasswordChar = '*';
            tbSifre.Size = new Size(260, 27);
            tbSifre.TabIndex = 1;
            // 
            // btnGirisDon
            // 
            btnGirisDon.Location = new Point(28, 609);
            btnGirisDon.Name = "btnGirisDon";
            btnGirisDon.Size = new Size(389, 47);
            btnGirisDon.TabIndex = 9;
            btnGirisDon.Text = "Giriş Ekranına Dön";
            btnGirisDon.UseVisualStyleBackColor = true;
            btnGirisDon.Click += btnGirisDon_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 674);
            Controls.Add(groupBox1);
            Controls.Add(btnGirisDon);
            Name = "Form2";
            Text = "Üyelik İşlemleri";
            FormClosed += Form2_FormClosed;
            Load += Form2_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbSoyisim;
        private TextBox tbHedefKilo;
        private TextBox tbIsim;
        private TextBox tbSifre;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox tbMevcutKilo;
        private Label label7;
        private TextBox tbBoy;
        private ComboBox cbCinsiyet;
        private Label label8;
        private Label label9;
        private TextBox tbEmail;
        private Button btnUyeOl;
        private DateTimePicker dtpDogum;
        private Label label1;
        private CheckBox cbSifreGor;
        private Button btnGirisDon;
    }
}
namespace _01_DiyetProjesi.UI
{
    partial class Form4
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
            cbMailDegis = new CheckBox();
            cbSifreGor = new CheckBox();
            btnGuncelle = new Button();
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
            btnListeGuncelle = new Button();
            btnAsdon = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbMailDegis);
            groupBox1.Controls.Add(cbSifreGor);
            groupBox1.Controls.Add(btnGuncelle);
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
            groupBox1.Location = new Point(28, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(437, 570);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Üye ol";
            // 
            // cbMailDegis
            // 
            cbMailDegis.AutoSize = true;
            cbMailDegis.Location = new Point(146, 62);
            cbMailDegis.Margin = new Padding(1);
            cbMailDegis.Name = "cbMailDegis";
            cbMailDegis.Size = new Size(217, 24);
            cbMailDegis.TabIndex = 11;
            cbMailDegis.Text = "Mailimi değişmek istiyorum.";
            cbMailDegis.UseVisualStyleBackColor = true;
            cbMailDegis.CheckedChanged += cbMailDegis_CheckedChanged;
            // 
            // cbSifreGor
            // 
            cbSifreGor.AutoSize = true;
            cbSifreGor.Location = new Point(146, 137);
            cbSifreGor.Margin = new Padding(1);
            cbSifreGor.Name = "cbSifreGor";
            cbSifreGor.Size = new Size(106, 24);
            cbSifreGor.TabIndex = 10;
            cbSifreGor.Text = "Şifremi Gör";
            cbSifreGor.UseVisualStyleBackColor = true;
            cbSifreGor.CheckedChanged += cbSifreGor_CheckedChanged;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(16, 497);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(389, 47);
            btnGuncelle.TabIndex = 9;
            btnGuncelle.Text = "Bilgilerimi Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // dtpDogum
            // 
            dtpDogum.Location = new Point(145, 439);
            dtpDogum.Name = "dtpDogum";
            dtpDogum.Size = new Size(260, 27);
            dtpDogum.TabIndex = 8;
            // 
            // cbCinsiyet
            // 
            cbCinsiyet.FormattingEnabled = true;
            cbCinsiyet.Location = new Point(145, 389);
            cbCinsiyet.Name = "cbCinsiyet";
            cbCinsiyet.Size = new Size(260, 28);
            cbCinsiyet.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 37);
            label9.Name = "label9";
            label9.Size = new Size(49, 20);
            label9.TabIndex = 1;
            label9.Text = "Email:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 440);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 1;
            label1.Text = "Doğum Tarihi:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 390);
            label8.Name = "label8";
            label8.Size = new Size(63, 20);
            label8.TabIndex = 1;
            label8.Text = "Cinsiyet:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 345);
            label7.Name = "label7";
            label7.Size = new Size(37, 20);
            label7.TabIndex = 1;
            label7.Text = "Boy:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 303);
            label6.Name = "label6";
            label6.Size = new Size(90, 20);
            label6.TabIndex = 1;
            label6.Text = "Mevcut Kilo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 259);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 1;
            label5.Text = "Hedef Kilo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 214);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 1;
            label4.Text = "Soyisim:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 169);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 1;
            label3.Text = "İsim:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 102);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 1;
            label2.Text = "Şifre:";
            // 
            // tbSoyisim
            // 
            tbSoyisim.Location = new Point(145, 213);
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
            tbBoy.Location = new Point(145, 344);
            tbBoy.Name = "tbBoy";
            tbBoy.Size = new Size(260, 27);
            tbBoy.TabIndex = 6;
            // 
            // tbMevcutKilo
            // 
            tbMevcutKilo.Location = new Point(145, 302);
            tbMevcutKilo.Name = "tbMevcutKilo";
            tbMevcutKilo.Size = new Size(260, 27);
            tbMevcutKilo.TabIndex = 5;
            // 
            // tbHedefKilo
            // 
            tbHedefKilo.Location = new Point(145, 258);
            tbHedefKilo.Name = "tbHedefKilo";
            tbHedefKilo.Size = new Size(260, 27);
            tbHedefKilo.TabIndex = 4;
            // 
            // tbIsim
            // 
            tbIsim.Location = new Point(145, 168);
            tbIsim.Name = "tbIsim";
            tbIsim.Size = new Size(260, 27);
            tbIsim.TabIndex = 2;
            // 
            // tbSifre
            // 
            tbSifre.Location = new Point(145, 98);
            tbSifre.Name = "tbSifre";
            tbSifre.PasswordChar = '*';
            tbSifre.Size = new Size(260, 27);
            tbSifre.TabIndex = 1;
            // 
            // btnListeGuncelle
            // 
            btnListeGuncelle.Location = new Point(105, 611);
            btnListeGuncelle.Margin = new Padding(1);
            btnListeGuncelle.Name = "btnListeGuncelle";
            btnListeGuncelle.Size = new Size(277, 47);
            btnListeGuncelle.TabIndex = 3;
            btnListeGuncelle.Text = "Formu Güncelle";
            btnListeGuncelle.UseVisualStyleBackColor = true;
            btnListeGuncelle.Click += btnListeGuncelle_Click;
            // 
            // btnAsdon
            // 
            btnAsdon.Location = new Point(45, 692);
            btnAsdon.Name = "btnAsdon";
            btnAsdon.Size = new Size(388, 54);
            btnAsdon.TabIndex = 4;
            btnAsdon.Text = "Ana Sayfaya Dön";
            btnAsdon.UseVisualStyleBackColor = true;
            btnAsdon.Click += btnAsdon_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 799);
            Controls.Add(btnAsdon);
            Controls.Add(btnListeGuncelle);
            Controls.Add(groupBox1);
            Margin = new Padding(1);
            Name = "Form4";
            Text = "Profil Güncelleme Ekranı";
            FormClosed += Form4_FormClosed;
            Load += Form4_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox cbSifreGor;
        private Button btnGuncelle;
        private DateTimePicker dtpDogum;
        private ComboBox cbCinsiyet;
        private Label label9;
        private Label label1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox tbSoyisim;
        private TextBox tbEmail;
        private TextBox tbBoy;
        private TextBox tbMevcutKilo;
        private TextBox tbHedefKilo;
        private TextBox tbIsim;
        private TextBox tbSifre;
        private Button btnListeGuncelle;
        private CheckBox cbMailDegis;
        private Button btnAsdon;
    }
}
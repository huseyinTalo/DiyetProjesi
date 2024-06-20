namespace _01_DiyetProjesi.UI
{
    partial class Form3
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
            lviewUrunler = new ListView();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            combOgunTipi = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            btnOgunEkle = new Button();
            tbGramaj = new TextBox();
            btnGetir = new Button();
            combKosulOperatoru = new ComboBox();
            tbKosul = new TextBox();
            btnYeniUrun = new Button();
            menuStrip1 = new MenuStrip();
            profilimToolStripMenuItem = new ToolStripMenuItem();
            profilimiGörToolStripMenuItem = new ToolStripMenuItem();
            raporlarımToolStripMenuItem = new ToolStripMenuItem();
            progressBar1 = new ProgressBar();
            gbGunum = new GroupBox();
            lvOgunlerim = new ListView();
            btnOgunSil = new Button();
            label13 = new Label();
            label8 = new Label();
            label7 = new Label();
            lblAldigimKalori = new Label();
            lblHedefKalori = new Label();
            btnExit = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            gbGunum.SuspendLayout();
            SuspendLayout();
            // 
            // lviewUrunler
            // 
            lviewUrunler.Location = new Point(27, 92);
            lviewUrunler.Margin = new Padding(1);
            lviewUrunler.Name = "lviewUrunler";
            lviewUrunler.Size = new Size(531, 221);
            lviewUrunler.TabIndex = 0;
            lviewUrunler.UseCompatibleStateImageBehavior = false;
            lviewUrunler.View = View.Details;
            lviewUrunler.SelectedIndexChanged += lviewUrunler_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(combOgunTipi);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnOgunEkle);
            groupBox1.Controls.Add(tbGramaj);
            groupBox1.Controls.Add(btnGetir);
            groupBox1.Controls.Add(combKosulOperatoru);
            groupBox1.Controls.Add(tbKosul);
            groupBox1.Controls.Add(lviewUrunler);
            groupBox1.Location = new Point(25, 47);
            groupBox1.Margin = new Padding(1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(1);
            groupBox1.Size = new Size(583, 447);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ürün Seçimi:";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(297, 323);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(139, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // combOgunTipi
            // 
            combOgunTipi.FormattingEnabled = true;
            combOgunTipi.Location = new Point(117, 357);
            combOgunTipi.Margin = new Padding(1);
            combOgunTipi.Name = "combOgunTipi";
            combOgunTipi.Size = new Size(170, 28);
            combOgunTipi.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 31);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 7;
            label2.Text = "Ürün ismi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 357);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 6;
            label3.Text = "Öğün tipi:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 321);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 6;
            label1.Text = "Gramaj:";
            // 
            // btnOgunEkle
            // 
            btnOgunEkle.Location = new Point(467, 323);
            btnOgunEkle.Margin = new Padding(1);
            btnOgunEkle.Name = "btnOgunEkle";
            btnOgunEkle.Size = new Size(88, 28);
            btnOgunEkle.TabIndex = 5;
            btnOgunEkle.Text = "Öğün Ekle";
            btnOgunEkle.UseVisualStyleBackColor = true;
            btnOgunEkle.Click += btnOgunEkle_Click;
            // 
            // tbGramaj
            // 
            tbGramaj.Location = new Point(117, 321);
            tbGramaj.Margin = new Padding(1);
            tbGramaj.Name = "tbGramaj";
            tbGramaj.Size = new Size(170, 27);
            tbGramaj.TabIndex = 4;
            // 
            // btnGetir
            // 
            btnGetir.Location = new Point(297, 60);
            btnGetir.Margin = new Padding(1);
            btnGetir.Name = "btnGetir";
            btnGetir.Size = new Size(258, 24);
            btnGetir.TabIndex = 3;
            btnGetir.Text = "Getir";
            btnGetir.UseVisualStyleBackColor = true;
            btnGetir.Click += btnGetir_Click;
            // 
            // combKosulOperatoru
            // 
            combKosulOperatoru.FormattingEnabled = true;
            combKosulOperatoru.Location = new Point(176, 59);
            combKosulOperatoru.Margin = new Padding(1);
            combKosulOperatoru.Name = "combKosulOperatoru";
            combKosulOperatoru.Size = new Size(111, 28);
            combKosulOperatoru.TabIndex = 2;
            // 
            // tbKosul
            // 
            tbKosul.Location = new Point(27, 60);
            tbKosul.Margin = new Padding(1);
            tbKosul.Name = "tbKosul";
            tbKosul.Size = new Size(137, 27);
            tbKosul.TabIndex = 1;
            // 
            // btnYeniUrun
            // 
            btnYeniUrun.Location = new Point(243, 515);
            btnYeniUrun.Margin = new Padding(1);
            btnYeniUrun.Name = "btnYeniUrun";
            btnYeniUrun.Size = new Size(139, 36);
            btnYeniUrun.TabIndex = 5;
            btnYeniUrun.Text = "Yeni Ürün Ekle";
            btnYeniUrun.UseVisualStyleBackColor = true;
            btnYeniUrun.Click += btnYeniUrun_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(40, 40);
            menuStrip1.Items.AddRange(new ToolStripItem[] { profilimToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(3, 1, 0, 1);
            menuStrip1.Size = new Size(1185, 26);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // profilimToolStripMenuItem
            // 
            profilimToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { profilimiGörToolStripMenuItem, raporlarımToolStripMenuItem });
            profilimToolStripMenuItem.Name = "profilimToolStripMenuItem";
            profilimToolStripMenuItem.Size = new Size(75, 24);
            profilimToolStripMenuItem.Text = "Profilim";
            // 
            // profilimiGörToolStripMenuItem
            // 
            profilimiGörToolStripMenuItem.Name = "profilimiGörToolStripMenuItem";
            profilimiGörToolStripMenuItem.Size = new Size(209, 26);
            profilimiGörToolStripMenuItem.Text = "Profilimi Güncelle";
            profilimiGörToolStripMenuItem.Click += profilimiGörToolStripMenuItem_Click;
            // 
            // raporlarımToolStripMenuItem
            // 
            raporlarımToolStripMenuItem.Name = "raporlarımToolStripMenuItem";
            raporlarımToolStripMenuItem.Size = new Size(209, 26);
            raporlarımToolStripMenuItem.Text = "Raporlarım";
            raporlarımToolStripMenuItem.Click += raporlarımToolStripMenuItem_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(21, 60);
            progressBar1.Margin = new Padding(1);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(473, 39);
            progressBar1.TabIndex = 7;
            // 
            // gbGunum
            // 
            gbGunum.Controls.Add(lvOgunlerim);
            gbGunum.Controls.Add(btnOgunSil);
            gbGunum.Controls.Add(label13);
            gbGunum.Controls.Add(label8);
            gbGunum.Controls.Add(label7);
            gbGunum.Controls.Add(lblAldigimKalori);
            gbGunum.Controls.Add(lblHedefKalori);
            gbGunum.Controls.Add(progressBar1);
            gbGunum.Location = new Point(626, 47);
            gbGunum.Margin = new Padding(1);
            gbGunum.Name = "gbGunum";
            gbGunum.Padding = new Padding(1);
            gbGunum.Size = new Size(522, 447);
            gbGunum.TabIndex = 8;
            gbGunum.TabStop = false;
            gbGunum.Text = "Günüm";
            // 
            // lvOgunlerim
            // 
            lvOgunlerim.Location = new Point(9, 183);
            lvOgunlerim.Margin = new Padding(1);
            lvOgunlerim.Name = "lvOgunlerim";
            lvOgunlerim.Size = new Size(485, 185);
            lvOgunlerim.TabIndex = 12;
            lvOgunlerim.UseCompatibleStateImageBehavior = false;
            // 
            // btnOgunSil
            // 
            btnOgunSil.Location = new Point(9, 379);
            btnOgunSil.Margin = new Padding(1);
            btnOgunSil.Name = "btnOgunSil";
            btnOgunSil.Size = new Size(101, 42);
            btnOgunSil.TabIndex = 11;
            btnOgunSil.Text = "Öğün sil";
            btnOgunSil.UseVisualStyleBackColor = true;
            btnOgunSil.Click += btnOgunSil_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(251, 121);
            label13.Margin = new Padding(1, 0, 1, 0);
            label13.Name = "label13";
            label13.Size = new Size(96, 20);
            label13.TabIndex = 9;
            label13.Text = "Hedef Kalori:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 128);
            label8.Margin = new Padding(1, 0, 1, 0);
            label8.Name = "label8";
            label8.Size = new Size(108, 20);
            label8.TabIndex = 9;
            label8.Text = "Aldığım Kalori:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 27);
            label7.Margin = new Padding(1, 0, 1, 0);
            label7.Name = "label7";
            label7.Size = new Size(226, 20);
            label7.TabIndex = 9;
            label7.Text = "Aldığım ve Hedef Kalori Yüzdesi:";
            // 
            // lblAldigimKalori
            // 
            lblAldigimKalori.BackColor = Color.DarkTurquoise;
            lblAldigimKalori.Location = new Point(129, 121);
            lblAldigimKalori.Margin = new Padding(1, 0, 1, 0);
            lblAldigimKalori.Name = "lblAldigimKalori";
            lblAldigimKalori.Size = new Size(118, 40);
            lblAldigimKalori.TabIndex = 8;
            // 
            // lblHedefKalori
            // 
            lblHedefKalori.BackColor = Color.DarkTurquoise;
            lblHedefKalori.Location = new Point(376, 121);
            lblHedefKalori.Margin = new Padding(1, 0, 1, 0);
            lblHedefKalori.Name = "lblHedefKalori";
            lblHedefKalori.Size = new Size(118, 40);
            lblHedefKalori.TabIndex = 8;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(25, 580);
            btnExit.Margin = new Padding(1);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(583, 36);
            btnExit.TabIndex = 9;
            btnExit.Text = "Giriş Ekranına Dön";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1185, 626);
            Controls.Add(btnExit);
            Controls.Add(gbGunum);
            Controls.Add(groupBox1);
            Controls.Add(btnYeniUrun);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(1);
            Name = "Form3";
            Text = "Anasayfa";
            FormClosed += Form3_FormClosed;
            Load += Form3_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            gbGunum.ResumeLayout(false);
            gbGunum.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lviewUrunler;
        private GroupBox groupBox1;
        private Button btnOgunEkle;
        private TextBox tbGramaj;
        private Button btnGetir;
        private ComboBox combKosulOperatoru;
        private TextBox tbKosul;
        private Label label1;
        private Button btnYeniUrun;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem profilimToolStripMenuItem;
        private ToolStripMenuItem profilimiGörToolStripMenuItem;
        private Label label2;
        private ProgressBar progressBar1;
        private GroupBox gbGunum;
        private Label lblHedefKalori;
        private Label label7;
        private Label label8;
        private Label label13;
        private Label lblAldigimKalori;
        private Button btnOgunSil;
        private ListView lvOgunlerim;
        private ComboBox combOgunTipi;
        private Label label3;
        private ToolStripMenuItem raporlarımToolStripMenuItem;
        private Button btnExit;
        private PictureBox pictureBox1;
    }
}
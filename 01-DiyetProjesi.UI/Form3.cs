using _01_DiyetProjesi.DATA.Entities;
using _01_DiyetProjesi.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _01_DiyetProjesi.UI
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();

        }
        string usermail = "";
        DateTime dt = new DateTime();
        private void Form3_Load(object sender, EventArgs e)
        {
            combOgunTipi.Items.Add("Kahvaltı");
            combOgunTipi.Items.Add("Öğle");
            combOgunTipi.Items.Add("Akşam");
            combOgunTipi.Items.Add("Ara öğün");

            combKosulOperatoru.Items.Add("ile başlayan");
            combKosulOperatoru.Items.Add("içeren");
            combKosulOperatoru.Items.Add("ile biten");
            UIMetotlari uim = new UIMetotlari();

            uim.AddRememberance(this);
            uim.InitializeListView(lviewUrunler);
            uim.InitializeListViewOgunlerim(lvOgunlerim);




            foreach (Control ctrl in this.Owner.Controls)
            {
                if (ctrl is GroupBox gb)
                {
                    foreach (Control ctr in gb.Controls)
                    {
                        if (ctr is System.Windows.Forms.TextBox tb && tb.Name == "tbEmail")
                        {
                            usermail = tb.Text;
                        }

                    }
                }
                else if (ctrl is Label lbl && lbl.Name == "lblTutucu")
                {
                    dt = Convert.ToDateTime(lbl.Text);
                }
            }

            GenericRepository<GunUrunDetay> gud = new GenericRepository<GunUrunDetay>();
            List<GunUrunDetay> gudList = gud.RepGetbyConditionGunUrunDetay(dt);
            GenericRepository<Kullanici> grKul = new GenericRepository<Kullanici>();
            Kullanici kulin = grKul.RepGetByConditionKullanici(usermail);
            List<GunUrunDetay> realGuds = new List<GunUrunDetay>();
            foreach (GunUrunDetay gudi in gudList)
            {
                if (gudi.UserID == kulin.UserID)
                {
                    realGuds.Add(gudi);
                }
            }
            if (gudList.Count > 0)
                uim.PopulateListViewOgunlerim(realGuds, lvOgunlerim);

            GenericRepository<Kullanici> grKullanici2 = new GenericRepository<Kullanici>();
            List<Kullanici> mevcutKullanicilar = grKullanici2.RepGetAll();
            GenericRepository<Kullanici> grKullanici = new GenericRepository<Kullanici>();
            GenericRepository<Gun> grGun = new GenericRepository<Gun>();
            Gun gun = grGun.RepGetByConditionGun(dt);
            Kullanici kullanici = grKullanici.RepGetByConditionKullanici(usermail);
            kullanici.Gunler.Add(gun);
            int gunCounter = 0;
            foreach (Kullanici kul in mevcutKullanicilar)
            {
                foreach (Gun altinGun in kul.Gunler)
                {
                    if (altinGun.ToString() == gun.ToString())
                    {
                        gunCounter++;
                    }
                }
            }
            if (gunCounter == 0)
            {
                grKullanici.RepUpdate(kullanici);
            }
            GenericRepository<Kullanici> genericRepository = new GenericRepository<Kullanici>();
            Kullanici kuli = genericRepository.RepGetByConditionKullanici(usermail);

            uim.HedefKaloriHesaplaVeAta(progressBar1, lblHedefKalori, kuli);
            uim.AlinmisKaloriHesaplaVeGuncelle(lblAldigimKalori, dt, progressBar1, usermail);

        }

        private void profilimiGörToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Owner = this;
            form4.Show();
            this.Hide();
        }

        private void btnYeniUrun_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Owner = this;
            form5.Show();
            this.Hide();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            UIMetotlari uim = new UIMetotlari();
            GenericRepository<Urun> grUrun = new GenericRepository<Urun>();
            List<Urun> urunler = new List<Urun>();
            if (combKosulOperatoru.SelectedIndex != -1 && tbKosul.Text != "")
            {
                urunler = grUrun.RepGetByConditionUrun(combKosulOperatoru.SelectedIndex, tbKosul.Text);
                uim.PopulateListView(urunler, lviewUrunler);
            }
            else
            {
                MessageBox.Show("Koşul seçmelisin");
            }


        }

        private void btnOgunEkle_Click(object sender, EventArgs e)
        {

            //poly table populate
            //urun gramaji
            double urunGramajDeger = 0;
            if (tbGramaj.Text != "")
            {
                urunGramajDeger = Convert.ToDouble((tbGramaj.Text));
            }
            else
                tbGramaj.Text = "100";
            double urununTutulanGramaji = 100;

            //GunId için
            GenericRepository<Gun> grGunP = new GenericRepository<Gun>();
            Gun gunP = grGunP.RepGetByConditionGun(dt);
            //userid içi
            GenericRepository<Kullanici> grK = new GenericRepository<Kullanici>();
            Kullanici kulP = grK.RepGetByConditionKullanici(usermail);

            //UrunId için
            try
            {
                GenericRepository<Urun> grUrunP = new GenericRepository<Urun>();
                Urun urunP = grUrunP.RepGetById(Convert.ToInt32(lviewUrunler.SelectedItems[0].SubItems[0].Text));

                //alinmis cal hesabi
                double alinmisKaloriP = urunGramajDeger * urunP.Kalori / urununTutulanGramaji;
                GunUrunDetay gud = new GunUrunDetay();
                gud.UrunGramaj = urunGramajDeger;
                gud.AlinmisKalori = alinmisKaloriP;
                gud.Gun = gunP;
                gud.Urun = urunP;
                gud.Kullanici = kulP;
                if (combOgunTipi.SelectedIndex != -1)
                {
                    gud.GununZamani = combOgunTipi.SelectedItem.ToString();
                }

                GenericRepository<GunUrunDetay> grGud = new GenericRepository<GunUrunDetay>();
                GenericRepository<GunUrunDetay> grGud2 = new GenericRepository<GunUrunDetay>();
                List<GunUrunDetay> gunUrunDetays1 = grGud2.RepGetAll();
                int counter = 0;
                foreach (GunUrunDetay gudd in gunUrunDetays1)
                {
                    if (gudd.UrunID == urunP.UrunID && gudd.GunID == gunP.GunID && gudd.UserID == kulP.UserID)
                    {
                        counter++;
                    }

                }

                if (counter == 0 && combOgunTipi.SelectedIndex != -1)
                    grGud.RepUpdate(gud);
                else
                    MessageBox.Show("Aynı üründen iki defa girmemelisin sil ve ya öğün tipi seçmeyi unuttun seç");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            UIMetotlari uim = new UIMetotlari();

            GenericRepository<GunUrunDetay> gud23 = new GenericRepository<GunUrunDetay>();
            List<GunUrunDetay> gudList = gud23.RepGetbyConditionGunUrunDetay(dt);
            GenericRepository<Kullanici> grKul = new GenericRepository<Kullanici>();
            Kullanici kul = grKul.RepGetByConditionKullanici(usermail);
            List<GunUrunDetay> realGuds = new List<GunUrunDetay>();
            foreach (GunUrunDetay gudi in gudList)
            {
                if (gudi.UserID == kul.UserID)
                {
                    realGuds.Add(gudi);
                }
            }
            if (gudList.Count > 0)
                uim.PopulateListViewOgunlerim(realGuds, lvOgunlerim);




            GenericRepository<Kullanici> grKullanici = new GenericRepository<Kullanici>();

            Kullanici girisYapanKullanici = grKullanici.RepGetByConditionKullanici(usermail);


            //Erkekler için BMH = 66,47 + (13, 75 x kilo) +(5 x boy) -(6, 76 x yaş)
            //Kadınlar için BMH = 655,10 + (9, 56 x kilo) +(1, 85 x boy) -(4, 68 x yaş)

            double hedefKalori = 0;


            uim.HedefKaloriHesaplaVeAta(progressBar1, lblHedefKalori, girisYapanKullanici);
            uim.AlinmisKaloriHesaplaVeGuncelle(lblAldigimKalori, dt, progressBar1, usermail);


            if (progressBar1.Value >= progressBar1.Maximum)
                MessageBox.Show("Boğazını mı tutsan acaba");



        }

        private void btnOgunSil_Click(object sender, EventArgs e)
        {

            if (lvOgunlerim.Items.Count == 0)
            {
                MessageBox.Show("Listede Silecek öğün yoktur.");
            }


            try
            {


                GenericRepository<GunUrunDetay> grGud = new GenericRepository<GunUrunDetay>();
                List<GunUrunDetay> gudList = grGud.RepGetAll();
                foreach (GunUrunDetay guD in gudList)
                {
                    if (guD.UrunID == Convert.ToInt32(lvOgunlerim.SelectedItems[0].SubItems[0].Text))
                    {
                        grGud.RepDelete(guD);
                        break;
                    }
                }



                GenericRepository<Kullanici> grKul = new GenericRepository<Kullanici>();
                Kullanici kul = grKul.RepGetByConditionKullanici(usermail);
                List<GunUrunDetay> gudListt = grGud.RepGetbyConditionGunUrunDetay(dt);
                List<GunUrunDetay> realGuds = new List<GunUrunDetay>();
                foreach (GunUrunDetay gudi in gudListt)
                {
                    if (gudi.UserID == kul.UserID)
                    {
                        realGuds.Add(gudi);
                    }
                }
                UIMetotlari uim = new UIMetotlari();
                uim.PopulateListViewOgunlerim(realGuds, lvOgunlerim);
                GenericRepository<Kullanici> grUser = new GenericRepository<Kullanici>();
                Kullanici user = grUser.RepGetByConditionKullanici(usermail);
                uim.HedefKaloriHesaplaVeAta(progressBar1, lblHedefKalori, user);
                uim.AlinmisKaloriHesaplaVeGuncelle(lblAldigimKalori, dt, progressBar1, usermail);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lütfen Silinecek ğün seçiniz!!");
            }
        }

        private void raporlarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Owner = this;
            form6.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();

            foreach (Control ctrl in this.Owner.Controls)
            {
                if (ctrl is GroupBox gb)
                {
                    foreach (Control c in gb.Controls)
                    {
                        if (c is System.Windows.Forms.TextBox tb)
                        {
                            tb.Clear();
                        }
                    }
                }

            }
            this.Owner.Show();

        }

        private void lviewUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GenericRepository<Urun> grUrun = new GenericRepository<Urun>();
                Urun urun = grUrun.RepGetById(Convert.ToInt32(lviewUrunler.SelectedItems[0].SubItems[0].Text));
                UIMetotlari uim = new UIMetotlari();

                pictureBox1.Image = uim.ByteArrayToImage(urun.ImageData);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

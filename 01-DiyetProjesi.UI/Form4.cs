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

namespace _01_DiyetProjesi.UI
{
    public partial class Form4 : Form
    {
        Kullanici girisYapmisKullanici;
        public Form4()
        {
            InitializeComponent();
        }
        string usermail = "";
        GenericRepository<Kullanici> grKullanici;
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            UIMetotlari uim = new UIMetotlari();

            grKullanici = new GenericRepository<Kullanici>();
            girisYapmisKullanici = grKullanici.RepGetByConditionKullanici(usermail);

            if (tbEmail.Text != "" && tbIsim.Text != "" && tbSoyisim.Text != "" && tbMevcutKilo.Text != "" && tbSifre.Text != "" && tbHedefKilo.Text != "" && tbBoy.Text != "" && cbCinsiyet.SelectedIndex != -1 && dtpDogum.Value != DateTime.Now && uim.IsValidEmail(tbEmail.Text) && uim.IsValidPassword(tbSifre.Text) && !(DateTime.Now.Year - dtpDogum.Value.Year < 18))
            {
                GenericRepository<Kullanici> grK = new GenericRepository<Kullanici>();
                List<Kullanici> kullaniciList = grK.RepGetAll();
                //gr kod akışından bağımsız bir veri köprüsü kurar. aynı grden newlediğin aynı kaynağa atanmış nesneler kod akışında sonda değişirse geçmişte oluşturulmuş nesneyi de değiştirir. o yüzden karşılaştırma yapmak için iki ayrı instance alman gerekir.


                if (tbEmail.Enabled)
                {


                    girisYapmisKullanici.Email = tbEmail.Text;
                    girisYapmisKullanici.Adi = tbIsim.Text;
                    girisYapmisKullanici.Soyadi = tbSoyisim.Text;
                    girisYapmisKullanici.GuncelKilo = Convert.ToDouble(tbMevcutKilo.Text);
                    girisYapmisKullanici.HedefKilo = Convert.ToDouble(tbHedefKilo.Text);
                    girisYapmisKullanici.Boy = Convert.ToInt32(tbBoy.Text);
                    girisYapmisKullanici.Sex = cbCinsiyet.SelectedItem.ToString();
                    girisYapmisKullanici.Password = tbSifre.Text;
                    girisYapmisKullanici.KayitTarihi = DateTime.Now;
                    girisYapmisKullanici.DogumTarihi = dtpDogum.Value;

                    int counter = 0;
                    foreach (Kullanici kullan in kullaniciList)
                    {
                        if (kullan.Email != tbEmail.Text)
                        {
                            counter++;
                        }
                    }

                    if (counter == kullaniciList.Count)
                    {
                        grKullanici.RepUpdate(girisYapmisKullanici);
                        MessageBox.Show("Güncelleme başarılı..");
                    }
                    else
                    {
                        MessageBox.Show("Bu email kullanılmakta");
                    }


                }
                else
                {


                    girisYapmisKullanici.Adi = tbIsim.Text;
                    girisYapmisKullanici.Soyadi = tbSoyisim.Text;
                    girisYapmisKullanici.GuncelKilo = Convert.ToDouble(tbMevcutKilo.Text);
                    girisYapmisKullanici.HedefKilo = Convert.ToDouble(tbHedefKilo.Text);
                    girisYapmisKullanici.Boy = Convert.ToInt32(tbBoy.Text);
                    girisYapmisKullanici.Sex = cbCinsiyet.SelectedItem.ToString();
                    girisYapmisKullanici.Password = tbSifre.Text;
                    girisYapmisKullanici.KayitTarihi = DateTime.Now;
                    girisYapmisKullanici.DogumTarihi = dtpDogum.Value;

                    grKullanici.RepUpdate(girisYapmisKullanici);
                    MessageBox.Show("Güncelleme başarılı..");


                }

            }
            else
                MessageBox.Show("Ekleme işlemi başarısız... Formu tamamen doldurmalısınız");










        }

        private void Form4_Load(object sender, EventArgs e)
        {
            tbEmail.Enabled = false;
            cbCinsiyet.Items.Add("Erkek");
            cbCinsiyet.Items.Add("Kadın");

            grKullanici = new GenericRepository<Kullanici>();
            foreach (Control ctrl in this.Owner.Owner.Controls)
            {
                if (ctrl is GroupBox gb)
                {
                    foreach (Control ctr in gb.Controls)
                    {
                        if (ctr is TextBox tb && tb.Name == "tbEmail")
                        {
                            usermail = tb.Text;
                        }
                    }
                }
            }

            girisYapmisKullanici = grKullanici.RepGetByConditionKullanici(usermail);

            tbEmail.Text = girisYapmisKullanici.Email;
            tbBoy.Text = girisYapmisKullanici.Boy.ToString();
            tbHedefKilo.Text = girisYapmisKullanici.HedefKilo.ToString();
            tbIsim.Text = girisYapmisKullanici.Adi;
            tbSoyisim.Text = girisYapmisKullanici.Soyadi;
            tbSifre.Text = girisYapmisKullanici.Password;
            tbMevcutKilo.Text = girisYapmisKullanici.GuncelKilo.ToString();
            dtpDogum.Value = girisYapmisKullanici.DogumTarihi.Date;
            if (girisYapmisKullanici.Sex == cbCinsiyet.Items[0].ToString())
            {
                cbCinsiyet.SelectedIndex = 0;
            }
            else
            {
                cbCinsiyet.SelectedIndex = 1;
            }

        }

        private void cbSifreGor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSifreGor.Checked)
            {
                tbSifre.PasswordChar = '\0';
            }
            else if (!cbSifreGor.Checked)
            {
                tbSifre.PasswordChar = '*';
            }
        }

        private void cbMailDegis_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMailDegis.Checked)
            {
                tbEmail.Enabled = true;
            }
            else
                tbEmail.Enabled = false;
        }

        private void btnListeGuncelle_Click(object sender, EventArgs e)
        {
            GenericRepository<Kullanici> grKullanici = new GenericRepository<Kullanici>();
            foreach (Control ctrl in this.Owner.Owner.Controls)
            {
                if (ctrl is GroupBox gb)
                {
                    foreach (Control ctr in gb.Controls)
                    {
                        if (ctr is TextBox tb && tb.Name == "tbEmail")
                        {
                            usermail = tb.Text;
                        }
                    }
                }
            }

            girisYapmisKullanici = grKullanici.RepGetByConditionKullanici(usermail);

            tbEmail.Text = girisYapmisKullanici.Email;
            tbBoy.Text = girisYapmisKullanici.Boy.ToString();
            tbHedefKilo.Text = girisYapmisKullanici.HedefKilo.ToString();
            tbIsim.Text = girisYapmisKullanici.Adi;
            tbSoyisim.Text = girisYapmisKullanici.Soyadi;
            tbSifre.Text = girisYapmisKullanici.Password;
            tbMevcutKilo.Text = girisYapmisKullanici.GuncelKilo.ToString();
            if (girisYapmisKullanici.Sex == cbCinsiyet.Items[0])
            {
                cbCinsiyet.SelectedIndex = 0;
            }
            else
            {
                cbCinsiyet.SelectedIndex = 1;
            }
        }

        private void btnAsdon_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

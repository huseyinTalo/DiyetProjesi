using _01_DiyetProjesi.DATA;
using _01_DiyetProjesi.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _01_DiyetProjesi.DATA.Repositories;
using _01_DiyetProjesi.DATA.Entities;
using System.Diagnostics.Metrics;

namespace _01_DiyetProjesi.UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            UIMetotlari uim = new UIMetotlari();
            if (tbEmail.Text != "" && tbIsim.Text != "" && tbSoyisim.Text != "" && tbMevcutKilo.Text != "" && tbSifre.Text != "" && tbHedefKilo.Text != "" && tbBoy.Text != "" && cbCinsiyet.SelectedIndex != -1 && dtpDogum.Value != DateTime.Now && uim.IsValidEmail(tbEmail.Text) && uim.IsValidPassword(tbSifre.Text) && !(DateTime.Now.Year - dtpDogum.Value.Year < 18))
            {
                GenericRepository<Kullanici> grKullanici = new GenericRepository<Kullanici>();
                List<Kullanici> kullaniciList = grKullanici.RepGetAll();




                Kullanici kullanici = new Kullanici()
                {
                    Email = tbEmail.Text,
                    Adi = tbIsim.Text,
                    Soyadi = tbSoyisim.Text,
                    GuncelKilo = Convert.ToDouble(tbMevcutKilo.Text),
                    HedefKilo = Convert.ToDouble(tbHedefKilo.Text),

                    Boy = Convert.ToInt32(tbBoy.Text),
                    Sex = cbCinsiyet.SelectedItem.ToString(),
                    Password = tbSifre.Text,
                    KayitTarihi = DateTime.Now,
                    DogumTarihi = dtpDogum.Value,


                };
                if (kullaniciList.Count == 0)
                {
                    grKullanici.RepUpdate(kullanici);
                    MessageBox.Show("Üyelik başarılı");
                }
                else
                {
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
                        grKullanici.RepUpdate(kullanici);
                        MessageBox.Show("Üyelik başarılı");
                    }
                    else
                    {
                        MessageBox.Show("Bu email kullanılmakta");
                    }
                }



            }
            else
                MessageBox.Show("Ekleme işlemi başarısız... Formu tamamen doldurmalısınız");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cbCinsiyet.Items.Add("Erkek");
            cbCinsiyet.Items.Add("Kadın");
        }

        private void cbSifreGor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSifreGor.Checked)
            {
                tbSifre.PasswordChar = '\0';
            }
            else
            {
                tbSifre.PasswordChar = '*';
            }
        }

        private void btnGirisDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

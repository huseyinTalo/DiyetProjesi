using _01_DiyetProjesi.DATA.Entities;
using _01_DiyetProjesi.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_DiyetProjesi.UI
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnYeniUrunEkle_Click(object sender, EventArgs e)
        {
            UIMetotlari uim = new UIMetotlari();

            if (tbUrunAdi.Text != "" && tbMarka.Text != "" && nudKalori.Value != 0 && combKategori.SelectedIndex != -1 && pictureBox1.Image != null/*&& nudCokluDoymamisYag.Value != 0 && nudTekliDoymamisYag.Value != 0 && nudSeker.Value != 0 && nudDoymusYag.Value != 0 && nudTransYag.Value != 0 && nudProtein.Value != 0 && nudKarbonhidrat.Value != 0 && nudSodyum.Value != 0 && nudFiber.Value != 0 && nudPotasyum.Value != 0*/)
            {
                Urun yeniUrun = new Urun()
                {
                    UrunAdi = tbUrunAdi.Text,
                    Marka = tbMarka.Text,
                    Kalori = (int)nudKalori.Value,
                    CokluDoymamisYag = (double)nudCokluDoymamisYag.Value,
                    TekliDoymamisYag = (double)nudTekliDoymamisYag.Value,
                    DoymusYag = (double)nudDoymusYag.Value,
                    TransYag = (double)nudTransYag.Value,
                    Karbonhidrat = (double)nudKarbonhidrat.Value,
                    Seker = (double)nudSeker.Value,
                    Protein = (double)nudProtein.Value,
                    Sodyum = (double)nudSodyum.Value,
                    Fiber = (double)nudFiber.Value,
                    Potasyum = (double)nudPotasyum.Value,
                    Kategori = combKategori.SelectedItem.ToString(),
                    ImageData = uim.ImageToByteArray(pictureBox1.Image)
                };

                GenericRepository<Urun> grUrun = new GenericRepository<Urun>();
                grUrun.RepUpdate(yeniUrun);
                MessageBox.Show("Ürün ekleme başarılı");
            }
            else
            {
                MessageBox.Show("Boş alan bırakmamalısın");
            }

        }

        private void btnUrunSecimi_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            combKategori.Items.Add("Et ve et ürünleri");
            combKategori.Items.Add("Süt ve Süt ürünleri");
            combKategori.Items.Add("Meyve Sebze");
            combKategori.Items.Add("Unlu Mamül");
            combKategori.Items.Add("Kuru bakliyat");
            combKategori.Items.Add("İçecek");
            combKategori.Items.Add("Atıştırmalık");
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new System.Drawing.Bitmap(openFileDialog.FileName);
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

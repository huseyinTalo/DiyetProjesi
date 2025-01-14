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
    public partial class Form5 : BaseForm
    {
        private readonly GenericRepository<Urun> _urunRepository;

        public Form5()
        {
            InitializeComponent();
            _urunRepository = new GenericRepository<Urun>();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            InitializeCategories();
        }

        private void InitializeCategories()
        {
            var categories = new[]
            {
            "Et ve et ürünleri",
            "Süt ve Süt ürünleri",
            "Meyve Sebze",
            "Unlu Mamül",
            "Kuru bakliyat",
            "İçecek",
            "Atıştırmalık"
        };

            combKategori.Items.AddRange(categories);
        }

        private void btnYeniUrunEkle_Click(object sender, EventArgs e)
        {
            if (!ValidateProductInput())
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun.");
                return;
            }

            if (SaveNewProduct())
            {
                MessageBox.Show("Ürün ekleme başarılı");
            }
        }

        private bool ValidateProductInput()
        {
            return !string.IsNullOrWhiteSpace(tbUrunAdi.Text) &&
                   !string.IsNullOrWhiteSpace(tbMarka.Text) &&
                   nudKalori.Value > 0 &&
                   combKategori.SelectedIndex != -1 &&
                   pictureBox1.Image != null;
        }

        private bool SaveNewProduct()
        {
            try
            {
                var newProduct = new Urun
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
                    ImageData = _uiMetotlari.ImageToByteArray(pictureBox1.Image)
                };

                _urunRepository.RepUpdate(newProduct);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün eklenirken hata: {ex.Message}");
                return false;
            }
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                }
            }
        }
    }
}

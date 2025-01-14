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
    public partial class Form2 : BaseForm
    {
        private readonly GenericRepository<Kullanici> _kullaniciRepository;

        public Form2()
        {
            InitializeComponent();
            _kullaniciRepository = new GenericRepository<Kullanici>();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitializeGenderComboBox();
        }

        private void InitializeGenderComboBox()
        {
            cbCinsiyet.Items.AddRange(new[] { "Erkek", "Kadın" });
        }

        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            if (!ValidateRegistrationForm())
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve geçerli bilgiler girin.");
                return;
            }

            if (TryCreateUser(out var newUser) && SaveUser(newUser))
            {
                MessageBox.Show("Üyelik başarılı");
            }
        }

        private bool ValidateRegistrationForm()
        {
            return !string.IsNullOrWhiteSpace(tbEmail.Text) &&
                   !string.IsNullOrWhiteSpace(tbIsim.Text) &&
                   !string.IsNullOrWhiteSpace(tbSoyisim.Text) &&
                   !string.IsNullOrWhiteSpace(tbMevcutKilo.Text) &&
                   !string.IsNullOrWhiteSpace(tbSifre.Text) &&
                   !string.IsNullOrWhiteSpace(tbHedefKilo.Text) &&
                   !string.IsNullOrWhiteSpace(tbBoy.Text) &&
                   cbCinsiyet.SelectedIndex != -1 &&
                   dtpDogum.Value != DateTime.Now &&
                   _uiMetotlari.IsValidEmail(tbEmail.Text) &&
                   _uiMetotlari.IsValidPassword(tbSifre.Text) &&
                   (DateTime.Now.Year - dtpDogum.Value.Year >= 18);
        }

        private bool TryCreateUser(out Kullanici user)
        {
            try
            {
                user = new Kullanici
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
                    DogumTarihi = dtpDogum.Value
                };
                return true;
            }
            catch
            {
                user = null;
                return false;
            }
        }

        private bool SaveUser(Kullanici user)
        {
            var existingUsers = _kullaniciRepository.RepGetAll();
            if (existingUsers.Any(u => u.Email == user.Email))
            {
                MessageBox.Show("Bu email kullanılmakta");
                return false;
            }

            _kullaniciRepository.RepUpdate(user);
            return true;
        }
    }
}

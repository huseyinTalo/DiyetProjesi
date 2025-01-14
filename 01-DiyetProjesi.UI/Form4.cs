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
    public partial class Form4 : BaseForm
    {
        private readonly GenericRepository<Kullanici> _kullaniciRepository;
        private Kullanici _currentUser;

        public Form4()
        {
            InitializeComponent();
            _kullaniciRepository = new GenericRepository<Kullanici>();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            InitializeControls();
            LoadUserData();
        }

        private void InitializeControls()
        {
            tbEmail.Enabled = false;
            cbCinsiyet.Items.AddRange(new[] { "Erkek", "Kadın" });
        }

        private void LoadUserData()
        {
            string userEmail = GetUserEmailFromParentForm();
            _currentUser = _kullaniciRepository.RepGetByConditionKullanici(userEmail);
            PopulateUserFields();
        }

        private string GetUserEmailFromParentForm()
        {
            var emailControl = Owner?.Owner?.Controls
                .OfType<GroupBox>()
                .SelectMany(gb => gb.Controls.OfType<TextBox>())
                .FirstOrDefault(tb => tb.Name == "tbEmail");

            return emailControl?.Text ?? string.Empty;
        }

        private void PopulateUserFields()
        {
            if (_currentUser == null) return;

            tbEmail.Text = _currentUser.Email;
            tbBoy.Text = _currentUser.Boy.ToString();
            tbHedefKilo.Text = _currentUser.HedefKilo.ToString();
            tbIsim.Text = _currentUser.Adi;
            tbSoyisim.Text = _currentUser.Soyadi;
            tbSifre.Text = _currentUser.Password;
            tbMevcutKilo.Text = _currentUser.GuncelKilo.ToString();
            dtpDogum.Value = _currentUser.DogumTarihi.Date;
            cbCinsiyet.SelectedIndex = _currentUser.Sex == "Erkek" ? 0 : 1;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!ValidateUserInput())
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve geçerli bilgiler girin.");
                return;
            }

            if (UpdateUserProfile())
            {
                MessageBox.Show("Güncelleme başarılı.");
            }
        }

        private bool ValidateUserInput()
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

        private bool UpdateUserProfile()
        {
            try
            {
                if (tbEmail.Enabled && IsEmailInUse(tbEmail.Text))
                {
                    MessageBox.Show("Bu email adresi kullanımda");
                    return false;
                }

                UpdateUserFields();
                _kullaniciRepository.RepUpdate(_currentUser);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında hata: {ex.Message}");
                return false;
            }
        }

        private bool IsEmailInUse(string email)
        {
            return _kullaniciRepository.RepGetAll()
                .Any(u => u.Email == email && u.UserID != _currentUser.UserID);
        }

        private void UpdateUserFields()
        {
            _currentUser.Email = tbEmail.Text;
            _currentUser.Adi = tbIsim.Text;
            _currentUser.Soyadi = tbSoyisim.Text;
            _currentUser.GuncelKilo = Convert.ToDouble(tbMevcutKilo.Text);
            _currentUser.HedefKilo = Convert.ToDouble(tbHedefKilo.Text);
            _currentUser.Boy = Convert.ToInt32(tbBoy.Text);
            _currentUser.Sex = cbCinsiyet.SelectedItem.ToString();
            _currentUser.Password = tbSifre.Text;
            _currentUser.KayitTarihi = DateTime.Now;
            _currentUser.DogumTarihi = dtpDogum.Value;
        }

        private void cbSifreGor_CheckedChanged(object sender, EventArgs e)
        {
            tbSifre.PasswordChar = cbSifreGor.Checked ? '\0' : '*';
        }

        private void cbMailDegis_CheckedChanged(object sender, EventArgs e)
        {
            tbEmail.Enabled = cbMailDegis.Checked;
        }
    }
}

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
    public partial class Form3 : BaseForm
    {

        private string _userEmail;
        private DateTime _currentDate;
        private readonly GenericRepository<GunUrunDetay> _gunUrunDetayRepository;
        private readonly GenericRepository<Kullanici> _kullaniciRepository;
        private readonly GenericRepository<Gun> _gunRepository;
        private readonly GenericRepository<Urun> _urunRepository;

        public Form3()
        {
            InitializeComponent();
            _gunUrunDetayRepository = new GenericRepository<GunUrunDetay>();
            _kullaniciRepository = new GenericRepository<Kullanici>();
            _gunRepository = new GenericRepository<Gun>();
            _urunRepository = new GenericRepository<Urun>();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            InitializeControls();
            LoadUserData();
            UpdateUserInterface();
        }

        private void InitializeControls()
        {
            InitializeComboBoxes();
            _uiMetotlari.InitializeListView(lviewUrunler);
            _uiMetotlari.InitializeListViewOgunlerim(lvOgunlerim);
            _uiMetotlari.AddRememberance(this);
        }

        private void InitializeComboBoxes()
        {
            combOgunTipi.Items.AddRange(new[] { "Kahvaltı", "Öğle", "Akşam", "Ara öğün" });
            combKosulOperatoru.Items.AddRange(new[] { "ile başlayan", "içeren", "ile biten" });
        }

        private void LoadUserData()
        {
            LoadUserCredentials();
            var currentUser = _kullaniciRepository.RepGetByConditionKullanici(_userEmail);
            var currentDay = _gunRepository.RepGetByConditionGun(_currentDate);

            AssociateUserWithDay(currentUser, currentDay);
            LoadUserMeals(currentUser);
        }

        private void LoadUserCredentials()
        {
            foreach (Control ctrl in Owner.Controls)
            {
                if (ctrl is GroupBox gb)
                {
                    var emailBox = gb.Controls.OfType<System.Windows.Forms.TextBox>()
                        .FirstOrDefault(tb => tb.Name == "tbEmail");
                    if (emailBox != null)
                        _userEmail = emailBox.Text;
                }
                else if (ctrl is Label lbl && lbl.Name == "lblTutucu")
                {
                    _currentDate = Convert.ToDateTime(lbl.Text);
                }
            }
        }

        private void LoadUserMeals(Kullanici user)
        {
            var meals = _gunUrunDetayRepository.RepGetbyConditionGunUrunDetay(_currentDate)
                .Where(m => m.UserID == user.UserID)
                .ToList();

            if (meals.Any())
            {
                _uiMetotlari.PopulateListViewOgunlerim(meals, lvOgunlerim);
            }
        }

        private void AssociateUserWithDay(Kullanici user, Gun day)
        {
            if (!user.Gunler.Contains(day))
            {
                user.Gunler.Add(day);
                _kullaniciRepository.RepUpdate(user);
            }
        }

        private void UpdateUserInterface()
        {
            var currentUser = _kullaniciRepository.RepGetByConditionKullanici(_userEmail);
            _uiMetotlari.HedefKaloriHesaplaVeAta(progressBar1, lblHedefKalori, currentUser);
            _uiMetotlari.AlinmisKaloriHesaplaVeGuncelle(lblAldigimKalori, _currentDate, progressBar1, _userEmail);
        }

        private void btnOgunEkle_Click(object sender, EventArgs e)
        {
            if (!ValidateOgunInput())
                return;

            var mealDetails = CreateMealDetails();
            if (mealDetails != null && !IsDuplicateMeal(mealDetails))
            {
                SaveMealAndUpdateUI(mealDetails);
            }
        }

        private bool ValidateOgunInput()
        {
            if (combOgunTipi.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen öğün tipi seçin");
                return false;
            }

            if (string.IsNullOrEmpty(tbGramaj.Text))
            {
                tbGramaj.Text = "100";
            }

            return true;
        }

        private GunUrunDetay CreateMealDetails()
        {
            try
            {
                var selectedUrunId = Convert.ToInt32(lviewUrunler.SelectedItems[0].SubItems[0].Text);
                var urun = _urunRepository.RepGetById(selectedUrunId);
                var gramaj = Convert.ToDouble(tbGramaj.Text);
                var alinmisKalori = gramaj * urun.Kalori / 100;

                return new GunUrunDetay
                {
                    UrunGramaj = gramaj,
                    AlinmisKalori = alinmisKalori,
                    Gun = _gunRepository.RepGetByConditionGun(_currentDate),
                    Urun = urun,
                    Kullanici = _kullaniciRepository.RepGetByConditionKullanici(_userEmail),
                    GununZamani = combOgunTipi.SelectedItem.ToString()
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Öğün eklenirken hata: {ex.Message}");
                return null;
            }
        }

        private bool IsDuplicateMeal(GunUrunDetay meal)
        {
            return _gunUrunDetayRepository.RepGetAll()
                .Any(m => m.UrunID == meal.UrunID &&
                         m.GunID == meal.GunID &&
                         m.UserID == meal.UserID);
        }

        private void SaveMealAndUpdateUI(GunUrunDetay meal)
        {
            _gunUrunDetayRepository.RepUpdate(meal);
            LoadUserMeals(_kullaniciRepository.RepGetByConditionKullanici(_userEmail));
            UpdateUserInterface();

            if (progressBar1.Value >= progressBar1.Maximum)
            {
                MessageBox.Show("Günlük kalori limitinizi aştınız!");
            }
        }
    }
}

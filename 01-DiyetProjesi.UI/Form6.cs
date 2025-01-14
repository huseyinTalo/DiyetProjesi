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
    public partial class Form6 : BaseForm
    {
        private readonly GenericRepository<Kullanici> _kullaniciRepository;
        private readonly GenericRepository<GunUrunDetay> _gunUrunDetayRepository;
        private Kullanici _currentUser;

        public Form6()
        {
            InitializeComponent();
            _kullaniciRepository = new GenericRepository<Kullanici>();
            _gunUrunDetayRepository = new GenericRepository<GunUrunDetay>();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            LoadUserData();
            InitializeReports();
        }

        private void LoadUserData()
        {
            string userEmail = GetUserEmailFromParentForm();
            _currentUser = _kullaniciRepository.RepGetByConditionKullanici(userEmail);
        }

        private string GetUserEmailFromParentForm()
        {
            var emailControl = Owner?.Owner?.Controls
                .OfType<GroupBox>()
                .SelectMany(gb => gb.Controls.OfType<TextBox>())
                .FirstOrDefault(tb => tb.Name == "tbEmail");

            return emailControl?.Text ?? string.Empty;
        }

        private void InitializeReports()
        {
            var meals = _gunUrunDetayRepository.RepGetAll();
            if (!meals.Any()) return;

            UpdateStatistics();
            InitializeAndPopulateReportList();
        }

        private void UpdateStatistics()
        {
            _uiMetotlari.EnCokTercihEdilenYemek(_currentUser, lblEncokYedigim);
            _uiMetotlari.EnCokTercihEdilenYemek(lblEnCokYenen);
            _uiMetotlari.EnCokTercihEdilenOgunum(lblEnCokTercihEdilenOgun);
            _uiMetotlari.EnCokTercihEdilenOgunum(_currentUser, lblEnCokTercihEttigimOgun);
        }

        private void InitializeAndPopulateReportList()
        {
            _uiMetotlari.InitializeListViewRaporum(listView1);
            _uiMetotlari.PopulateListViewRaporum(listView1, _currentUser);
        }
    }
}

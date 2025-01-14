using _01_DiyetProjesi.DATA.Entities;
using _01_DiyetProjesi.DATA.Repositories;

namespace _01_DiyetProjesi.UI
{
    public partial class Form1 : BaseForm
    {
        private Form3 _form3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeCurrentDay();
            InitializeRememberMe();
        }

        private void InitializeCurrentDay()
        {
            var gunRepository = new GenericRepository<Gun>();
            var today = DateTime.Now.Date;
            var newGun = new Gun { BugununTarihi = today };
            lblTutucu.Text = today.ToString();

            var existingGuns = gunRepository.RepGetAll();
            if (!existingGuns.Any() || existingGuns.All(g => g.BugununTarihi.Day != today.Day))
            {
                gunRepository.RepUpdate(newGun);
            }
        }

        private void InitializeRememberMe()
        {
            _uiMetotlari.CreateRememberance();
            _uiMetotlari.ReadRememberance(tbEmail);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            _form3 = new Form3();
            if (_uiMetotlari.GirisKontrolu(this, _form3, tbEmail, tbSifre))
            {
                MessageBox.Show("Giriş başarılı");
            }
            else
            {
                MessageBox.Show("Email veya şifre hatalı");
            }
        }

        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            var form2 = new Form2 { Owner = this };
            form2.Show();
            Hide();
        }

        private void cbSifreGor_CheckedChanged(object sender, EventArgs e)
        {
            tbSifre.PasswordChar = cbSifreGor.Checked ? '\0' : '*';
        }
    }
}
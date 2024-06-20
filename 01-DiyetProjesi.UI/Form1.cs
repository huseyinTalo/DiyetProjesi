using _01_DiyetProjesi.DATA.Entities;
using _01_DiyetProjesi.DATA.Repositories;

namespace _01_DiyetProjesi.UI
{
    public partial class Form1 : Form
    {
        Form3 form3;
        public Form1()
        {
            InitializeComponent();

        }
        UIMetotlari uim;
        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Owner = this;
            form2.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenericRepository<Gun> gr = new GenericRepository<Gun>();
            Gun gn = new Gun()
            {
                BugununTarihi = DateTime.Now.Date,
            };

            lblTutucu.Text = gn.BugununTarihi.ToString();

            List<Gun> gunList = gr.RepGetAll(); //list boş mu değil mi null olarak DEĞİL Count propertysinden KONTROL EDİLİR. çünkü newlediğin zaman doluyo mantıken.

            if (gunList.Count != 0)
            {
                int counter = 0;
                foreach (Gun gun in gunList)
                {
                    if (gun.BugununTarihi.Day != gn.BugununTarihi.Day)
                    {
                        counter++;

                    }

                    if (counter == gunList.Count)
                    {
                        gr.RepUpdate(gn);
                    }//bunu counterla yapmak daha mantıklı çünkü databasede 50 gün varsa farklı olan her gün için ekleme yapmasın. tüm hepsine baksın hepsi farklıysa ekleme yapsın.
                }
            }
            else if (gunList.Count == 0)
            {
                gr.RepUpdate(gn);
            }

            uim = new UIMetotlari();
            uim.CreateRememberance();
            uim.ReadRememberance(tbEmail);




        }

        public void btnGiris_Click(object sender, EventArgs e)
        {
            uim = new UIMetotlari();
            form3 = new Form3();
            form3.Owner = this;
            if (uim.GirisKontrolu(this, form3, tbEmail, tbSifre))
            {
                MessageBox.Show("Giriş başarılı");
            }
            else
                MessageBox.Show("Email ve ya şifre hatalı");
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
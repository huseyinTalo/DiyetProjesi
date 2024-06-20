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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string usermail = string.Empty;
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
            GenericRepository<Kullanici> grKullanici = new GenericRepository<Kullanici>();
            Kullanici kul = grKullanici.RepGetByConditionKullanici(usermail);
            UIMetotlari uim = new UIMetotlari();
            GenericRepository<GunUrunDetay> grGud = new GenericRepository<GunUrunDetay>();
            List<GunUrunDetay> gunUrunDetays = grGud.RepGetAll();
            if (gunUrunDetays.Count > 0)
            {
                uim.EnCokTercihEdilenYemek(kul, lblEncokYedigim);
                uim.EnCokTercihEdilenYemek(lblEnCokYenen);
                uim.EnCokTercihEdilenOgunum(lblEnCokTercihEdilenOgun);
                uim.EnCokTercihEdilenOgunum(kul, lblEnCokTercihEttigimOgun);
                uim.InitializeListViewRaporum(listView1);
                uim.PopulateListViewRaporum(listView1, kul);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

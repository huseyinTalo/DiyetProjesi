using _01_DiyetProjesi.DATA.Entities;
using _01_DiyetProjesi.DATA.Repositories;
using Castle.Components.DictionaryAdapter.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01_DiyetProjesi.UI
{
    public class UIMetotlari
    {
        string fllpath = @"C:\Users\79153\Documents\DiyetProject\UserRememberance.txt";
        public bool GirisKontrolu(Form mevcutForm, Form acılacakForm, TextBox email, TextBox sifre)
        {
            GenericRepository<Kullanici> gr = new GenericRepository<Kullanici>();
            try
            {
                List<Kullanici> kullaniciList = gr.RepGetAll();

                foreach (Kullanici kul in kullaniciList)
                {
                    if (kul.Email == email.Text && kul.Password == sifre.Text)
                    {
                        acılacakForm.Owner = mevcutForm;
                        acılacakForm.Show();
                        mevcutForm.Hide();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateRememberance()
        {
            try
            {
                string directoryPath = @"C:\Users\79153\Documents\DiyetProject";
                string fileName = "UserRememberance.txt";
                string fullPath = Path.Combine(directoryPath, fileName);
                fllpath = fullPath;

                if (!Directory.Exists(directoryPath))
                {

                    Directory.CreateDirectory(directoryPath);
                }


                if (!File.Exists(fullPath))
                {
                    StreamWriter sw = File.CreateText(fullPath);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddRememberance(Form3 form3)
        {
            try
            {
                File.WriteAllText(fllpath, string.Empty);
                using (StreamWriter sw = new StreamWriter(fllpath))
                {
                    foreach (Control ctrl in form3.Owner.Controls)
                    {
                        if (ctrl is GroupBox gb)
                        {
                            foreach (Control ctrl2 in gb.Controls)
                            {
                                if (ctrl2 is CheckBox cb)
                                {
                                    if (cb.Checked && cb.Name == "cbBeniHatirla")
                                    {
                                        foreach (Control cctrl in gb.Controls)
                                        {
                                            if (cctrl is TextBox tb)
                                            {
                                                if (tb.Name == "tbEmail")
                                                {
                                                    sw.Write(tb.Text);

                                                }
                                            }
                                        }
                                    }


                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ReadRememberance(TextBox tb)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fllpath))
                {
                    tb.Text = sr.ReadLine();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void PopulateListView(List<Urun> urunler, ListView listView1)
        {

            listView1.Items.Clear();
            try
            {

                int i = 0;
                foreach (Urun urun in urunler)
                {
                    listView1.Items.Add(urun.UrunID.ToString());
                    listView1.Items[i].SubItems.Add(urun.UrunAdi);
                    listView1.Items[i].SubItems.Add(urun.Marka);
                    listView1.Items[i].SubItems.Add(urun.Kalori.ToString());
                    listView1.Items[i].SubItems.Add(urun.DoymusYag.ToString());
                    listView1.Items[i].SubItems.Add(urun.TransYag.ToString());
                    listView1.Items[i].SubItems.Add(urun.CokluDoymamisYag.ToString());
                    listView1.Items[i].SubItems.Add(urun.TekliDoymamisYag.ToString());
                    listView1.Items[i].SubItems.Add(urun.Karbonhidrat.ToString());
                    listView1.Items[i].SubItems.Add(urun.Seker.ToString());
                    listView1.Items[i].SubItems.Add(urun.Protein.ToString());
                    listView1.Items[i].SubItems.Add(urun.Sodyum.ToString());
                    listView1.Items[i].SubItems.Add(urun.Potasyum.ToString());
                    listView1.Items[i].SubItems.Add(urun.Fiber.ToString());
                    listView1.Items[i].SubItems.Add(urun.Kategori);
                    i++;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public void InitializeListView(ListView listView1)
        {
            try
            {


                listView1.Enabled = true;

                listView1.View = View.Details;
                listView1.AllowColumnReorder = true;

                listView1.FullRowSelect = true;
                listView1.GridLines = true;

                listView1.Columns.Add("ID", 60);
                listView1.Columns.Add("Ürün Adı", 180);
                listView1.Columns.Add("Marka", 180);
                listView1.Columns.Add("Kalori", 180);
                listView1.Columns.Add("Doymuş Yağ", 180);
                listView1.Columns.Add("Trans Yağ", 180);
                listView1.Columns.Add("Tekli Doymamış Yağ", 360);
                listView1.Columns.Add("Çoklu Doymamış Yağ", 360);
                listView1.Columns.Add("Protein", 120);
                listView1.Columns.Add("Karbonhidrat", 180);
                listView1.Columns.Add("Şeker", 120);
                listView1.Columns.Add("Sodyum", 120);
                listView1.Columns.Add("Fiber", 120);
                listView1.Columns.Add("Potasyum", 120);
                listView1.Columns.Add("Kategori", 120);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void InitializeListViewOgunlerim(ListView listView1)
        {
            try
            {


                listView1.Enabled = true;

                listView1.View = View.Details;
                listView1.AllowColumnReorder = true;

                listView1.FullRowSelect = true;
                listView1.GridLines = true;

                listView1.Columns.Add("ID", 60);
                listView1.Columns.Add("Ürün Adı", 180);
                listView1.Columns.Add("Gramaj", 180);
                listView1.Columns.Add("Alınan Kalori", 240);
                listView1.Columns.Add("Öğün Tipi", 180);
                listView1.Columns.Add("Ürün Kategorisi", 180);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void PopulateListViewOgunlerim(List<GunUrunDetay> gunUrunDetays, ListView listView1)
        {
            listView1.Items.Clear();
            try
            {
                int i = 0;
                foreach (GunUrunDetay urun in gunUrunDetays)
                {
                    listView1.Items.Add(urun.UrunID.ToString());
                    listView1.Items[i].SubItems.Add(urun.Urun.UrunAdi);
                    listView1.Items[i].SubItems.Add(urun.UrunGramaj.ToString());
                    listView1.Items[i].SubItems.Add(urun.AlinmisKalori.ToString());
                    listView1.Items[i].SubItems.Add(urun.GununZamani);
                    listView1.Items[i].SubItems.Add(urun.Urun.Kategori);
                    i++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void HedefKaloriHesaplaVeAta(ProgressBar progressBar1, Label lblHedefKalori, Kullanici kullanici)
        {

            double boy = kullanici.Boy;
            double kilo = kullanici.HedefKilo;
            double yas = DateTime.Now.Year - kullanici.DogumTarihi.Year;
            double hedefKalori = 0;

            try
            {



                if (kullanici.Sex == "Erkek")
                {
                    hedefKalori = 66.47 + (13.75 * kilo) + (5 * boy) - (6.76 * yas);
                }
                else
                {
                    hedefKalori = 655.10 + (9.56 * kilo) + (1.85 * boy) - (4.68 * yas);
                }


                lblHedefKalori.Text = hedefKalori.ToString();


                progressBar1.Maximum = Convert.ToInt32(hedefKalori);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlinmisKaloriHesaplaVeGuncelle(Label lbl, DateTime dt, ProgressBar pb, string usermail)
        {
            try
            {
                GenericRepository<GunUrunDetay> grGudLab = new GenericRepository<GunUrunDetay>();
                GenericRepository<Kullanici> grKul = new GenericRepository<Kullanici>();
                Kullanici kul = grKul.RepGetByConditionKullanici(usermail);
                List<GunUrunDetay> gunUrunDetays = grGudLab.RepGetAll();
                double alinmisKaloriToplam = 0;
                if (gunUrunDetays.Count > 0)
                    foreach (GunUrunDetay gunUrunDetay in gunUrunDetays)
                    {
                        if (gunUrunDetay.Gun.BugununTarihi == dt && gunUrunDetay.UserID == kul.UserID)
                        {
                            alinmisKaloriToplam += gunUrunDetay.AlinmisKalori;
                        }
                    }
                lbl.Text = alinmisKaloriToplam.ToString();
                pb.Value = (int)alinmisKaloriToplam;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsValidEmail(string email)
        {
            try
            {

                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(email))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Lütfen mail formatında bir şey giriniz.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsValidPassword(string password)
        {
            // Regex pattern for complex password:
            // - At least 8 characters long
            // - Contains at least one uppercase letter
            // - Contains at least one lowercase letter
            // - Contains at least one number
            // - Contains at least one special character
            try
            {
                string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?.&])[A-Za-z\d@$!%*?&]{8,}$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(password))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Şifre en az 8 karakter olmalı bir büyük bir küçük harf içermeli en az bir numara ve özel karakter içermeli.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EnCokTercihEdilenYemek(Kullanici kul, Label lbl)
        {
            try
            {

                GenericRepository<GunUrunDetay> genericRepository = new GenericRepository<GunUrunDetay>();
                List<GunUrunDetay> gudList = genericRepository.RepGetAll();
                List<int> gudListoresult = new List<int>();
                foreach (GunUrunDetay gud in gudList)
                {
                    if (gud.UserID == kul.UserID)
                    {
                        gudListoresult.Add(gud.UrunID);
                    }
                }
                GenericRepository<Urun> grUrun = new GenericRepository<Urun>();
                Urun urun = grUrun.RepGetById(FindMostRepeatedNumber(gudListoresult));

                lbl.Text = urun.UrunAdi + " " + urun.Kategori;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EnCokTercihEdilenYemek(Label lbl)
        {
            try
            {
                GenericRepository<GunUrunDetay> genericRepository = new GenericRepository<GunUrunDetay>();

                List<GunUrunDetay> gudList = genericRepository.RepGetAll();
                List<int> gudListoresult = new List<int>();
                foreach (GunUrunDetay gud in gudList)
                {
                    gudListoresult.Add(gud.UrunID);
                }
                GenericRepository<Urun> grUrun = new GenericRepository<Urun>();
                Urun urun = grUrun.RepGetById(FindMostRepeatedNumber(gudListoresult));

                lbl.Text = urun.UrunAdi + " " + urun.Kategori;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EnCokTercihEdilenOgunum(Label lbl)
        {
            try
            {

                GenericRepository<GunUrunDetay> grGud = new GenericRepository<GunUrunDetay>();
                List<GunUrunDetay> gunUrunDetays = grGud.RepGetAll();
                List<string> strings = new List<string>();
                foreach (GunUrunDetay gud in gunUrunDetays)
                {

                    strings.Add(gud.GununZamani);

                }
                lbl.Text = FindMostRepeatedWord(strings);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EnCokTercihEdilenOgunum(Kullanici kul, Label lbl)
        {
            try
            {
                GenericRepository<GunUrunDetay> grGud = new GenericRepository<GunUrunDetay>();
                List<GunUrunDetay> gunUrunDetays = grGud.RepGetAll();
                List<string> strings = new List<string>();
                foreach (GunUrunDetay gud in gunUrunDetays)
                {
                    if (kul.UserID == gud.UserID)
                    {
                        strings.Add(gud.GununZamani);
                    }
                }
                lbl.Text = FindMostRepeatedWord(strings);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static int FindMostRepeatedNumber(List<int> numbers)
        {
            try
            {


                if (numbers == null || numbers.Count == 0)
                    throw new ArgumentException("The list cannot be null or empty");

                Dictionary<int, int> countDictionary = new Dictionary<int, int>();

                foreach (int number in numbers)
                {
                    if (countDictionary.ContainsKey(number))
                    {
                        countDictionary[number]++;
                    }
                    else
                    {
                        countDictionary[number] = 1;
                    }
                }

                int mostRepeatedNumber = numbers[0];
                int maxCount = countDictionary[mostRepeatedNumber];

                foreach (var pair in countDictionary)
                {
                    if (pair.Value > maxCount)
                    {
                        mostRepeatedNumber = pair.Key;
                        maxCount = pair.Value;
                    }
                }

                return mostRepeatedNumber;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static string FindMostRepeatedWord(List<string> words)
        {
            try
            {
                if (words == null || words.Count == 0)
                    return null;
                Dictionary<string, int> wordCounts = new Dictionary<string, int>();
                foreach (string word in words)
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;
                    }
                    else
                    {
                        wordCounts[word] = 1;
                    }
                }
                string mostRepeatedWord = null;
                int maxCount = 0;

                foreach (var kvp in wordCounts)
                {
                    if (kvp.Value > maxCount)
                    {
                        maxCount = kvp.Value;
                        mostRepeatedWord = kvp.Key;
                    }
                }
                return mostRepeatedWord;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InitializeListViewRaporum(ListView listView1)
        {
            try
            {

                listView1.Enabled = true;
                listView1.View = View.Details;
                listView1.AllowColumnReorder = true;
                listView1.FullRowSelect = true;
                listView1.GridLines = true;
                listView1.Columns.Add("Gun", 60);
                listView1.Columns.Add("Urun", 180);
                listView1.Columns.Add("Kategori", 180);
                listView1.Columns.Add("Gramaj", 180);
                listView1.Columns.Add("Kalori", 180);
                listView1.Columns.Add("Ogun", 180);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void PopulateListViewRaporum(ListView listView1, Kullanici kul)
        {
            try
            {
                GenericRepository<GunUrunDetay> grGud = new GenericRepository<GunUrunDetay>();
                List<GunUrunDetay> gunUrunDetays = new List<GunUrunDetay>();
                List<GunUrunDetay> gunUrunDetays1 = grGud.RepGetAll();
                foreach (GunUrunDetay gud in gunUrunDetays1)
                {
                    if (gud.UserID == kul.UserID)
                    {
                        gunUrunDetays.Add(gud);
                    }
                }

                listView1.Items.Clear();

                int i = 0;
                foreach (GunUrunDetay urun in gunUrunDetays)
                {
                    listView1.Items.Add(urun.Gun.BugununTarihi.ToString());
                    listView1.Items[i].SubItems.Add(urun.Urun.UrunAdi);
                    listView1.Items[i].SubItems.Add(urun.Urun.Kategori);
                    listView1.Items[i].SubItems.Add(urun.UrunGramaj.ToString());
                    listView1.Items[i].SubItems.Add(urun.AlinmisKalori.ToString());
                    listView1.Items[i].SubItems.Add(urun.GununZamani);
                    i++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public byte[] ImageToByteArray(Image image)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Image ByteArrayToImage(byte[] byteArray)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream(byteArray))
                {
                    Image image = Image.FromStream(memoryStream);
                    return image;
                }
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
        }
    }


}

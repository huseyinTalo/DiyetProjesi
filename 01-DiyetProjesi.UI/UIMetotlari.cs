using _01_DiyetProjesi.DATA.Entities;
using _01_DiyetProjesi.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;

namespace _01_DiyetProjesi.UI
{
    public class UIMetotlari
    {
        private const string FILE_PATH = @"C:\Users\79153\Documents\DiyetProject\UserRememberance.txt";
        private const string DIRECTORY_PATH = @"C:\Users\79153\Documents\DiyetProject";
        private const string FILE_NAME = "UserRememberance.txt";

        private readonly GenericRepository<Kullanici> _kullaniciRepository;
        private readonly GenericRepository<GunUrunDetay> _gunUrunDetayRepository;
        private readonly GenericRepository<Urun> _urunRepository;

        public UIMetotlari()
        {
            _kullaniciRepository = new GenericRepository<Kullanici>();
            _gunUrunDetayRepository = new GenericRepository<GunUrunDetay>();
            _urunRepository = new GenericRepository<Urun>();
        }

        public bool GirisKontrolu(Form mevcutForm, Form acilacakForm, TextBox email, TextBox sifre)
        {
            try
            {
                var kullaniciList = _kullaniciRepository.RepGetAll();
                var kullanici = kullaniciList.FirstOrDefault(k => k.Email == email.Text && k.Password == sifre.Text);

                if (kullanici != null)
                {
                    acilacakForm.Owner = mevcutForm;
                    acilacakForm.Show();
                    mevcutForm.Hide();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Giriş kontrolünde hata: {ex.Message}");
            }
        }

        public void CreateRememberance()
        {
            try
            {
                if (!Directory.Exists(DIRECTORY_PATH))
                {
                    Directory.CreateDirectory(DIRECTORY_PATH);
                }

                string fullPath = Path.Combine(DIRECTORY_PATH, FILE_NAME);
                if (!File.Exists(fullPath))
                {
                    using (StreamWriter sw = File.CreateText(fullPath)) { }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Hatırlama dosyası oluşturulurken hata: {ex.Message}");
            }
        }

        public void AddRememberance(Form3 form3)
        {
            try
            {
                File.WriteAllText(FILE_PATH, string.Empty);
                using (StreamWriter sw = new StreamWriter(FILE_PATH))
                {
                    var gbControls = form3.Owner.Controls.OfType<GroupBox>();
                    foreach (var gb in gbControls)
                    {
                        var cbBeniHatirla = gb.Controls.OfType<CheckBox>()
                            .FirstOrDefault(cb => cb.Name == "cbBeniHatirla" && cb.Checked);

                        if (cbBeniHatirla != null)
                        {
                            var tbEmail = gb.Controls.OfType<TextBox>()
                                .FirstOrDefault(tb => tb.Name == "tbEmail");

                            if (tbEmail != null)
                            {
                                sw.Write(tbEmail.Text);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Hatırlama bilgisi eklenirken hata: {ex.Message}");
            }
        }

        public void ReadRememberance(TextBox tb)
        {
            try
            {
                using (StreamReader sr = new StreamReader(FILE_PATH))
                {
                    tb.Text = sr.ReadLine();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Hatırlama bilgisi okunurken hata: {ex.Message}");
            }
        }

        public void InitializeListView(ListView listView)
        {
            try
            {
                ConfigureListViewBase(listView);

                var columns = new Dictionary<string, int>
                {
                    {"ID", 60},
                    {"Ürün Adı", 180},
                    {"Marka", 180},
                    {"Kalori", 180},
                    {"Doymuş Yağ", 180},
                    {"Trans Yağ", 180},
                    {"Tekli Doymamış Yağ", 360},
                    {"Çoklu Doymamış Yağ", 360},
                    {"Protein", 120},
                    {"Karbonhidrat", 180},
                    {"Şeker", 120},
                    {"Sodyum", 120},
                    {"Fiber", 120},
                    {"Potasyum", 120},
                    {"Kategori", 120}
                };

                foreach (var column in columns)
                {
                    listView.Columns.Add(column.Key, column.Value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"ListView başlatılırken hata: {ex.Message}");
            }
        }

        private void ConfigureListViewBase(ListView listView)
        {
            listView.Enabled = true;
            listView.View = View.Details;
            listView.AllowColumnReorder = true;
            listView.FullRowSelect = true;
            listView.GridLines = true;
        }

        public void PopulateListView(List<Urun> urunler, ListView listView)
        {
            try
            {
                listView.Items.Clear();
                for (int i = 0; i < urunler.Count; i++)
                {
                    var urun = urunler[i];
                    var item = new ListViewItem(new[]
                    {
                        urun.UrunID.ToString(),
                        urun.UrunAdi,
                        urun.Marka,
                        urun.Kalori.ToString(),
                        urun.DoymusYag.ToString(),
                        urun.TransYag.ToString(),
                        urun.CokluDoymamisYag.ToString(),
                        urun.TekliDoymamisYag.ToString(),
                        urun.Karbonhidrat.ToString(),
                        urun.Seker.ToString(),
                        urun.Protein.ToString(),
                        urun.Sodyum.ToString(),
                        urun.Potasyum.ToString(),
                        urun.Fiber.ToString(),
                        urun.Kategori
                    });
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"ListView doldurulurken hata: {ex.Message}");
            }
        }

      

       

        public bool IsValidEmail(string email)
        {
            const string EMAIL_PATTERN = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            try
            {
                if (Regex.IsMatch(email, EMAIL_PATTERN))
                    return true;

                MessageBox.Show("Lütfen geçerli bir e-posta adresi giriniz.");
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"E-posta doğrulama hatası: {ex.Message}");
            }
        }

        public bool IsValidPassword(string password)
        {
            const string PASSWORD_PATTERN = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?.&])[A-Za-z\d@$!%*?&]{8,}$";
            try
            {
                if (Regex.IsMatch(password, PASSWORD_PATTERN))
                    return true;

                MessageBox.Show("Şifre en az 8 karakter olmalı, bir büyük harf, bir küçük harf, " +
                              "bir rakam ve bir özel karakter içermelidir.");
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Şifre doğrulama hatası: {ex.Message}");
            }
        }

        // Image handling utilities
        public byte[] ImageToByteArray(Image image)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Resim byte dizisine dönüştürülürken hata: {ex.Message}");
            }
        }

        public Image ByteArrayToImage(byte[] byteArray)
        {
            try
            {
                using (var ms = new MemoryStream(byteArray))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Byte dizisi resme dönüştürülürken hata: {ex.Message}");
            }
        }
        /// <summary>
        /// Kullanıcının belirli bir gün için almış olduğu toplam kaloriyi hesaplar ve arayüzü günceller.
        /// </summary>
        /// <param name="lbl">Alınan kalori miktarını gösterecek Label kontrolü</param>
        /// <param name="dt">Hesaplanacak gün</param>
        /// <param name="pb">İlerleme durumunu gösterecek ProgressBar kontrolü</param>
        /// <param name="usermail">Kullanıcının email adresi</param>
        /// <exception cref="Exception">Kalori hesaplama sırasında oluşan hatalar için fırlatılır</exception>
        public void AlinmisKaloriHesaplaVeGuncelle(Label lbl, DateTime dt, ProgressBar pb, string usermail)
        {
            try
            {
                var gunUrunDetayRepo = new GenericRepository<GunUrunDetay>();
                var kullaniciRepo = new GenericRepository<Kullanici>();

                var kullanici = kullaniciRepo.RepGetByConditionKullanici(usermail);
                var gunUrunDetaylar = gunUrunDetayRepo.RepGetAll();

                double totalCalories = 0;

                if (gunUrunDetaylar.Any())
                {
                    totalCalories = gunUrunDetaylar
                        .Where(gud => gud.Gun.BugununTarihi == dt && gud.UserID == kullanici.UserID)
                        .Sum(gud => gud.AlinmisKalori);
                }

                lbl.Text = totalCalories.ToString();
                pb.Value = (int)totalCalories;
            }
            catch (Exception ex)
            {
                throw new Exception($"Kalori hesaplama hatası: {ex.Message}");
            }
        }

        /// <summary>
        /// Harris-Benedict denklemi kullanarak kullanıcının hedef kalori miktarını hesaplar ve arayüzü günceller.
        /// </summary>
        /// <param name="progressBar1">Kalori alımı ilerleme durumunu gösterecek ProgressBar kontrolü</param>
        /// <param name="lblHedefKalori">Hedef kalori miktarını gösterecek Label kontrolü</param>
        /// <param name="kullanici">Kalori hesaplaması yapılacak kullanıcı</param>
        /// <exception cref="Exception">Hedef kalori hesaplama sırasında oluşan hatalar için fırlatılır</exception>
        public void HedefKaloriHesaplaVeAta(ProgressBar progressBar1, Label lblHedefKalori, Kullanici kullanici)
        {
            try
            {
                double boy = kullanici.Boy;
                double kilo = kullanici.HedefKilo;
                double yas = DateTime.Now.Year - kullanici.DogumTarihi.Year;

                // Harris-Benedict denklemi
                double hedefKalori = kullanici.Sex == "Erkek"
                    ? 66.47 + (13.75 * kilo) + (5 * boy) - (6.76 * yas)
                    : 655.10 + (9.56 * kilo) + (1.85 * boy) - (4.68 * yas);

                lblHedefKalori.Text = hedefKalori.ToString();
                progressBar1.Maximum = Convert.ToInt32(hedefKalori);
            }
            catch (Exception ex)
            {
                throw new Exception($"Hedef kalori hesaplama hatası: {ex.Message}");
            }
        }

        /// <summary>
        /// Belirli bir kullanıcının en çok tercih ettiği yemeği bulur ve ilgili etikette gösterir.
        /// </summary>
        /// <param name="kul">İşlem yapılacak kullanıcı</param>
        /// <param name="lbl">Sonucu gösterecek Label kontrolü</param>
        /// <exception cref="Exception">En çok tercih edilen yemek hesaplanırken oluşan hatalar için fırlatılır</exception>
        public void EnCokTercihEdilenYemek(Kullanici kul, Label lbl)
        {
            try
            {
                var gudRepository = new GenericRepository<GunUrunDetay>();
                var urunRepository = new GenericRepository<Urun>();

                var kullaniciUrunler = gudRepository.RepGetAll()
                    .Where(gud => gud.UserID == kul.UserID)
                    .Select(gud => gud.UrunID);

                if (!kullaniciUrunler.Any())
                {
                    lbl.Text = "Henüz yemek tercihi yok";
                    return;
                }

                var mostFrequentUrunId = kullaniciUrunler
                    .GroupBy(id => id)
                    .OrderByDescending(g => g.Count())
                    .First()
                    .Key;

                var urun = urunRepository.RepGetById(mostFrequentUrunId);
                lbl.Text = $"{urun.UrunAdi} {urun.Kategori}";
            }
            catch (Exception ex)
            {
                throw new Exception($"En çok tercih edilen yemek hesaplama hatası: {ex.Message}");
            }
        }

        /// <summary>
        /// Tüm kullanıcılar arasında en çok tercih edilen yemeği bulur ve ilgili etikette gösterir.
        /// </summary>
        /// <param name="lbl">Sonucu gösterecek Label kontrolü</param>
        /// <exception cref="Exception">En çok tercih edilen yemek hesaplanırken oluşan hatalar için fırlatılır</exception>
        public void EnCokTercihEdilenYemek(Label lbl)
        {
            try
            {
                var gudRepository = new GenericRepository<GunUrunDetay>();
                var urunRepository = new GenericRepository<Urun>();

                var allUrunIds = gudRepository.RepGetAll()
                    .Select(gud => gud.UrunID);

                if (!allUrunIds.Any())
                {
                    lbl.Text = "Henüz yemek tercihi yok";
                    return;
                }

                var mostFrequentUrunId = allUrunIds
                    .GroupBy(id => id)
                    .OrderByDescending(g => g.Count())
                    .First()
                    .Key;

                var urun = urunRepository.RepGetById(mostFrequentUrunId);
                lbl.Text = $"{urun.UrunAdi} {urun.Kategori}";
            }
            catch (Exception ex)
            {
                throw new Exception($"En çok tercih edilen yemek hesaplama hatası: {ex.Message}");
            }
        }

        /// <summary>
        /// Tüm kullanıcılar arasında en çok tercih edilen öğün zamanını bulur ve ilgili etikette gösterir.
        /// </summary>
        /// <param name="lbl">Sonucu gösterecek Label kontrolü</param>
        /// <exception cref="Exception">En çok tercih edilen öğün hesaplanırken oluşan hatalar için fırlatılır</exception>
        public void EnCokTercihEdilenOgunum(Label lbl)
        {
            try
            {
                var gudRepository = new GenericRepository<GunUrunDetay>();

                var allMealTimes = gudRepository.RepGetAll()
                    .Select(gud => gud.GununZamani);

                if (!allMealTimes.Any())
                {
                    lbl.Text = "Henüz öğün tercihi yok";
                    return;
                }

                var mostFrequentMealTime = allMealTimes
                    .GroupBy(time => time)
                    .OrderByDescending(g => g.Count())
                    .First()
                    .Key;

                lbl.Text = mostFrequentMealTime;
            }
            catch (Exception ex)
            {
                throw new Exception($"En çok tercih edilen öğün hesaplama hatası: {ex.Message}");
            }
        }

        /// <summary>
        /// Belirli bir kullanıcının en çok tercih ettiği öğün zamanını bulur ve ilgili etikette gösterir.
        /// </summary>
        /// <param name="kul">İşlem yapılacak kullanıcı</param>
        /// <param name="lbl">Sonucu gösterecek Label kontrolü</param>
        /// <exception cref="Exception">En çok tercih edilen öğün hesaplanırken oluşan hatalar için fırlatılır</exception>
        public void EnCokTercihEdilenOgunum(Kullanici kul, Label lbl)
        {
            try
            {
                var gudRepository = new GenericRepository<GunUrunDetay>();

                var userMealTimes = gudRepository.RepGetAll()
                    .Where(gud => gud.UserID == kul.UserID)
                    .Select(gud => gud.GununZamani);

                if (!userMealTimes.Any())
                {
                    lbl.Text = "Henüz öğün tercihi yok";
                    return;
                }

                var mostFrequentMealTime = userMealTimes
                    .GroupBy(time => time)
                    .OrderByDescending(g => g.Count())
                    .First()
                    .Key;

                lbl.Text = mostFrequentMealTime;
            }
            catch (Exception ex)
            {
                throw new Exception($"En çok tercih edilen öğün hesaplama hatası: {ex.Message}");
            }
        }
    }
}
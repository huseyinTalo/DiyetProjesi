using _01_DiyetProjesi.DAL;
using _01_DiyetProjesi.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _01_DiyetProjesi.DATA.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class, new()
    {
        public AppDbContext context;

        public GenericRepository()
        {
            context = new AppDbContext();
        }
        public List<TEntity> RepGetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        //GetById

        public TEntity RepGetById(int id)
        {
            try
            {
                return context.Set<TEntity>().Find(id);
            }
            catch (Exception)
            {
                throw new Exception("Aranılan kayıt bulunamadı");
            }
        }
        //Find by condition GunUrunDetay
        public List<GunUrunDetay> RepGetbyConditionGunUrunDetay(DateTime dt)
        {

            try
            {
                Gun gu = context.Gunler.FirstOrDefault(x => x.BugununTarihi.Date == dt.Date);


                List<GunUrunDetay> gudList = context.GunUrunDetaylari.Where(x => x.GunID == gu.GunID).ToList();
                return gudList;
            }
            catch (Exception)
            {

                throw new Exception("Getirme işi yaş");
            }
        }

        //Find by Condition Gun için spesifik. bunu entityli yapmadım çünkü  parametre sadece gün için var.
        public Gun RepGetByConditionGun(DateTime dtt)
        {
            try
            {
                Gun gu = context.Gunler.FirstOrDefault(x => x.BugununTarihi.Date == dtt.Date);
                return gu;
            }
            catch (Exception)
            {
                throw new Exception("Getirme işi yaş");
            }


        }
        //Find by Condition Gun için spesifik. bunu entityli yapmadım çünkü  parametre sadece gün için var.
        //public GunUrunDetay RepGetByConditionGunDetay(dt)
        //{
        //    GunUrunDetay gu = context.GunUrunDetaylari.FirstOrDefault(x => x.Gun.BugununTarihi.Date == dt);
        //    return gu;
        //} ?????????????????????????????????????????
        //generic seçmedim çünkü spesific kullanıcıya.
        public Kullanici RepGetByConditionKullanici(string s)
        {
            try
            {
                Kullanici ku = context.Kullanicilar.FirstOrDefault(x => x.Email == s);
                return ku;
            }
            catch (Exception ex)
            {
                throw new Exception("Getirme işi yaş");
            }
        }
        //urun için spesifik
        public List<Urun> RepGetByConditionUrun(int kosulOperatoru, string kosul)
        {

            try
            {
                List<Urun> urunler = new List<Urun>();
                switch (kosulOperatoru)
                {
                    case 0:
                        {
                            List<Urun> urunler1 = context.Urunler.Where(x => x.UrunAdi.StartsWith(kosul)).ToList();
                            return urunler1;
                            break;
                        }
                    case 1:
                        {
                            List<Urun> urunler2 = context.Urunler.Where(x => x.UrunAdi.Contains(kosul)).ToList();
                            return urunler2;
                            break;
                        }
                    case 2:
                        {
                            List<Urun> urunler3 = context.Urunler.Where(x => x.UrunAdi.EndsWith(kosul)).ToList();
                            return urunler3;
                            break;
                        }
                    default:
                        {

                            break;
                        }
                }
                return urunler;

            }
            catch (Exception ex)
            {
                throw new Exception("Getirme işi yaş");
            }
        }


        //Add
        public int RepAdd(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Add(entity);
                return context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ekleme işlemi başarısız oldu");
            }
        }

        //Update
        public int RepUpdate(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Update(entity);
                return context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Güncelleme işlemi başarısız oldu");
            }
        }
        //UpdateByID
        public int RepUpdateByID(int id)
        {
            {
                try
                {
                    context.Set<TEntity>().Update(context.Set<TEntity>().Find(id));
                    return context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception("Güncelleme işlemi başarısız oldu");
                }
            }
        }

        //Delete
        public int RepDelete(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Remove(entity);
                return context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Silinemedi");
            }
        }
        //DeleteByID
        public int RepDeleteByID(int id)
        {
            try
            {
                TEntity entity = context.Set<TEntity>().Find(id);
                context.Set<TEntity>().Remove(entity);
                return context.SaveChanges();
            }
            catch
            {
                throw new Exception("Silemedik");
            }
        }
    }
}

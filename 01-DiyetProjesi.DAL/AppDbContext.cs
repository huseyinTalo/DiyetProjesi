using _01_DiyetProjesi.DAL.Mapping;
using _01_DiyetProjesi.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _01_DiyetProjesi.DAL
{
    public class AppDbContext : DbContext
    {
        public  DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Gun> Gunler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<GunUrunDetay> GunUrunDetaylari { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-9FIH8LL;Initial Catalog=HS-15DiyetProjesiDB;Integrated Security=True;TrustServerCertificate=True");
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new GunMapping().Configure(modelBuilder.Entity<Gun>());
            new KullaniciMapping().Configure(modelBuilder.Entity<Kullanici>());
            new UrunMapping().Configure(modelBuilder.Entity<Urun>());
            new GunUrunMapping().Configure(modelBuilder.Entity<GunUrunDetay>());

            
            base.OnModelCreating(modelBuilder);
        }
    }
}

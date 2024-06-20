using _01_DiyetProjesi.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DiyetProjesi.DAL.Mapping
{
    public class GunUrunMapping : IEntityTypeConfiguration<GunUrunDetay>
    {
        public void Configure(EntityTypeBuilder<GunUrunDetay> builder)
        {
            

            builder.HasKey(e => new { e.UrunID, e.GunID, e.UserID});

            builder.HasOne(e => e.Gun)
            .WithMany(e => e.GunUrunDetaylar)
            .HasForeignKey(e => e.GunID);

            builder.HasOne(e => e.Urun)
            .WithMany(e => e.UrunGunDetaylar)
            .HasForeignKey(e => e.UrunID);

           builder.HasOne(e => e.Kullanici).WithMany(e => e.GunUrunDetays).HasPrincipalKey(e => e.UserID).HasForeignKey(e => e.UserID);

        }
    }
}

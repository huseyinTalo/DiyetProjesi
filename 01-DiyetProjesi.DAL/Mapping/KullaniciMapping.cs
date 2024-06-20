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
    public class KullaniciMapping : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            builder.HasKey(o => o.UserID);
            builder.Property(c => c.Email).IsRequired(); //üşenmezsen unique yap


            
            builder.Property(c => c.Password).IsRequired();
            ///* builder.Property(c => c.UserID).UseIdentityColumn(1,1);*///bunu vermezsen userid ve gunid birlikte composite olduğundan ekleme yaparken patlıyor. verirsen de composite keyin identitysi olamaz.
            //builder.Property(c => c.UserID).ValueGeneratedOnAdd(); //composite kullanıyosan identity yerine bunu kullan zortlamaması için.
            //bunların hiçbirine gerek yok ara tablo yap.

        }
    }
}

using _01_DiyetProjesi.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DiyetProjesi.DAL.Mapping
{
    public class GunMapping : IEntityTypeConfiguration<Gun>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Gun> builder)
        {
            builder.HasKey(o => o.GunID);
            
            builder.Property(o => o.BugununTarihi).IsRequired();
            
            

        }
    }
}

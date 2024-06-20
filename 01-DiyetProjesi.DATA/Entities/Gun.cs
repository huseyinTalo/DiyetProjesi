using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_DiyetProjesi.DATA.Entities
{
    public class Gun
    {
        public int GunID { get; set; }
        
        public DateTime BugununTarihi { get; set; }

        

        //nav property
        public virtual List<Kullanici> Kullanicilar { get; set; }

        public virtual List<GunUrunDetay> GunUrunDetaylar { get; set; }
    }
}

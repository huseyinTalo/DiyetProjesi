using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DiyetProjesi.DATA.Entities
{
    public class GunUrunDetay
    {
        public int GunID { get; set; }
        public int UrunID { get; set; }

        public int UserID { get; set; }
        //navprop
        public virtual Gun Gun { get; set; }
        public virtual Urun Urun { get; set; }
        public virtual Kullanici Kullanici { get; set; }


        public double UrunGramaj { get; set; }
        public double AlinmisKalori { get; set; }

        public string GununZamani { get; set; }

    }
}

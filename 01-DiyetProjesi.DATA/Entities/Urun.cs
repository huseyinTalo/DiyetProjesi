using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DiyetProjesi.DATA.Entities
{
    public class Urun
    {
        
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public int Kalori { get; set; }
        public string Marka { get; set; }
        public double DoymusYag { get; set; }
        public double TransYag { get; set; }
        public double TekliDoymamisYag { get; set; }
        public double CokluDoymamisYag { get; set; }
        public double Protein { get; set; }
        public double Karbonhidrat { get; set; }
        public double Seker { get; set; }
        public double Sodyum { get; set; }
        public double Fiber { get; set; }
        public double Potasyum { get; set; }
        public string Kategori { get; set; }
        public byte[] ImageData { get; set; }

        //navprop
        public virtual List<GunUrunDetay> UrunGunDetaylar { get; set; }

    }
}

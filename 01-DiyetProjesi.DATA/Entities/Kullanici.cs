using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DiyetProjesi.DATA.Entities
{
    public class Kullanici
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public double HedefKilo { get; set; }
        public string Sex { get; set; }


        private DateTime _dogumTarihi;

        public DateTime DogumTarihi
        {
            get { return _dogumTarihi; }
            set
            {
                if (value > DateTime.Now.AddYears(-18))
                {
                    throw new InvalidOperationException("You cannot set the birth date to a date within the last 18 years.");
                }
                _dogumTarihi = value;
            }
        }
        public int Boy { get; set; }
        
        public double GuncelKilo { get; set; }
        public DateTime KayitTarihi { get; set; }
        //nav property
        public virtual List<Gun> Gunler { get; set; }

        public virtual List<GunUrunDetay> GunUrunDetays { get; set; }
    }
}

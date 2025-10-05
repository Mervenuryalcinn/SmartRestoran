using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeforms.model
{
    public class Siparis
    {
        public int SiparisID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string TeslimatAdresi { get; set; }
        public decimal ToplamTutar { get; set; }
        public string Durum { get; set; }
        public DateTime Tarih { get; set; }
    }


    public class SiparisDetay
    {
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public decimal BirimFiyat { get; set; }
    }
}

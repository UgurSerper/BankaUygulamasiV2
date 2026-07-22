using System;

namespace Banka
{
    public class Kullanici
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int KullaniciNo { get; set; }
        public string Sifre { get; set; }
        public decimal Bakiye { get; set; }
        public KullaniciRolu Rol { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public bool KilitliMi { get; set; }
        public List<Islem> IslemGecmisi{get;set;}

        public Kullanici(
            string ad,
            string soyad,
            int kullaniciNo,
            string sifre,
            decimal bakiye,
            KullaniciRolu rol)
        {
            Ad = ad;
            Soyad = soyad;
            KullaniciNo = kullaniciNo;
            Sifre = sifre;
            Bakiye = bakiye;
            Rol = rol;
            OlusturmaTarihi = DateTime.Now;
            KilitliMi = false;
            IslemGecmisi = new List<Islem>();
        }
    }
}

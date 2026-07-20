namespace Banka
{
    public class KullaniciServices
    {
        private List<Kullanici> kullanicilar = new List<Kullanici>();

        public KullaniciServices() 
        { 
            Kullanici musteri = new Kullanici("Ugur","Aslan",1,"5656aslan",1000.00m,KullaniciRolu.Musteri, new DateTime(2025,1,1));
            Kullanici musteri2 = new Kullanici("Ibrahim","Aslan",2,"5656aslan",1000.00m,KullaniciRolu.Musteri, new DateTime(2024,1,1));
            Kullanici musteri3 = new Kullanici("Musa","Aslan",3,"5656aslan",1000.00m,KullaniciRolu.Musteri, new DateTime(2023,1,1));

            kullanicilar.Add(musteri);
            kullanicilar.Add(musteri2);
            kullanicilar.Add(musteri3);
        }

        public void KullaniciEkle()
        {
            
        }
        public void KullaniciListele()
        {
            
        }
        public Kullanici GirisYap()
        {
            return null;
        }
        public void KullaniciSil()
        {
            
        }
        public void HesapKilitle()
        {
            
        }
        public void HesapKilidiniAc()
        {
            
        }
    }
}
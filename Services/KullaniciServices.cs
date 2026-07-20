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
            
            string ad, soyad, sifre;
            decimal bakiye;
            int kullanicinNo = 0;
            KullaniciRolu kullaniciRolu = KullaniciRolu.Musteri;

            Console.Write("Ad : ");
            ad = Console.ReadLine();

            Console.Write("Soyad : ");
            soyad = Console.ReadLine();
            
            Console.Write("Sifre : ");
            sifre = Console.ReadLine();

            Console.WriteLine("Bakiye : ");
            if (!decimal.TryParse(Console.ReadLine(), out bakiye))
            {
                Console.WriteLine("Gecerli bir sayi giriniz");
                return;
            }
            if(bakiye < 0)
            {
                Console.WriteLine("Bakiye negatif olamaz.");
                return;
            }

            int enBuyukKullaniciNo = 0;

            foreach (Kullanici kullanici in kullanicilar)
            {
                
                if (enBuyukKullaniciNo < kullanici.KullaniciNo)
                {
                    enBuyukKullaniciNo = kullanici.KullaniciNo;
                }

            }

            kullanicinNo = enBuyukKullaniciNo + 1;

            Kullanici yeniKullanici = new Kullanici(ad, soyad, sifre, bakiye, kullanicinNo);

            kullanicilar.Add(yeniKullanici);

            Console.WriteLine("Ekleme Basarili!");

        }
        public void KullaniciListele()
        {
            
        }
        public Kullanici GirisYap()
        {
            int kullaniciNo;
            string sifre;
            

            Console.Write("Kullanici No : ");
            if (!int.TryParse(Console.ReadLine(), out kullaniciNo))
            {
                Console.WriteLine("Gecerli bir sayi giriniz");
                return null;
            }
            if (kullaniciNo < 0)
            {
                Console.WriteLine("kullaniciNo negatif olamaz.");
                return null;
            }

            Console.Write("Sifre : ");
            sifre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(sifre))
            {
                Console.WriteLine("Şifre boş olamaz.");
                return null;
            }

            foreach(Kullanici kullanici in kullanicilar)
            {
                if(kullanici.KullaniciNo == kullaniciNo && kullanici.Sifre == sifre)
                {
                    if (kullanici.KilitliMi)
                    {
                        Console.WriteLine("Hesap kilitlenmistir.");
                        return null;
                    }

                    return kullanici;
                }
                
            }
            Console.WriteLine("Kullanici no ve ya sifre yanlis lutfen tekrar deneyiniz");
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
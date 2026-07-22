namespace Banka
{
    public class KullaniciServices
    {
        private List<Kullanici> kullanicilar = new List<Kullanici>();

        public KullaniciServices() 
        { 
            Kullanici musteri = new Kullanici("Ugur","Aslan",1,"5656aslan",1000.00m,KullaniciRolu.Musteri);
            Kullanici musteri2 = new Kullanici("Ibrahim","Aslan",2,"5656aslan",1000.00m,KullaniciRolu.Musteri);
            Kullanici musteri3 = new Kullanici("Musa","Aslan",3,"5656aslan",1000.00m,KullaniciRolu.Musteri);
            Kullanici admin = new Kullanici("Yakup","Aslan",4,"5656aslan",0,KullaniciRolu.Admin);

            kullanicilar.Add(musteri);
            kullanicilar.Add(musteri2);
            kullanicilar.Add(musteri3);
            kullanicilar.Add(admin);
        }

        public void KullaniciEkle()
        {
            
            string? ad, soyad, sifre;
            decimal bakiye;
            int kullanicinNo = 0;
            KullaniciRolu kullaniciRolu = KullaniciRolu.Musteri;

            Console.Write("Ad : ");
            ad = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ad))
            {
                Console.WriteLine("Ad boş olamaz");
                return;
            }

            Console.Write("Soyad : ");
            soyad = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(soyad))
            {
                Console.WriteLine("Soyad boş olamaz");
                return;
            }
            
            Console.Write("Sifre : ");
            sifre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(sifre))
            {
                Console.WriteLine("Sifre boş olamaz");
                return;
            }

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

            Kullanici yeniKullanici = new Kullanici(ad, soyad,kullanicinNo, sifre, bakiye ,KullaniciRolu.Musteri);

            kullanicilar.Add(yeniKullanici);

            Console.WriteLine("Ekleme Basarili!");

        }
        public void KullaniciListele()
        {
            foreach(Kullanici kullanici in kullanicilar)
            {
                Console.WriteLine($"Kullanici Adi : {kullanici.Ad}");
                Console.WriteLine($"Kullanici Soyadi : {kullanici.Soyad}");
                Console.WriteLine($"Kullanici Numarası : {kullanici.KullaniciNo}");
                Console.WriteLine($"Kullanici Bakiyesi : {kullanici.Bakiye}");
                Console.WriteLine($"Kullanici Olsturma Tarihi: {kullanici.OlusturmaTarihi}");
                Console.WriteLine($"Kullanici Rolu : {kullanici.Rol}");
                Console.WriteLine($"Hesap Kilitli Mi : {kullanici.KilitliMi}");
            }
        }
        public Kullanici GirisYap()
        {
            int kullaniciNo;
            string? sifre;
            

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
            int kullaniciNo;
            Kullanici? silinecekKullanici = null;
            Console.WriteLine("kullanici No : ");
            if (!int.TryParse(Console.ReadLine(), out kullaniciNo))
            {
                Console.WriteLine("Gecerli bir sayi giriniz");
                return;
            }
            if(kullaniciNo < 0)
            {
                Console.WriteLine("kullanici No negatif olamaz.");
                return;
            }
            foreach(Kullanici kullanici in kullanicilar)
            {
                if(kullanici.KullaniciNo == kullaniciNo)
                {
                    silinecekKullanici = kullanici;
                    break;
                }
            }
            if (silinecekKullanici == null)
            {
                Console.WriteLine("Kullanici Bulunamadı Menuye Dönülüyor.");
                return;
            }

            int secim =0;
            Console.WriteLine("1 - Evet");
            Console.WriteLine("2 - Hayır");
            Console.WriteLine("Seçiminiz : ");
            if (!int.TryParse(Console.ReadLine(), out secim))
            {
                Console.WriteLine("Gecerli bir sayi giriniz");
                return;
            }
            if(secim == 1)
            {
                kullanicilar.Remove(silinecekKullanici);
            }
            else if(secim == 2)
            {
                Console.WriteLine("İşlem iptal ediliyor.");
                return;
            }
            else
            {
                Console.WriteLine("Geçersizs seçim");
                return;
            }
            Console.WriteLine("Menuye Dönülüyor.");

        }
        public void HesapKilitle(Kullanici aktifKullanici)
        {
            int kullaniciNo;
            Kullanici? kilitlenecekKullanici = null;
            Console.WriteLine("kullanici No : ");
            if (!int.TryParse(Console.ReadLine(), out kullaniciNo))
            {
                Console.WriteLine("Gecerli bir sayi giriniz");
                return;
            }
            if(kullaniciNo < 0)
            {
                Console.WriteLine("kullanici No negatif olamaz.");
                return;
            }
            foreach(Kullanici kullanici in kullanicilar)
            {
                if(kullanici.KullaniciNo == kullaniciNo)
                {
                    kilitlenecekKullanici = kullanici;
                    if(kilitlenecekKullanici.KilitliMi == true)
                    {
                        Console.WriteLine("Kullanıcı zaten kilitli");
                        return;
                    }
                    kilitlenecekKullanici.KilitliMi=true;
                    Console.WriteLine("Kullanıcı kilitlendi.");
                    Islem islem = new Islem(IslemTipi.KilitKaldir,DateTime.Now,0,$"Admin {kilitlenecekKullanici.KullaniciNo} Nolu Hesabı Kilitledi.");
                    aktifKullanici.IslemGecmisi.Add(islem);
                    return;
                }
            }
            if (kilitlenecekKullanici == null)
            {
                Console.WriteLine("Kullanici Bulunamadı Menuye Dönülüyor.");
                return;
            }
        }
        public void HesapKilidiniAc(Kullanici aktifKullanici)
        {
            int kullaniciNo;
            Kullanici? kilitdiAcilacakKullanici = null;
            Console.WriteLine("kullanici No : ");
            if (!int.TryParse(Console.ReadLine(), out kullaniciNo))
            {
                Console.WriteLine("Gecerli bir sayi giriniz");
                return;
            }
            if(kullaniciNo < 0)
            {
                Console.WriteLine("kullanici No negatif olamaz.");
                return;
            }
            foreach(Kullanici kullanici in kullanicilar)
            {
                if(kullanici.KullaniciNo == kullaniciNo)
                {
                    kilitdiAcilacakKullanici = kullanici;
                    if(kilitdiAcilacakKullanici.KilitliMi == false)
                    {
                        Console.WriteLine("Kullanıcı zaten açık.");
                        return;
                    }
                    kilitdiAcilacakKullanici.KilitliMi=false;
                    Console.WriteLine("Kullanıcı Kilidi Açıldı.");
                    Islem islem = new Islem(IslemTipi.KilitAc,DateTime.Now,0,$"Admin {kilitdiAcilacakKullanici.KullaniciNo} Nolu Hesabı Kilitli Açtı.");
                    aktifKullanici.IslemGecmisi.Add(islem);
                    return;
                }
            }
            if (kilitdiAcilacakKullanici == null)
            {
                Console.WriteLine("Kullanici Bulunamadı Menuye Dönülüyor.");
                return;
            }
        }
       public List<Kullanici> Kullanicilar
        {
            get {return kullanicilar;}
        }
    }
}
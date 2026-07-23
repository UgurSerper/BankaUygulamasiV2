using System.Linq;
namespace Banka
{
    public class KullaniciServices
    {
        private List<Kullanici> kullanicilar = new List<Kullanici>();
        BankaServices bs = new BankaServices();

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
            if (!kullanicilar.Any())
            {
                Console.WriteLine("Kayıtlı kullanıcı bulunamadı");
                return;
            }
            foreach(Kullanici kullanici in kullanicilar)
            {
                KullaniciBilgileriniGetir(kullanici);
            }
        }
        public void KililiKullaniciListele()
        {
            if (!kullanicilar.Any())
            {
                Console.WriteLine("Kayıtlı kullanıcı bulunamadı");
                return;
            }
            if(!kullanicilar.Any(k => k.KilitliMi))
            {
                Console.WriteLine("kilitli kullanici bulunamadı");
                return;
            }
            foreach(Kullanici kullanici in kullanicilar.Where(k => k.KilitliMi))
            {
               KullaniciBilgileriniGetir(kullanici);
            }
        }
        private void KullaniciBilgileriniGetir(Kullanici kullanici)
        {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine($"Kullanici Adi : {kullanici.Ad}");
                Console.WriteLine($"Kullanici Soyadi : {kullanici.Soyad}");
                Console.WriteLine($"Kullanici Numarası : {kullanici.KullaniciNo}");
                Console.WriteLine($"Kullanici Bakiyesi : {kullanici.Bakiye}");
                Console.WriteLine($"Kullanici Olsturma Tarihi: {kullanici.OlusturmaTarihi}");
                Console.WriteLine($"Kullanici Rolu : {kullanici.Rol}");
                Console.WriteLine($"Hesap Kilitli Mi : {kullanici.KilitliMi}");
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

            Kullanici? kullanici = kullanicilar.FirstOrDefault(k => k.KullaniciNo == kullaniciNo && k.Sifre == sifre);

            if(kullanici == null)
            {
                Console.WriteLine("Kullanıcı no veya şifre yanlış.");
                return null;            
            }
            Console.WriteLine("Giriş Başarılı.");
            return kullanici;
        }
        public void KullaniciSil()
        {
            int kullaniciNo;
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
            Kullanici? kullanici = KullaniciBul(kullaniciNo);
            if (kullanici == null)
            {
                Console.WriteLine("Kullanici Bulunamadı Menuye Dönülüyor.");
                return;
            }

            int secim;
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
                kullanicilar.Remove(kullanici);
                Console.WriteLine("Kullanıcı başarıyla silindi.");
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
        private Kullanici? KullaniciBul(int kullaniciNo)
        {
            return kullanicilar.FirstOrDefault(k => k.KullaniciNo == kullaniciNo);
        }
        public void HesapKilitle(Kullanici aktifKullanici)
        {
            int kullaniciNo;
            Console.WriteLine("kullanici No : ");
            if (!int.TryParse(Console.ReadLine(), out kullaniciNo))
            {
                Console.WriteLine("Gecerli bir sayi giriniz");
                return;
            }
            if(kullaniciNo <= 0)
            {
                Console.WriteLine("kullanici No negatif veya 0 olamaz.");
                return;
            }

            Kullanici? kullanici = KullaniciBul(kullaniciNo);
            if(kullanici == null)
            {
                Console.WriteLine("Kullanici Bulunamadı");
                return;
            }
            if(kullanici.KilitliMi)
            {
                Console.WriteLine("Kullanıcı zaten kilitli");
                return;
            }
                kullanici.KilitliMi=true;
                Console.WriteLine("Kullanıcı kilitlendi.");
                bs.IslemEkle(aktifKullanici,IslemTipi.KilitAc, "Admin hesabı kilitledi");
                return;
        }
        public void HesapKilidiniAc(Kullanici aktifKullanici)
        {
            int kullaniciNo;
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

            Kullanici? kullanici = KullaniciBul(kullaniciNo);
            if(kullanici == null)
            {
                Console.WriteLine("Kullanici Bulunamadı Menuye Dönülüyor.");
                return;
            }
            if(!kullanici.KilitliMi)
            {
                Console.WriteLine("Kullanıcı zaten açık");
                return;
            }
                kullanici.KilitliMi=false;
                Console.WriteLine("Kullanıcı kilidi açıldı.");
                bs.IslemEkle(aktifKullanici,IslemTipi.KilitAc, "Admin hesabı kilidi açıldı.");
                return;
        }
       public List<Kullanici> Kullanicilar
        {
            get {return kullanicilar;}
        }
    }
}
namespace Banka
{
    public class BankaServices
    {
        private readonly KullaniciServices ks;
        private VeritabaniServices vs = new VeritabaniServices();
        public BankaServices(KullaniciServices ks)
        {
            this.ks = ks;
        }
        public void IslemEkle(Kullanici aktifKullanici,IslemTipi tip,string aciklama,decimal tutar=0)
        {
            Islem islem = new Islem(tip,DateTime.Now,tutar,aciklama);
            vs.IslemGecmisi(aktifKullanici.KullaniciNo,tip,DateTime.Now,tutar,aciklama);
            aktifKullanici.IslemGecmisi.Add(islem);
        }
        
        public async Task ParaYatir(Kullanici aktifKullanici)
        {
            decimal yatirilacakBakiye =0;
            Console.Write("Yatırılacak Bakiye : ");
            if(!decimal .TryParse(Console.ReadLine(),out yatirilacakBakiye))
            {
                Console.WriteLine("Geçerli bir sayı giriniz.");
                return;
            }
            if(yatirilacakBakiye<= 0)
            {
                Console.WriteLine("Yatırılacak bakiye negatif olmaz.");
                return;
            }

            aktifKullanici.Bakiye+=yatirilacakBakiye;

            IslemEkle(aktifKullanici,IslemTipi.Yatir,"Para Yatırıldı",yatirilacakBakiye);

            Console.WriteLine($"{yatirilacakBakiye} TL başarıyla yatırıldı.");
            Console.WriteLine($"Güncel Bakiyeniz : {aktifKullanici.Bakiye} TL");

            vs.ParaYatir(aktifKullanici.KullaniciNo,aktifKullanici.Bakiye);
            await DosyaServices.Kaydet(ks.Kullanicilar);

        }
        public async Task ParaCek(Kullanici aktifKullanici)
        {
            decimal cekilecekBakiye =0;
            Console.Write("Cekilecek Bakiye : ");
            if(!decimal .TryParse(Console.ReadLine(),out cekilecekBakiye))
            {
                Console.WriteLine("Geçerli bir sayı giriniz.");
                return;
            }
            if(cekilecekBakiye<= 0)
            {
                Console.WriteLine("Çekilecek bakiye 0dan büyük olmalı.");
                return;
            }
            if(cekilecekBakiye> aktifKullanici.Bakiye)
            {
                Console.WriteLine("Yetersiz Bakiye");
                return;
            }   
            aktifKullanici.Bakiye-=cekilecekBakiye;

            IslemEkle(aktifKullanici,IslemTipi.Cek,"Para Çekildi",cekilecekBakiye);

            Console.WriteLine($"{cekilecekBakiye} TL başarıyla çekildi.");
            Console.WriteLine($"Güncel Bakiyeniz : {aktifKullanici.Bakiye} TL");
            vs.ParaCek(aktifKullanici.KullaniciNo,aktifKullanici.Bakiye);
            await DosyaServices.Kaydet(ks.Kullanicilar);

        }
        public async Task Havale(Kullanici aktifKullanici,List<Kullanici> kullanicilar)
        {
            Kullanici? aliciKullanici = null;
            int aliciKullaniciNo = 0;
            decimal aktarilacakTutar ;
            

            Console.Write("Alici Kullanici No Giriniz : ");
            if (!int.TryParse(Console.ReadLine(), out aliciKullaniciNo))
            {
                Console.WriteLine("Gecerli bir sayi giriniz");
                return;
            }
            if (aliciKullaniciNo < 0)
            {
                Console.WriteLine("negatif sayı olamaz alici numarası");
                return;
            }
            if(aliciKullaniciNo == aktifKullanici.KullaniciNo)
                {
                    Console.WriteLine("Kendinize para gödermezsiniz.");
                    return;
                }

            Console.Write("Gonderilecek Tutar : ");
            if (!decimal.TryParse(Console.ReadLine(), out aktarilacakTutar))
            {
                Console.WriteLine("Gecerli bir sayi giriniz");
                return;
            }
            if(aktarilacakTutar < 0)
            {
                Console.WriteLine("aktarilacak Tutar negatif olamaz.");
                return;
            }
            if(aktifKullanici.Bakiye< aktarilacakTutar)
            {
                Console.WriteLine("aktarilacak Tutar bakiyeden yüksek olamaz.");
                return;
            }
            foreach (Kullanici kullanici in kullanicilar)
            {
                if(kullanici.KullaniciNo == aliciKullaniciNo)
                {
                    aliciKullanici = kullanici;
                    break;
                }

            }
            if (aliciKullanici == null)
            {
                Console.WriteLine("Kullanici bulunamadı.");
                return;
            }

            aktifKullanici.Bakiye-=aktarilacakTutar;
            aliciKullanici.Bakiye+=aktarilacakTutar;

            IslemEkle(aktifKullanici,IslemTipi.HavaleAl,"Para Havale Yapıldı",aktarilacakTutar);

            Console.WriteLine($"Güncel Bakiyen : {aktifKullanici.Bakiye}");
            Console.WriteLine($"Gönderilen Tutar {aktarilacakTutar}");

            vs.Havale(aktifKullanici.KullaniciNo,aliciKullanici.KullaniciNo,aktarilacakTutar);

            await DosyaServices.Kaydet(ks.Kullanicilar);
        }
        public void BakiyeGoster(Kullanici aktifKullanici)
        {
            Console.WriteLine($"Bakiyeniz : {aktifKullanici.Bakiye}");
        }
        public void IslemGecmisi(Kullanici aktifKullanici)
        {
            foreach(Islem islem in aktifKullanici.IslemGecmisi)
            {
                Console.WriteLine($"İşlem : {islem.IslemTipi}");
                Console.WriteLine($"Tarih : {islem.Tarih}");
                Console.WriteLine($"Tutar : {islem.Tutar}");
                Console.WriteLine($"Açıklama : {islem.Aciklama}");
                Console.WriteLine();
            }
        }
    }
}
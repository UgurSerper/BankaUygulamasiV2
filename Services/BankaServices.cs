namespace Banka
{
    public class BankaServices
    {
        
        public void ParaYatir(Kullanici aktifKullanici)
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

            Console.WriteLine($"{yatirilacakBakiye} TL başarıyla çekildi.");
            Console.WriteLine($"Güncel Bakiyeniz : {aktifKullanici.Bakiye} TL");

        }
        public void ParaCek(Kullanici aktifKullanici)
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

            Console.WriteLine($"{cekilecekBakiye} TL başarıyla çekildi.");
            Console.WriteLine($"Güncel Bakiyeniz : {aktifKullanici.Bakiye} TL");


        }
        public void Havale(Kullanici aktifKullanici,List<Kullanici> kullanicilar)
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

            Console.WriteLine($"Güncel Bakiyen : {aktifKullanici.Bakiye}");
            Console.WriteLine($"Gönderilen Tutar {aktarilacakTutar}");

        }
        public void EFT(Kullanici aktifKullanici)
        {
            
        }
        public void BakiyeGoster(Kullanici aktifKullanici)
        {
            Console.WriteLine($"Bakiyeniz : {aktifKullanici.Bakiye}");
        }
        public void IslemGecmisi(Kullanici aktifKullanici)
        {
            
        }
    }
}
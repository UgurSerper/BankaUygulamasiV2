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
        public void Havale(Kullanici aktifKullanici)
        {
            
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
namespace Banka
{
    public class Program
    {
        public void MusteriMenu()
        {

        }

        public void AnaMenu()
        {
            KullaniciServices ks = new KullaniciServices();
            
            int secim = 0;

            while (true)
            {
                Console.WriteLine("===BANKA UYGULAMASI===");
                Console.WriteLine("1 - GIRIS YAP");
                Console.WriteLine("2 - HESAP OLUSTUR");
                Console.WriteLine("0 - CIKIS");
                Console.Write("Seciminiz");

                if(!int.TryParse(Console.ReadLine(), out secim))
                {
                    Console.WriteLine("Lutfen gecerli bir sayi giriniz.");
                    continue;
                }

                switch (secim)
                {
                    case 1: Kullanici aktifKullanici = ks.GirisYap(); if (aktifKullanici != null) {ks.MusteriMenu} break;
                    
                    case 2: ks.KullaniciEkle(); break;

                    case 0: return;

                        default: Console.WriteLine("Lutfen gecerli bir secim giriniz."); break;
                }
            }
        }


        public static void Main(string[] args)
        {
            Program p = new Program();

            p.AnaMenu();
        }
    }
}
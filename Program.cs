namespace Banka
{
    public class Program
    {
        public async Task AdminMenu(Kullanici aktifKullanici , KullaniciServices ks)
        {
            int secim = 0;

            while (true)
            {
                Console.WriteLine("===== Admin Menu =====");
                Console.WriteLine("1 - Kullanici Sil");
                Console.WriteLine("2 - Hesap Kilitle");
                Console.WriteLine("3 - Hesap Kilidini Aç");
                Console.WriteLine("4 - Kullanıcıları Listele");
                Console.WriteLine("5 - Kilitli Kullanıcıları Listele");
                Console.WriteLine("0 - Çıkış");
                Console.Write("Seçiminiz : ");

                if(!int.TryParse(Console.ReadLine() ,out secim))
                {
                    Console.WriteLine("Lütfen geçerli bir sayı giriniz");
                    continue;
                }

                switch (secim)
                {
                    case 1: await ks.KullaniciSil();break;
                    case 2: await ks.HesapKilitle(aktifKullanici);break;
                    case 3: await ks.HesapKilidiniAc(aktifKullanici);break;
                    case 4: ks.KullaniciListele();break;
                    case 5: ks.KililiKullaniciListele();break;
                    case 0: Console.WriteLine("Cıkıs yapılıyor...");return;
                    default:Console.WriteLine("lütfen geçerli bir secim giriniz."); break;
                }
            }
        }
        public async Task MusteriMenu(Kullanici aktifKullanici, KullaniciServices ks)
        {
            BankaServices bk = new BankaServices(ks);
            int secim = 0;

            while (true)
            {
                Console.WriteLine("===== Menu =====");
                Console.WriteLine("1 - Bakiye Görüntüle");
                Console.WriteLine("2 - Para Yatır");
                Console.WriteLine("3 - Para Cek");
                Console.WriteLine("4 - Havale");
                Console.WriteLine("5 - Islem Geçmişi");
                Console.WriteLine("0 - Çıkış");
                Console.Write("Seçiminiz : ");

                if(!int.TryParse(Console.ReadLine() ,out secim))
                {
                    Console.WriteLine("Lütfen geçerli bir sayı giriniz");
                    continue;
                }

                switch (secim)
                {
                    case 1: bk.BakiyeGoster(aktifKullanici);break;
                    case 2: await bk.ParaYatir(aktifKullanici);break;
                    case 3: await bk.ParaCek(aktifKullanici);break;
                    case 4: await bk.Havale(aktifKullanici ,ks.Kullanicilar);break;
                    case 5: bk.IslemGecmisi(aktifKullanici);break;
                    case 0: Console.WriteLine("Cıkıs yapılıyor...");return;
                    default:Console.WriteLine("lütfen geçerli bir secim giriniz."); break;
                }
            }
        }

        public async Task AnaMenu()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
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
                    case 1: 
                    Kullanici aktifKullanici = ks.GirisYap(); 
                    if (aktifKullanici != null)
                    {
                        if(aktifKullanici.Rol == KullaniciRolu.Admin)
                        {
                            await AdminMenu(aktifKullanici,ks);
                        }
                            else
                            {
                               await  MusteriMenu(aktifKullanici,ks);
                            }
                    } 
                     
                    break;
                    
                    case 2: await  ks.KullaniciEkle(); break;

                    case 0: return;

                        default: Console.WriteLine("Lutfen gecerli bir secim giriniz."); break;
                }
            }
        }


        public static async Task Main(string[] args)
        {
            Program p = new Program();

            await p.AnaMenu();
        }
    }
}
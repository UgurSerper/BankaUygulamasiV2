namespace Banka
{
    public class Islem
    {
        public IslemTipi IslemTipi{get;set;}
        public DateTime Tarih{get;set;}
        public decimal Tutar{get;set;}
        public string Aciklama{get;set;}

        public Islem(IslemTipi islemTipi,DateTime tarih,decimal tutar,string aciklama)
        {
            IslemTipi=islemTipi;
            Tarih=tarih;
            Tutar=tutar;
            Aciklama=aciklama;
        }

    }
}
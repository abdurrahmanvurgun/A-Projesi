using EntityLayer;

namespace Armut.Model
{
    public class HizmetZamanTablosu
    {
        public int Id { get; set; }
        public DateTime? BaslangicTarihi { get; set; } //=new DateTime(1,1,1,1,1,1);
        public DateTime? BitisTarihi { get; set; }
        public int AktiviteId { get; set; }
        public virtual Aktivite? Activite { get; set; }
        public int Kota {get; set;}
        public int KatilimciSayisi {get; set;}
        public bool Aktif { get; set; }

        

        //public virtual ýenumerable<useractivitytimetable>? attendantusers { get; set; }
        public virtual List<Kullanici>? TumKatilimciSayisi {get; set; }

        public HizmetZamanTablosu()
        {
            TumKatilimciSayisi = new List<Kullanici>();
        }

    }
}

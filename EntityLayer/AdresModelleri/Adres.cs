using EntityLayer;

namespace Armut.Model
{
    public class Adres
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? Adres1 { get; set; }
        public string? Adres2 { get; set; }
        public int UlkeId { get; set; }
        public virtual Ulke Ulke { get; set; }
        public int SehirId { get; set; }
        public virtual Il Sehir { get; set; }
        public int? IlceId { get; set; }
        public virtual Ilce Ilce { get; set; }
        public int MahalleId { get; set; }
        public virtual Mahalle Mahalle { get; set; }
        public int SemtId { get; set; }
        

        public bool Visibility { get; set; }

        public virtual List<Aktivite> Activiteler { get; set; }
    }
}
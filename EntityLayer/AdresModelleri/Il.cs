namespace Armut.Model
{
    public class Il
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public int UlkeId { get; set; }
        public int? IlceId { get; set; }
        public virtual Ulke? Ulke { get; set; }
        public virtual Ilce? Ilce { get; set; }
        public bool Gorunurluk { get; set; }
        public virtual ICollection<Ulke>? Ulkeler { get; set; }

        public virtual ICollection<Adres>? Adresler { get; set; }

        
    }
}
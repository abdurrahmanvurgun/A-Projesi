namespace Armut.Model
{
    public class Mahalle
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public int SehirId { get; set; }
        public virtual Il? Sehir {get; set;}
        public bool Gorunurluk { get; set; }

        public virtual ICollection<Il>? Sehirler { get; set; }

        public virtual ICollection<Adres>? Adresler {get;set;}
    }
}
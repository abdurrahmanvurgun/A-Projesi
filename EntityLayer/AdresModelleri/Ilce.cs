namespace Armut.Model
{
    public class Ilce
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public int UlkeId { get; set; }
        public virtual Ulke? Ulke { get; set; }
        public virtual ICollection<Il>? Iller { get; set; }
        public bool Gorunurluk { get; set; }
        public virtual ICollection<Adres>? Adresler { get; set; }


     
    }
}
namespace Armut.Model
{
    public class Ulke
    {
        public int Id { get; set; }
        public string? UlkeAd { get; set; }
        //public bool EyaletVarmi { get; set; }
        public bool Gorunurluk { get; set; }
        public virtual ICollection<Ilce>? States {get;set;}
        public virtual ICollection<Il>? Iller {get;set;}
        public virtual ICollection<Adres>? Adresler {get;set;}
        
        
    }
}
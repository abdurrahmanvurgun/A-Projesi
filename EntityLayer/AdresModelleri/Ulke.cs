namespace Armut.Model
{
    public class Ulke
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool HasStates { get; set; }
        public bool Visibility { get; set; }
        public virtual ICollection<Ilce>? States {get;set;}
        public virtual ICollection<Il>? Iller {get;set;}
        public virtual ICollection<Adres>? Adresler {get;set;}
        
        
    }
}
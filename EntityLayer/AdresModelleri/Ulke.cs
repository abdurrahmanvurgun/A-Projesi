using System.ComponentModel.DataAnnotations.Schema;

namespace Armut.Model
{
    public class Ulke
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool HasStates { get; set; }
        public bool Visibility { get; set; }
        public int AdresId { get; set; }
        public virtual ICollection<Il> Iller {get;set;}
        [ForeignKey(nameof(AdresId))]
        public virtual Adres Adres {get;set;}
        
        
    }
}
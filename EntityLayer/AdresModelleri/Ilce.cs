using System.ComponentModel.DataAnnotations.Schema;

namespace Armut.Model
{
    public class Ilce
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public int UlkeId { get; set; }
        public int AdresId { get; set; }

        public virtual Il Il { get; set; }
        public bool Gorunurluk { get; set; }
        [ForeignKey(nameof(AdresId))]
        public virtual Adres Adres { get; set; }


     
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Armut.Model
{
    public class Il
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public int UlkeId { get; set; }
        public int? IlceId { get; set; }
        public int AdresId { get; set; }

        public virtual ICollection<Ilce> Ilceler { get; set; }
        public bool Gorunurluk { get; set; }
        public virtual Ulke Ulke { get; set; }
        [ForeignKey(nameof(AdresId))]
        public virtual Adres Adres { get; set; }

       

        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.AdresModelleri
{
    [Table("İl")]
    public class Il
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public int UlkeId { get; set; }
        public int? IlceId { get; set; }
        public int AdresId { get; set; }
        public virtual ICollection<Ilce> Ilceler { get; set; }

        [ForeignKey(nameof(UlkeId))]
        public virtual Ulke Ulke { get; set; }

        
      
    }
}

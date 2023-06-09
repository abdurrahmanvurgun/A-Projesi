using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.AdresModelleri
{
    [Table("İlçe")]
    public class Ilce
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public int IlId { get; set; }
        public int AdresId { get; set; }
        [ForeignKey(nameof(IlId))]
        public virtual Il Il { get; set; }

        
      
    }
}

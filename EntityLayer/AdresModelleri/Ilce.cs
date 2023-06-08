using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.AdresModelleri
{
    public class Ilce
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public int UlkeId { get; set; }
        public int AdresId { get; set; }

        public virtual Il Il { get; set; }
      
        [ForeignKey(nameof(AdresId))]
        public virtual Adres Adres { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.AdresModelleri
{
    [Table("Ülke")]
    public class Ulke
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdresId { get; set; }
        public virtual ICollection<Il> Iller { get; set; }

        
       
    }
}
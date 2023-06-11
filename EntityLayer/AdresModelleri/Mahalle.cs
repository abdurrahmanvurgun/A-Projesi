using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.AdresModelleri
{
   
    public class Mahalle
    {

        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public int AdresId { get; set; }
        public int IlceId { get; set; }
        [ForeignKey(nameof(IlceId))]
        public virtual Ilce Ilce { get; set; }
       
        
       
    }
}

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
        public int SehirId { get; set; }
        public virtual Ilce Ilce { get; set; }
        public bool Gorunurluk { get; set; }
        [ForeignKey(nameof(AdresId))]
        public virtual Adres Adres { get; set; }
    }
}

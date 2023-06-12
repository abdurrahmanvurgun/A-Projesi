using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Cevap
    {
        [Key]
        public int CevapId { get; set; }
        public int SoruId  { get; set; }
        public string Cevaplar { get; set; }
        public virtual Soru Soru { get; set; }

    }
}

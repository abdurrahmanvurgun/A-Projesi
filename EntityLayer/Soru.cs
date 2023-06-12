using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Soru
    {
        [Key]
        public int SoruId { get; set; }
        public int AltKategoriId { get; set; }
        public string Sorular { get; set; }
        public virtual List<Cevap> Cevaplar { get; set; }
        public virtual AltKategori AltKategori { get; set; }
    }
}

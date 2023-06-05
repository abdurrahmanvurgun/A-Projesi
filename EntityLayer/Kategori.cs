using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string KategoriAdi { get; set; }

        public virtual List<AltKategori> AltKategoriler { get; set; }

        public bool Gorunurluk { get; set; }
        public Kategori()
        {
            AltKategoriler = new List<AltKategori>();
        }
    }
}

//Test atışı........
//Test atışı........222
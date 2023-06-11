using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Table("Alt Kategori")]
    public class AltKategori
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string AltKategoriAdi { get; set; }
        public int KategoriId { get; set; }
        public bool Aktif { get; set; }


        //*****
        public virtual Kategori Kategori { get; set; }
        public virtual List<Soru> Sorular { get; set; }

    }
}

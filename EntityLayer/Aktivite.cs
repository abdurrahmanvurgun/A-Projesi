using Armut.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Aktivite //Teklif İsteği
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }

        [StringLength(350)]
        public string? Mesaj { get; set; }
        public decimal Fiyat { get; set; }

        public string? Resim { get; set; }
        public bool Gorunurluk { get; set; }
        public DateTime OlusturmaTarih { get; set; }

        //*************
        public int AltKategoriId { get; set; }
        public virtual AltKategori AltKategori { get; set; }
        public int AdresId { get; set; }
        public virtual Adres Adres { get; set; }

        [Required]
        public Guid TeklifVerenId { get; set; }
        [Required]
        public Guid TeklifAlanId { get; set; }

        //Teklif istenilen iş eklenicek

        public List<HizmetZamanTablosu> ZamanTablosu { get; set; }
        
        public virtual Kullanici TeklifIsteyen { get; set; } // iş için teklif isteyen kullanıcı
        public virtual Kullanici TeklifVeren { get; set; } //iş için teklif verenler
        public virtual List<KullaniciRol> KullaniciRol { get; set; }


    }
}

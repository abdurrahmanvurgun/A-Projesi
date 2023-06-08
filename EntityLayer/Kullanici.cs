using Armut.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Table("Kullanıcı")]
    public class Kullanici
    {
        [Key]
        public Guid Id { get; set; }
        public string? Ad { get; set; }
        [StringLength(30)]
        public string? Soyad { get; set; }
        [StringLength(50), Required]
        public string Email { get; set; }
        [StringLength(30), Required]
        public string KullaniciAdi { get; set; }
        [StringLength(250), Required]
        public string Sifre { get; set; }
        [MinLength(6), MaxLength(16)]
        [Compare(nameof(Sifre))]
        public string Sifre2 { get; set; }

        [StringLength(5), Required]
        public string Cinsiyet { get; set; }

        public bool Aktif { get; set; }

        public string ProfilResmiDosyaAdi { get; set; }

        public virtual KullaniciRol KullaniciRol { get; set; }
    }


    //****************



}


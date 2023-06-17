using Armut.Model;
using System.ComponentModel.DataAnnotations;

namespace ArmutProjesi.Models
{
    public class RegisterModel
    {
        [Required, StringLength(50)]
        public string KullaniciAdi { get; set; }

        [MinLength(2), MaxLength(30)]
        public string? Ad { get; set; }
        [StringLength(30)]
        public string? Soyad { get; set; }
        [StringLength(100), Required]
        public string Email { get; set; }

        [StringLength(250), Required]
        public string Sifre { get; set; }
        [MinLength(6), MaxLength(16)]
        [Compare(nameof(Sifre))]
        public string Sifre2 { get; set; }

        [StringLength(5), Required]
        public string Cinsiyet { get; set; }
    }
}

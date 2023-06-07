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

        [Required]
        [StringLength(25)]
        public string KullanıcıAdı { get; set; }

        [MinLength(2), MaxLength(30)]
        public string? Ad { get; set; }


        [MinLength(2), MaxLength(30)]
        public string? Soyad { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required, MinLength(6), MaxLength(250)]
        public string Pasword { get; set; }

        public DateTime DogumTarihi { get; set; }

        [StringLength(25)]
        public string? TelefonNumarası { get; set; }
        public bool Aktivate { get; set; }
        public DateTime KayıtTarihi { get; set; }

        [StringLength(255)]
        public string ProfilImagefileName { get; set; }

        [StringLength(10)]
        public string Cinsiyet { get; set; }


        //****************


        public virtual List<Aktivite> TeklifVern { get; set; }
        public virtual List<Aktivite> TeklifAln { get; set; }
        public int HesapId { get; set; }
        public virtual Hesap Hesap { get; set; }

        public int CinsiyetId { get; set; }
        public virtual Cinsiyet Cinsiyeti { get; set;}

        public virtual List<HizmetZamanTablosu> HizmetZamanTablosu { get; set; }
        public virtual KullaniciRol KullaniciRol { get; set; }
        public virtual ICollection<Adres> Adresler { get; set; }

        public Kullanici()
        {
            
        }
    }
}

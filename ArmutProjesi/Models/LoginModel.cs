using System.ComponentModel.DataAnnotations;

namespace ArmutProjesi.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        [StringLength(250), Required]
        public string Sifre { get; set; }
    }
}

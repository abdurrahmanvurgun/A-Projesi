using EntityLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Armut.Model
{
    [Table("Kullanýcý Rol")]
    public class KullaniciRol
    {
        [Key]
        public int RolId { get; set; }
        public Guid KullaniciId { get; set; }

        [ForeignKey(nameof(KullaniciId))]
        public virtual Kullanici Kullanici { get; set; }
        public virtual Rol Rol { get; set; }
    }
}

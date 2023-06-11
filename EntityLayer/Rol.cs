using EntityLayer;
using System.ComponentModel.DataAnnotations;

namespace Armut.Model
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public virtual KullaniciRol KullaniciRol { get; set; }
   
    }
}

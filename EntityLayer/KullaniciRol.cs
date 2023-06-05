using EntityLayer;

namespace Armut.Model
{
    public class KullaniciRol
    {
        public int RolId { get; set; }
        public int KullaniciId { get; set; }
        public virtual Kullanici? Kullanici { get; set; }
        public virtual Rol? Rol { get; set; }
    }
}

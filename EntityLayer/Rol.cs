using EntityLayer;

namespace Armut.Model
{
    public class Rol
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public virtual IEnumerable<KullaniciRol> KullaniciRolleri { get; set; }
        public virtual IEnumerable<Kullanici>? Kullanicilar { get; set; }
    }
}

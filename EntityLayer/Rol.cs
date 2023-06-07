using EntityLayer;

namespace Armut.Model
{
    public class Rol
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public virtual KullaniciRol KullaniciRol { get; set; }
   
    }
}

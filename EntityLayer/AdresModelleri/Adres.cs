using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.AdresModelleri
{
    public class Adres
    {
        public int Id { get; set; }
        public Guid KullaniciId { get; set; }
        public string Adres1 { get; set; }
        public string? Adres2 { get; set; }
        public int UlkeId { get; set; }
        public int SehirId { get; set; }
        public int? IlceId { get; set; }
        public int MahalleId { get; set; }
        public bool Aktif { get; set; }
        
        
        public virtual Ulke Ulke { get; set; }
        public virtual Il Sehir { get; set; }
        public virtual Ilce Ilce { get; set; }
        public virtual Mahalle Mahalle { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}

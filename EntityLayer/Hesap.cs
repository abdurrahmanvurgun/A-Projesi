using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Hesap
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? Sifre { get; set; }

        public bool? Aktif { get; set; }

        public int KullaniciId { get; set; }
        public virtual Kullanici? Kullanici { get; set; }

    }
}

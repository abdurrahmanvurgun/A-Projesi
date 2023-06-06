using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Cinsiyet
    {
        public int Id { get; set; }
        public string Cinsiyeti { get; set; }

        public virtual List<Kullanici> Kullanicilar { get; set; }
    }
}

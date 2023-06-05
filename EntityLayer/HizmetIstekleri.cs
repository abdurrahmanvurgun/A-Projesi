using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class HizmetIstekleri
    {
        public int Id { get; set; }
        public int AktiviteId { get; set; }
        public virtual Aktivite Teklif { get; set; } 
        public virtual Kullanici Kullanici{ get; set; } 


    }
}

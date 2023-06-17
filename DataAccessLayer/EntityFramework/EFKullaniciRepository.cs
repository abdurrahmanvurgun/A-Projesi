using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFKullaniciRepository : GenericRepository<Kullanici>, IKullaniciDal
    {
        DatabaseContext dbContext;
        public EFKullaniciRepository(DatabaseContext db) : base(db)
        {
            dbContext = db;
        }

        public Kullanici Find(string kullaniciAdi, string password)
        {
            return this.dbContext.Set<Kullanici>().FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == password);
        }
    }
}

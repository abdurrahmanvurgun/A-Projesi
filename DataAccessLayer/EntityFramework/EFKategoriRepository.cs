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
    public class EFKategoriRepository : GenericRepository<Kategori>, IKategoriDal
    {
        public EFKategoriRepository(DatabaseContext db) : base(db)
        {
        }
    }
}

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
    public class EFAltKategoriRepository : GenericRepository<AltKategori>, IAltKategoriDal
    {
        public EFAltKategoriRepository(DatabaseContext db) : base(db)
        {

        }
    }
}

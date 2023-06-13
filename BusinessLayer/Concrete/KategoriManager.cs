using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   
    public class KategoriManager:IKategoriService
    {
        IKategoriDal _kategoriDal;
        public KategoriManager(IKategoriDal kategoriDal) { 
          _kategoriDal = kategoriDal;
        }

        public void KategoriAdd(Kategori kategori)
        {
            _kategoriDal.Insert(kategori);
        }
        public void KategoriDelete(Kategori kategori)
        {
            _kategoriDal.Delete(kategori);  
        }

        public void KategoriUpdate(Kategori kategori)
        {
            _kategoriDal.Update(kategori);
        }
        public Kategori GetById(int id)
        {
            return _kategoriDal.GetById(id);
        }
        public List<Kategori> KategoriList()
        {
            return _kategoriDal.GetListAll();
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer;
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
        EFKategoriRepository efKategoriRepository ;
        //public KategoriManager()
        //{
        //    efKategoriRepository = new EFKategoriRepository;
        //}

        public void KategoriAdd(Kategori kategori)
        {
            efKategoriRepository.Insert(kategori);
        }
        public void KategoriDelete(Kategori kategori)
        {
            efKategoriRepository.Delete(kategori);  
        }

        public void KategoriUpdate(Kategori kategori)
        {
            efKategoriRepository.Update(kategori);
        }
        public Kategori GetById(int id)
        {
return efKategoriRepository.GetById(id);
        }
        public List<Kategori> KategoriList()
        {
return efKategoriRepository.GetListAll();
        }
    }
}

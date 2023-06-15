using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IKategoriService
    {
        public void KategoriAdd(Kategori kategori);
        public void KategoriDelete(Kategori kategori);
        public void KategoriUpdate(Kategori kategori);
        public Kategori GetById(int id);
        public List<Kategori> KategoriList();
    }
}

using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IKullaniciService
    {
        public void kullaniciAdd(Kullanici kullanici);
        public void kullaniciDelete(Kullanici kullanici);
        public void kullaniciUpdate(Kullanici kullanici);
        public Kullanici GetById(int id);
        public List<Kullanici> kullaniciList();

    }
}

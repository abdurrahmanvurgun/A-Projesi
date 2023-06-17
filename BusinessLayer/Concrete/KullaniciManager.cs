using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class KullaniciManager: IKullaniciService
    {
        IKullaniciDal _kullaniciDal;

        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }

        public void kullaniciAdd(Kullanici kullanici)
        {
            _kullaniciDal.Insert(kullanici);
        }
        public void kullaniciDelete(Kullanici kullanici)
        {
            _kullaniciDal.Delete(kullanici);
        }
        public void kullaniciUpdate(Kullanici kullanici)
        {
            _kullaniciDal.Update(kullanici);
        }
        public Kullanici GetById(Guid guid)
        {
            return _kullaniciDal.GetById(guid);
        }
        public List<Kullanici> kullaniciList()
        {
            return _kullaniciDal.GetListAll();
        }

		public Kullanici GetById(int id)
		{
			throw new NotImplementedException();
		}

        public Kullanici KullaniciBul(string kullaniciAdi, string sifre)
        {
            return _kullaniciDal.Find(kullaniciAdi, sifre);
        }
    }
}

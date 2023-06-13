using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        DatabaseContext _db;
        public GenericRepository(DatabaseContext db)
        {
            _db = db;
        }

        public void Delete(T t)
        {
            
            _db.Remove(t);   
            _db.SaveChanges();
        }

        public T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public T GetById(Guid guid)
        {
           return _db.Set<T>().Find(guid);
        }

        public List<T> GetListAll()
        {
            return _db.Set<T>().ToList();
        }

        public void Insert(T t)
        {
           _db.Add(t);
            _db.SaveChanges();
        }

        public void Update(T t)
        {
          _db.Update(t);
            _db.SaveChanges();
        }
    }
}

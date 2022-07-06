using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            using (Context context = new Context())
            {
                return context.Set<T>().Where(filter).ToList();
            }
        }


        //bilene sor ona göre bunu kullan
        //public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        //{
        //    using (Context context = new Context())
        //    {
        //        return filter == null
        //            ? context.Set<T>().ToList()
        //            : context.Set<T>().Where(filter).ToList();
        //    }
        //}

        public T GeyById(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        
        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }
}

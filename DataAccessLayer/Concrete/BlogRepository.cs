using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BlogRepository : IBlogDal
    {
        public void Add(Blog blog)
        {
            using (Context context = new Context())
            {
                context.Add(blog);
                context.SaveChanges();
            }
        }

        public void Delete(Blog blog)
        {
            using (Context context=new Context())
            {
                context.Remove(blog);
                context.SaveChanges();
            }
        }

        public List<Blog> GetAll()
        {
            using (Context context = new Context())
            {
                return context.Blogs.ToList();
            }
        }

        public Blog GetById(int id)
        {
            using (Context context = new Context())
            {
                return context.Blogs.Find(id);
            }
        }

        public Blog GeyById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Blog t)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog blog)
        {
            using (Context context = new Context())
            {
                context.Update(blog);
                context.SaveChanges();
            }
        }
    }
}

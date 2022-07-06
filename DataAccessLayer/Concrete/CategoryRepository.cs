using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CategoryRepository : ICategoryDal
    {
        Context context = new Context();
        public void Add(Category category)
        {
            context.Add(category);
            context.SaveChanges();
        }

        public void Delete(Category category)
        {
            context.Remove(category);
            context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            return context.Categories.Find(id);
        }

        public Category GeyById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category t)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            context.Update(category);
            context.SaveChanges();  
        }
    }
}

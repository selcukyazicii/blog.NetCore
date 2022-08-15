using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Add(Category t)
        {
            _categoryDal.Insert(t);
        }        
        public void Delete(Category t)
        {
            _categoryDal.Delete(t);
        }
        public Category GetById(int id)
        {
            return _categoryDal.GeyById(id);
        }
        public List<Category> GetList()
        {
            return _categoryDal.GetAll();
        }
        public void Update(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}

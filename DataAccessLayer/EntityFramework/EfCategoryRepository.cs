using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
       
        public List<CategoryVM> GetCategoryWithBlogCount()
        {

            using (Context context = new Context())
            {
                var result = (from a in context.Categories
                              select new CategoryVM
                              {
                                  CategoryId=a.CategoryId,
                                  CategoryName = a.CategoryName,
                                  BlogCount = context.Blogs.Where(x=> x.CategoryId== a.CategoryId).Count(),
                                  CategoryDescription = a.CategoryDescription

                              }).ToList();
                return result;

            }
        }
    }
}

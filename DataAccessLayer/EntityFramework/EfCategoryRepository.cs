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
       
        public List<CategoryVM> GetCategoryWithBlogCount(Category category)
        {

            using (Context context = new Context())
            {

                var result = (from a in context.Blogs
                              from k in context.Categories.Where(x => x.CategoryId == a.CategoryId)
                              select new CategoryVM
                              {
                                  CategoryName = k.CategoryName,
                                  BlogCount = k.Blogs.Count,
                                  CategoryDescription = k.CategoryDescription

                              }).ToList();
                return result;

            }
        }
    }
}

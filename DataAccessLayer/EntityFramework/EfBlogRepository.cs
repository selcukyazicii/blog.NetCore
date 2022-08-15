using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory(string searchText)
        {
            using (Context context = new Context())
            {
                if (string.IsNullOrEmpty(searchText) == true)
                {
                    var result = context.Blogs.Include(x => x.Category).ToList();
                    return result;
                }
                else
                {
                    var result = context.Blogs.Include(x => x.Category).Where(x => x.BlogTitle.ToLower().Contains(searchText)).ToList();
                    return result;
                }
            }

        }

        public List<BlogListesiVM> BlogListele(int id)
        {
            using (Context context = new Context())
            {
                
                    var result= (from a in context.Blogs.Where(x => x.WriterId == id)
                                 from k in context.Categories.Where(x => x.CategoryId == a.CategoryId).DefaultIfEmpty()
                                 select new BlogListesiVM
                                 {
                                     blogId=a.BlogID,
                                     Title = a.BlogTitle,
                                     CreateDate= a.CreateDate,
                                     Category=k.CategoryName,
                                     blogStatus=a.BlogStatus
                                     

                                 }).ToList();
                    return result;

            }
        }
    }
}

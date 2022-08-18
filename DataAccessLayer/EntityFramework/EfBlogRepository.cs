using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using Entity.Concrete;
using LinqKit;
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

        //id parametresi opsiyonel hale getirildi,varsa id ye göre,yoksa tüm blogları getiriyor
        public List<BlogListesiVM> BlogListele(int id)
        {
            var predicate = PredicateBuilder.New<Blog>();
            
            if (id>0)
            { 
                predicate = predicate.And(te => te.WriterId == id);

            }
            else
            {
                predicate = predicate.And(te => te.WriterId > id);

            }

            using (Context context = new Context())
            {

                var result = (from a in context.Blogs.Where(predicate)
                              from k in context.Categories.Where(x => x.CategoryId == a.CategoryId).DefaultIfEmpty()
                              select new BlogListesiVM
                              {
                                  blogId = a.BlogID,
                                  Title = a.BlogTitle,
                                  CreateDate = a.CreateDate,
                                  Category = k.CategoryName,
                                  blogStatus = a.BlogStatus,
                                  blogImage = a.BlogImage

                              }).ToList();
                return result;

            }
        }
        public List<GetBlogsWithCategoryName> BlogListWithCategoryNamee()
        {
            using (Context context = new Context())
            {
                var result = (from a in context.Blogs
                              from k in context.Categories.Where(x => x.CategoryId == a.CategoryId).DefaultIfEmpty()
                              select new GetBlogsWithCategoryName
                              {
                                  blogId = a.BlogID,
                                  Title = a.BlogTitle,
                                  CreateDate = a.CreateDate,
                                  Category = k.CategoryName,
                                  blogStatus = a.BlogStatus,
                                  blogImage = a.BlogImage,
                                  blogContent = a.BlogContent
                              }).ToList();
                return result;
            }
        }
    }
}

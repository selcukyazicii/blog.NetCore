using DataAccess.Abstract;
using DataAccess.Concrete;
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
        public List<Blog> GetListWithCategory()
        {
            using (Context context=new Context())
            {
               var result= context.Blogs.Include(x => x.Category).ToList();
               return result;
            }
            
        }
    }
}

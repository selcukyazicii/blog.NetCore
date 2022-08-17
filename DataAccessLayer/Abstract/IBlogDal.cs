using Entity;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory(string searchText);
        List<BlogListesiVM> BlogListele(int id);
        List<GetBlogsWithCategoryName> BlogListWithCategoryNamee();
    }
}

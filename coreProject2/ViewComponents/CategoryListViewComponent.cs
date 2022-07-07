using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            //int number=_b
            var values = _categoryManager.GetList();
            return View(values);
        }
    }
}

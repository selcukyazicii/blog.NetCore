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
        EfCategoryRepository repository = new EfCategoryRepository();

        public IViewComponentResult Invoke()
        {
            //var values = _categoryManager.GetList();
           var values= repository.GetCategoryWithBlogCount();
            return View(values);
        }
    }
}

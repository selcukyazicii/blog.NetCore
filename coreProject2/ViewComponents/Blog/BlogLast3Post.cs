using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.ViewComponents.Blog
{
    public class BlogLast3Post:ViewComponent
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var data = _blogManager.GetLast3Blog();
            return View(data);
        }
    }
}

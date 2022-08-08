using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.ViewComponents.Blog
{
    public class WriterLastBlog:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = blogManager.ListBlogByWriter(1);
            return View(values);
        }
    }
}

using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            ViewBag.lastBlog= _blogManager.GetList().OrderByDescending(x => x.CreateDate).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            return View();
        }
    }
}

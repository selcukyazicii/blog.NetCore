using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.Controllers
{
    public class BlogController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = _blogManager.ListCategoryWithBlog();
            return View(values);
        }
        public IActionResult BlogReadMore(int id)
        {
            var values = _blogManager.GetBlogById(id);
            return View(values);
        }
    }
}

using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = _blogManager.ListCategoryWithBlog(string.Empty);
            return View(values);
        }
        public IActionResult BlogReadMore(int id)
        {
            ViewBag.i = id;
            var values = _blogManager.GetBlogById(id);
            return View(values);
        }
        public IActionResult SearchBlog(string searchText)
        {
            var data = _blogManager.ListCategoryWithBlog(searchText);
            return View("Index", data);
        }
    }
}

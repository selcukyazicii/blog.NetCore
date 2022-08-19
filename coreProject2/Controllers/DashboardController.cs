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
    public class DashboardController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.ToplamBlog = _blogManager.GetList().Count();
            ViewBag.ToplamKategoriSayisi = _categoryManager.GetList().Count();
            ViewBag.SizinBlogSayiniz = _blogManager.BlogListele(2).Count();



            var value = _blogManager.BlogListele(0).OrderByDescending(x => x.CreateDate).Take(5).ToList();

            return View(value);
        }
    }
}

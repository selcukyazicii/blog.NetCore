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

        [AllowAnonymous]
        public IActionResult Index()
        {
            //var result = _blogManager.GetList();
            var value = _blogManager.BlogListele(1);

            return View(value);
        }
    }
}

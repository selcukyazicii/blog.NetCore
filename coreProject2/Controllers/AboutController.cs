using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var value = aboutManager.GetList();
            return View(value);
        }

        [HttpGet]
        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}

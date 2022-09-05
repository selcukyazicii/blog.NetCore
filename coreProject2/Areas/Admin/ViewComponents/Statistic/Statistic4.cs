using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.AdminName = _context.Admins.Where(x => x.AdminId == 1).Select(x => x.Name).FirstOrDefault();
            ViewBag.AdminImage = _context.Admins.Where(x => x.AdminId == 1).Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.AdminDescription = _context.Admins.Where(x => x.AdminId == 1).Select(x => x.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}

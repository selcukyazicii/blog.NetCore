using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        //contact manager,comment manager içini doldur,context ile çekme
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.totalBlog = _blogManager.GetList().Count();
            ViewBag.totalContact = _context.Contacts.Count();
            ViewBag.totalComment = _context.Comments.Count();
            return View();
        }
    }
}

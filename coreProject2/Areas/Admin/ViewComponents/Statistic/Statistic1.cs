using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            string api = "7b5a9c3dd65c9a2fdc219650d657c6c1";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Kocaeli&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument xDocument = XDocument.Load(connection);
            ViewBag.Temparature = xDocument.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}

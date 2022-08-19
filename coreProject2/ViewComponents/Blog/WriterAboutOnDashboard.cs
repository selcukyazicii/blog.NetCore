using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.ViewComponents.Blog
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        //dashboard sayfasına yazar hakkında kısmı çekilecek
        WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            var data = _writerManager.GetWriterById(1);

            return View(data);
        }
    }
}

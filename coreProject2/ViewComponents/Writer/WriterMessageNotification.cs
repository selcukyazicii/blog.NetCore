using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

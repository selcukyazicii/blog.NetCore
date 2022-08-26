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
        private readonly Message2Manager _messageManager = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            int id = 2;
            var values = _messageManager.GetInboxListByWriter(id);
            return View(values);
        }
    }
}

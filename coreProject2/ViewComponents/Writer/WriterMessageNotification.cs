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
        private readonly MessageManager _messageManager = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            string p;
            p = "selck453@gmail.com";
            var values = _messageManager.GetInboxListByWriter(p);
            return View(values);
        }
    }
}

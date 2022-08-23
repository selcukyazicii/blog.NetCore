using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
        NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = _notificationManager.GetList().Where(x=>x.NotificationStatus==true).ToList();
            return View(values);
        }
    }
}

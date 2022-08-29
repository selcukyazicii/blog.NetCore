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
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager _message2Manager = new Message2Manager(new EfMessage2Repository());
        [HttpGet]
        public IActionResult InBox()
        {
            int id = 2;
            var value = _message2Manager.GetInboxListByWriter(id);
            return View(value);
        }
        public IActionResult MessageDetails(int id)
        {
            var messageValue = _message2Manager.GetById(id);
            return View(messageValue);
        }
    }
}

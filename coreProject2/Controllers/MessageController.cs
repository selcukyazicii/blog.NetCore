using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
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
        private readonly Context _context;
        public MessageController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult InBox()
        {
            Context context = new Context();
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var result = _message2Manager.GetInboxListByWriter(writerID);
            return View(result);
        }
        public IActionResult MessageDetails(int id)
        {
            var messageValue = _message2Manager.GetById(id);
            return View(messageValue);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 message)
        {
            Context context = new Context();
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            message.SenderId = writerID;
            var result = context.Writers.Where(x => x.WriterMail == message.ReceiverMail).Select(y => y.WriterId).FirstOrDefault();
            message.ReceiverId = result;
            message.MessageStatus = true;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _message2Manager.Add(message);
            return RedirectToAction("Inbox","Message");
        }
        [HttpGet]
        public IActionResult SendBox()
        {
            Context context = new Context();
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var result = _message2Manager.GetInboxListByWriter(writerID);
            return View();
        }
    }
}

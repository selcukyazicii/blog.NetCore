using Business;
using Business.Concrete;
using coreProject2.Entity;
using coreProject2.Models;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.Controllers
{
    public class WriterController : Controller
    {
        WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        [Authorize]
        public IActionResult Index()
        {
            Context context = new Context();
            var writerMail = User.Identity.Name;
            ViewBag.result = writerMail; //giriş yapan kullanıcının mailini tutuyor//writer tablosundaki maili tutuyor

                                    
            var writerName = context.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.name = writerName;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            Context context = new Context();
            var userName = User.Identity.Name;
            ViewBag.name = userName;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var userId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var writer = _writerManager.GetById(userId);
            return View(writer);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {

            _writerManager.Update(writer);
            return RedirectToAction("WriterEditProfile", "Writer");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage addProfileImage)
        {
            var writer = new Writer();
            if (addProfileImage.WriterImage != null)
            {
                var extensions = Path.GetExtension(addProfileImage.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extensions;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFile/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                addProfileImage.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
            }
            writer.WriterMail = addProfileImage.WriterMail;
            writer.WriterName = addProfileImage.WriterName;
            writer.WriterPassword = Utilities.Md5Sifrele(addProfileImage.WriterPassword);
            writer.WriterStatus = true;
            writer.WriterAbout = addProfileImage.WriterAbout;
            _writerManager.Add(writer);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}

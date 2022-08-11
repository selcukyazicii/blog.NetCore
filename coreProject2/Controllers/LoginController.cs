using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Writer writer)
        {
            Context context = new Context();
            var result = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            if (result != null)
            {
                HttpContext.Session.SetString("username", writer.WriterMail);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
        }

        //[HttpPost]
        //public IActionResult Index(Writer writer)
        //{
        //    using (Context context = new Context())
        //    {
        //        var idSifreYanlis = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail&&x.WriterPassword!=writer.WriterPassword);
        //        var giris = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        //        if (giris != null)
        //        {
        //            return RedirectToAction("Index", "Blog");
        //        }
        //        else if (idSifreYanlis != null)
        //        {
        //            throw new Exception("Yanlış Parola");
        //        }
        //        else if(idSifreYanlis==null)
        //        {
        //            throw new Exception("İlgili mail adresine kayıtlı kullanıcı bulunamadı");

        //        }
        //        return View(writer);
        //    }
        //}
    }
}

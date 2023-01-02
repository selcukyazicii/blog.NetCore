using coreProject2.Models;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace coreProject2.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Indexx()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Indexx(UserLoginVM userLoginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userLoginVM.Username, userLoginVM.Password, false, true);
                if (result.Succeeded)
                {
                 return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Indexx(Writer writer)
        //{
        //    using (Context context = new Context())
        //    {
        //        var data = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        //        if (data != null)
        //        {
        //            var claims = new List<Claim>
        //            {
        //                new Claim(ClaimTypes.Name,writer.WriterMail)
        //            };
        //            var userIdentity = new ClaimsIdentity(claims, "s");
        //            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
        //            await HttpContext.SignInAsync(claimsPrincipal);
        //            return RedirectToAction("Index", "Dashboard");
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //}


    }
}

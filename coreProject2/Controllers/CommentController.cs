using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.Controllers
{
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComent(Comment comment)
        {
            _commentManager.AddComment(comment);
            return RedirectToAction("Index", "Blog");
        }
        public PartialViewResult CommentListByBlogg(int id)
        {
            //ViewBag.i = id;
            var values = _commentManager.GetListComment(id);
            return PartialView(values);
        }
    }
}

using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace coreProject2.Controllers
{
    public class BlogController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        Context _context = new Context();
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = _blogManager.ListCategoryWithBlog(string.Empty);
            return View(values);
        }
        public IActionResult BlogReadMore(int id)
        {
            ViewBag.i = id;
            var values = _blogManager.GetBlogById(id);
            return View(values);
        }
        public IActionResult SearchBlog(string searchText)
        {
            var data = _blogManager.ListCategoryWithBlog(searchText);
            return View("Index", data);
        }
        public IActionResult BlogListByWriter()
        {
            var mail = User.Identity.Name;
            var loginId = _context.Writers.Where(x => x.WriterName == mail).Select(y => y.WriterId).FirstOrDefault();
            var value = _blogManager.BlogListele(loginId);
            return View(value);
        }
        [HttpGet]
        public IActionResult AddBlog()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            ViewBag.cm = categoryValue;
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            Context context = new Context();
            var mail2 = User.Identity.Name;
            var idLog = context.Writers.Where(x => x.WriterName == mail2).Select(y => y.WriterId).FirstOrDefault();
            BlogValidator validationRules = new BlogValidator();
            ValidationResult validationResult = validationRules.Validate(blog);
            if (validationResult.IsValid)
            {
                blog.BlogStatus = true;
                blog.WriterId = idLog;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _blogManager.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogs = _blogManager.GetById(id); 
            _blogManager.Delete(blogs);
            ViewBag.idd = id;
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var blogId = _blogManager.GetById(id);
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.catId = categoryValue;
            return View(blogId);
        }
        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            Context context = new Context();
            var mail2 = User.Identity.Name;
            var idLog = context.Writers.Where(x => x.WriterMail == mail2).Select(y => y.WriterId).FirstOrDefault();
            blog.BlogID = idLog;
            _blogManager.Update(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
    }
}

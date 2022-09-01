using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace coreProject2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var result = _categoryManager.GetList().ToPagedList(page,3);
            return View(result);
        }
    }
}

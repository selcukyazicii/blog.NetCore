﻿using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.ViewComponents.Category
{
    public class CategoryListDashboard:ViewComponent
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        EfCategoryRepository repository = new EfCategoryRepository();
        public IViewComponentResult Invoke()
        {
            //var data = _categoryManager.GetList();
            var data = repository.GetCategoryWithBlogCount();
            return View(data);
        }
    }
}

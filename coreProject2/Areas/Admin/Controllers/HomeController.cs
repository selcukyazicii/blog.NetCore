﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index2()
        {
            return View();
        }
    }
}

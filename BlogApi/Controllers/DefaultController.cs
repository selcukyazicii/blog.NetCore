using BlogApi.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployeeList()
        {
            using (Context context=new Context())
            {
                var values = context.Employees.ToList();
                return Ok(values);
            }
        }
    }
}

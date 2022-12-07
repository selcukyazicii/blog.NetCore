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
        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using (Context context= new Context())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployeeWithId(int id)
        {
            using (Context context=new Context())
            {
                var data = context.Employees.Find(id);
                if (data==null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }
                
            }
        }
    }
}

using Dotnetcorewebapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnetcorewebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmpDbContext context;
        public EmployeeController(EmpDbContext context)
        {
            this.context = context;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employees> Get()
        {
            return context.Emps.ToList();
        }
        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employees Get(int id)
        {
            return context.Emps.Find(id);
        }
        [HttpPost]
        public Employees Post([FromBody] Employees emp)
        {
            context.Emps.Add(emp);
            //Employees res = null;
            //if (context.SaveChanges() > 0)
            //    res = (from e in context.Emps
            //           where e.EID == context.Emps.Max(e => e.EID)
            //           select e).FirstOrDefault();
            context.SaveChanges();
            return emp;
        }
        [HttpPut("{id}")]
        public Employees Put(int id, [FromBody] Employees emp)
        {
            context.Emps.Update(emp);
            context.SaveChanges();
            return emp;
        }
        [HttpDelete("{id}")]
        public Employees Delete(int id)
        {
            Employees data = context.Emps.Find(id);
            context.Emps.Remove(data);
            context.SaveChanges();
            return data;
        }
        
    }
}

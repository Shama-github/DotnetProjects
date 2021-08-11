using Dotnetcorewebapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnetcorewebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAsyncController : ControllerBase
    {
        private readonly EmpDbContext context;
        public EmpAsyncController(EmpDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Employees>> Get()
        {
            return  await context.Emps.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
          var emp= await context.Emps.FindAsync(id);
            if (emp == null)
                return NotFound("EID not found");//404

            return Ok(emp);
        }
        [HttpPost]
        public async Task<Employees>  Post([FromBody] Employees emp)
        {
            await context.Emps.AddAsync(emp);
            await context.SaveChangesAsync();
            return emp;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Employees emp)
        {
            if (id != emp.EID)
                return BadRequest($"Id {id} is not equal to EID {emp.EID}");
             //context.Emps.Update(emp);
            var res=await context.Emps.FindAsync(id);
            if (res == null)
                return NotFound();
            res.EName = emp.EName;
            res.ESal = emp.ESal;
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Employees data = await context.Emps.FindAsync(id);
            if (data == null)
                return NotFound();
            context.Emps.Remove(data);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}

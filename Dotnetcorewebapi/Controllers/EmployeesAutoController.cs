using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dotnetcorewebapi.Models;

namespace Dotnetcorewebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesAutoController : ControllerBase
    {
        private readonly EmpDbContext _context;

        public EmployeesAutoController(EmpDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeesAuto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmps()
        {
            return await _context.Emps.ToListAsync();
        }

        // GET: api/EmployeesAuto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployees(int id)
        {
            var employees = await _context.Emps.FindAsync(id);

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }

        // PUT: api/EmployeesAuto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployees(int id, Employees employees)
        {
            if (id != employees.EID)
            {
                return BadRequest();
            }

            _context.Entry(employees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeesAuto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employees>> PostEmployees(Employees employees)
        {
            _context.Emps.Add(employees);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployees", new { id = employees.EID }, employees);
        }

        // DELETE: api/EmployeesAuto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            var employees = await _context.Emps.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            _context.Emps.Remove(employees);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeesExists(int id)
        {
            return _context.Emps.Any(e => e.EID == id);
        }
    }
}

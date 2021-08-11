using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotnetFramwrkmvc.Models;
using Microsoft.AspNetCore.Authorization;

namespace DotnetFramwrkmvc.Controllers
{
    [Authorize]
    public class EmpAutoController : Controller
    {
        private readonly EmpDbcontext _context;

        public EmpAutoController(EmpDbcontext context)
        {
            _context = context;
        }

        // GET: EmpAuto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emps.ToListAsync());
        }

        // GET: EmpAuto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.Emps
                .FirstOrDefaultAsync(m => m.EID == id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // GET: EmpAuto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpAuto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EID,Name,Sal")] Emp emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        // GET: EmpAuto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.Emps.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        // POST: EmpAuto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EID,Name,Sal")] Emp emp)
        {
            if (id != emp.EID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpExists(emp.EID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        // GET: EmpAuto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.Emps
                .FirstOrDefaultAsync(m => m.EID == id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // POST: EmpAuto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emp = await _context.Emps.FindAsync(id);
            _context.Emps.Remove(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpExists(int id)
        {
            return _context.Emps.Any(e => e.EID == id);
        }
    }
}

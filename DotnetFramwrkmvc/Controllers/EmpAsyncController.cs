using DotnetFramwrkmvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetFramwrkmvc.Controllers
{
    [Authorize]
    public class EmpAsyncController : Controller
    {
        private readonly EmpDbcontext context;

        public EmpAsyncController(EmpDbcontext context)
        {
            this.context = context;

        }
        public async Task<IActionResult> Index()
        {
            var data= await context.Emps.ToListAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
         
                return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Emp employee)
        {
            if (ModelState.IsValid)
            {
                context.Emps.Add(employee);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var data = await context.Emps.FindAsync(id);
            if (data == null)
                return NotFound();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();//400
            var data =await context.Emps.FindAsync(id);
            if (data == null)
                return NotFound();//404
            return View(data);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int? id ,Emp emp)
        {
            if (id == null & id!=emp.EID )
                return BadRequest();//400
            if (ModelState.IsValid)
            {

                context.Update(emp);
               await context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var data = await context.Emps.FindAsync(id);
            if (data == null)
                return NotFound();
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int? id,Emp emp )
        {
            if (id == null & id != emp.EID)
                return BadRequest();//400
            var data = await context.Emps.FindAsync(id);
            context.Remove(data);
           await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

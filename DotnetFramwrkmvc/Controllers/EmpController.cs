using DotnetFramwrkmvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetFramwrkmvc.Controllers
{
    
    public class EmpController : Controller
    {
        private readonly EmpDbcontext context;

        public EmpController(EmpDbcontext context)
        {
            this.context = context;

        }
        public IActionResult Index()
        {
            //throw new Exception("My Exception");
            return View(context.Emps.ToList());

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Emp employee)
        {
            if (ModelState.IsValid)
            {
                context.Emps.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var data = context.Emps.Find(id);
            if (data == null)
                return NotFound();
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();//400
            var data = context.Emps.Find(id);
            if (data == null)
                return NotFound();//404
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit( int? id,Emp emp)
        {
            if (id == null & id != emp.EID)
                return BadRequest();//400
            if (ModelState.IsValid)
            {

                context.Update(emp);
                context.SaveChanges();
            }
        
             return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var data = context.Emps.Find(id);
            if (data == null)
                return NotFound();
            return View(data);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmation(int? id, Emp emp)
        {
            if (id == null & id != emp.EID)
                return BadRequest();//400
            var data = context.Emps.Find(id);
            context.Remove(data);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using StudentCOREMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCOREMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext StudentEntities;
        public StudentController(StudentDbContext context)//DI
        {
            StudentEntities = context;
        }

        public IActionResult Index()
        {
            return View(StudentEntities.Students.ToList());

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Student stud)
        {
            if (ModelState.IsValid)
            {
                StudentEntities.Students.Add(stud);
                StudentEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stud);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var data = StudentEntities.Students.Find(id);
            if (data == null)
                return NotFound();
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();//400
            var data = StudentEntities.Students.Find(id);
            if (data == null)
                return NotFound();//404
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(int? id,Student Student)
        {
            if (id == null & id != Student.SID)
                return BadRequest();//400
            if (ModelState.IsValid)
            {

                StudentEntities.Update(Student);
                StudentEntities.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var data = StudentEntities.Students.Find(id);
            if (data == null)
                return NotFound();
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public  IActionResult DeleteConfirmation(int? id, Student stud)
        {
            if (id == null & id != stud.SID)
                return BadRequest();//400
            var data = StudentEntities.Students.Find(id);
            StudentEntities.Remove(data);
            StudentEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
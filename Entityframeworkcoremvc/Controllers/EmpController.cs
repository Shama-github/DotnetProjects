using Entityframeworkcoremvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entityframeworkcoremvc.Controllers
{
    public class EmpController : Controller
    {
        EmpDbContext empEntities;
        public EmpController(EmpDbContext context)//DI
        {
            empEntities = context;
        }
        public IActionResult Index()
        {
            return View(empEntities.Emps.ToList());
        }
        public IActionResult Details(int id)
        {
            return View(empEntities.Emps.Find(id));
        }
    }
}

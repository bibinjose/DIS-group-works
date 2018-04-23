using EmpApp.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EmpApp.Controllers
{
    public class AccessoryController: Controller
    {
        private readonly AppDbContext context;

        public AccessoryController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
           var accessories = (from e in context.Employees
                          join l in context.Accessories
                          on e.Id equals l.Employee.Id
                          select new
                          {
                              e.Name,
                              l.AccessoryName,
                              l.AccessoryId
                          }).ToList();
            List<AccessoryViewModel> AccessoryViewModel = new List<AccessoryViewModel>();
            foreach (var l in accessories)
            {
                AccessoryViewModel accessory = new AccessoryViewModel();
                accessory.EmployeeName = l.Name;
                accessory.AccessoryName = l.AccessoryName;
             
                accessory.AccessoryId = l.AccessoryId;
                AccessoryViewModel.Add(accessory);

            }
            return View(AccessoryViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<String> employee = context.Employees.Select(e => e.Name).ToList();
            ViewData["Employee"] = employee;
            return View();
        }

        [HttpPost]
        public IActionResult Create(AccessoryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            //context.Add(model);
            //context.SaveChanges();
            var emp = context.Employees.Include("Accessories")
                       .Where(e => e.Name.Equals(model.EmployeeName))
                        .FirstOrDefault();
            Debug.WriteLine("emppp" + emp.Age);
            Accessory accessory = new Accessory() {
                AccessoryName = model.AccessoryName};
            emp.Accessories.Add(accessory);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = context.Accessories.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Accessory model)
        {
            if (!ModelState.IsValid) return View(model);
            Debug.WriteLine("awardId:" + model.AccessoryId);
            context.Accessories.Update(model);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var accessory = context.Accessories.Find(id);
            context.Accessories.Remove(accessory);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

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
    public class AwardController:Controller
    {
        private readonly AppDbContext context;

        public AwardController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
           var leaves = (from e in context.Employees
                          join l in context.Awards
                          on e.Id equals l.Employee.Id
                          select new
                          {
                              e.Name,
                              l.AwardName,
                              l.PrizeAmount,
                              l.AwardId
                          }).ToList();
            List<AwardViewModel> AwardViewModel = new List<AwardViewModel>();
            foreach (var l in leaves){
                AwardViewModel award = new AwardViewModel();
                award.EmployeeName = l.Name;
                award.AwardName = l.AwardName;
                award.PrizeAmount = l.PrizeAmount;
                award.AwardId = l.AwardId;
                AwardViewModel.Add(award);

            }
            return View(AwardViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<String> employee = context.Employees.Select(e => e.Name).ToList();
            ViewData["Employee"] = employee;
            return View();
        }

        [HttpPost]
        public IActionResult Create(AwardViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            //context.Add(model);
            //context.SaveChanges();
            var emp = context.Employees.Include("Awards")
                       .Where(e => e.Name.Equals(model.EmployeeName))
                        .FirstOrDefault();
            Debug.WriteLine("emppp" + emp.Age);
            Award award = new Award() {
                AwardName = model.AwardName, PrizeAmount = model.PrizeAmount };
            emp.Awards.Add(award);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = context.Awards.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Award model)
        {
            if (!ModelState.IsValid) return View(model);
            Debug.WriteLine("awardId:" + model.AwardId);
            context.Awards.Update(model);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var leave = context.Awards.Find(id);
            context.Awards.Remove(leave);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

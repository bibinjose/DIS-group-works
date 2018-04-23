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
    public class ScheduleController : Controller
    {
        private readonly AppDbContext context;

        public ScheduleController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
           var schedules = (from e in context.Employees
                          join l in context.Schedules
                          on e.Id equals l.Employee.Id
                          select new
                          {
                              e.Name,
                              l.ScheduleDate,
                              l.StartTime,
                              l.EndTime,
                              l.WorkLocation,
                              l.ScheduleId
                          }).ToList();
            List<ScheduleViewModel> ScheduleViewModel = new List<ScheduleViewModel>();
            foreach (var l in schedules)
            {
                ScheduleViewModel schedule = new ScheduleViewModel();
                schedule.EmployeeName = l.Name;
                schedule.ScheduleDate = l.ScheduleDate;
                schedule.StartTime = l.StartTime;
                schedule.EndTime = l.EndTime;
                schedule.WorkLocation = l.WorkLocation;
                schedule.ScheduleId = l.ScheduleId;
                ScheduleViewModel.Add(schedule);

            }
            return View(ScheduleViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<String> employee = context.Employees.Select(e => e.Name).ToList();
            ViewData["Employee"] = employee;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ScheduleViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            //context.Add(model);
            //context.SaveChanges();
            var emp = context.Employees.Include("Schedules")
                       .Where(e => e.Name.Equals(model.EmployeeName))
                        .FirstOrDefault();
            Debug.WriteLine("emppp" + emp.Age);
            Schedule schedule = new Schedule() {
                ScheduleDate=model.ScheduleDate, StartTime= model.StartTime, EndTime = model.EndTime, WorkLocation = model.WorkLocation };
            emp.Schedules.Add(schedule);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = context.Schedules.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Schedule model)
        {
            if (!ModelState.IsValid) return View(model);
            Debug.WriteLine("ScheduleId:" + model.ScheduleId);
            context.Schedules.Update(model);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var schedule = context.Schedules.Find(id);
            context.Schedules.Remove(schedule);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

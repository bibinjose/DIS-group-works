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
    public class PaymentController:Controller
    {
        private readonly AppDbContext context;

        public PaymentController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
           var leaves = (from e in context.Employees
                          join l in context.Payments
                          on e.Id equals l.Employee.Id
                          select new
                          {
                              e.Name,
                              l.PaymentDate,
                              l.HourlyWage,
                              l.HoursWorked,
                              l.Salary,
                              l.PaymentType,
                              l.PaymentId
                          }).ToList();
            List<PaymentViewModel> PaymentViewModel = new List<PaymentViewModel>();
            foreach (var l in leaves){
                PaymentViewModel payment = new PaymentViewModel();
                payment.EmployeeName = l.Name;
                payment.PaymentDate = l.PaymentDate;
                payment.HourlyWage = l.HourlyWage;
                payment.HoursWorked = l.HoursWorked;
                payment.Salary = l.Salary;
                payment.PaymentType = l.PaymentType;
                payment.PaymentId = l.PaymentId;
                PaymentViewModel.Add(payment);

            }
            return View(PaymentViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<String> employee = context.Employees.Select(e => e.Name).ToList();
            ViewData["Employee"] = employee;
            return View();
        }

        [HttpPost]
        public IActionResult Create(PaymentViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            //context.Add(model);
            //context.SaveChanges();
            var emp = context.Employees.Include("Payments")
                       .Where(e => e.Name.Equals(model.EmployeeName))
                        .FirstOrDefault();
            Debug.WriteLine("emppp" + emp.Age);
            Payment payment = new Payment() {
                PaymentDate = model.PaymentDate, HourlyWage = model.HourlyWage, HoursWorked = model.HoursWorked,
            Salary=model.Salary,PaymentType=model.PaymentType};
            emp.Payments.Add(payment);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = context.Payments.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Payment model)
        {
            if (!ModelState.IsValid) return View(model);
            Debug.WriteLine("Payment Id:" + model.PaymentId);
            context.Payments.Update(model);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var payment = context.Payments.Find(id);
            context.Payments.Remove(payment);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
      
      
        public IActionResult Index()
        {
            return View(TestData.Employees);
        }
        public IActionResult EmployeeCard(int Id)
        {
            var employee = TestData.Employees.Where(x => x.Id == Id).FirstOrDefault();  
            if(employee is not null)           
                return View(employee);
            return NotFound();
          
         
        }
        public IActionResult View(int Id)
        {
            var employee = TestData.Employees.Where(x => x.Id == Id).FirstOrDefault();
            if (employee is not null)
                return View(employee);
            return NotFound();
        }

        public IActionResult Edit(int Id)
        {
            var employee = TestData.Employees.Where(x => x.Id == Id).FirstOrDefault();
            if (employee is null)
            {
                var emp = new Employee();
                return View(emp);
            }
            else
            {
                return View(employee);
            }
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                TestData.SaveEmployee(employee);            
                return RedirectToAction("Index");
            }
            else
            {     
                return View(employee);
            }
        }

  

        public IActionResult Delete(int Id)
        {
            var employee = TestData.Employees.Where(x => x.Id == Id).FirstOrDefault();
            if (employee is not null)
            {
                TestData.Employees.Remove(employee);
                return RedirectToAction("Index");
            }
             
            return NotFound();
           
        }
    }
}

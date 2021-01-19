using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Employee> _Employees = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 22 ,DateBirth = new DateTime(1998, 7, 20), DateEmplayed = new DateTime(2020,1 , 1) },
            new Employee { Id = 2, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", Age = 32, DateBirth = new DateTime(1988, 6, 21), DateEmplayed = new DateTime(2019, 1, 1) },
            new Employee { Id = 3, LastName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", Age = 42,  DateBirth = new DateTime(1978, 5, 22), DateEmplayed = new DateTime(2021, 1, 1) },
        };

        public IActionResult Index() => View();

        public IActionResult SecondAction()
        {
            return Content("Second controller action");
        }

        public IActionResult Employees()
        {
            return View(_Employees);
        }
        public IActionResult EmployeeCard(int Id)
        {
            return View(_Employees.Where(x => x.Id==Id).FirstOrDefault());
        }
    }
}
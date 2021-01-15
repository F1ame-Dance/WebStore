using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Employee> _Employees = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 22 },
            new Employee { Id = 2, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", Age = 33 },
            new Employee { Id = 3, LastName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", Age = 44 },
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
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    //[Route("staff")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;
        public EmployeesController(IEmployeesData  employeesData)
        {
            _EmployeesData = employeesData;
        }

        // [Route("all")]
        public IActionResult Index()
        {
            return View(_EmployeesData.Get());
        }
        // [Route("info(id-{id})")]
        public IActionResult EmployeeCard(int id)
        {
            var employee = _EmployeesData.Get(id);
            if (employee is not null)
                return View(employee);
            return NotFound();
        }

        public IActionResult Edit(int id)
        {
            if (id <= 0) return BadRequest();

            var employee = _EmployeesData.Get(id);
            if (employee is null)
                return NotFound();
            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Age = employee.Age,
                DateBirth = employee.DateBirth,
                DateEmplayed = employee.DateEmplayed,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                MiddleName = employee.Patronymic

            });
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            var employee = new Employee
            {
                Id = model.Id,
                Age = model.Age,
                DateBirth = model.DateBirth,
                DateEmplayed = model.DateEmplayed,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Patronymic = model.MiddleName
            };

            if (employee.Id == 0)
                _EmployeesData.Add(employee);
            else
                _EmployeesData.Update(employee);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var employee = _EmployeesData.Get(id);
            if (employee is null)
                return NotFound();
            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Age = employee.Age,
                DateBirth = employee.DateBirth,
                DateEmplayed = employee.DateEmplayed,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                MiddleName = employee.Patronymic

            });
        }
        [HttpPost] 
        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeesData.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Create() => View("Edit", new EmployeeViewModel());

    }
}

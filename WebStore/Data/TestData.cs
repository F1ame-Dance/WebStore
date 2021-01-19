using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Models;

namespace WebStore.Data
{
    public static class TestData
    {
        public static List<Employee> Employees = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 22, DateBirth = new DateTime(1998, 7, 20), DateEmplayed = new DateTime(2020, 1, 1) },
            new Employee { Id = 2, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", Age = 32, DateBirth = new DateTime(1988, 6, 21), DateEmplayed = new DateTime(2019, 1, 1) },
            new Employee { Id = 3, LastName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", Age = 42, DateBirth = new DateTime(1978, 5, 22), DateEmplayed = new DateTime(2021, 1, 1) },
        };




        public static void SaveEmployee(Employee employee)
        {
            Employee chgEnity = Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (chgEnity is null)
                Employees.Add(employee);
            else
            {


                chgEnity.LastName = employee.LastName;
                chgEnity.FirstName = employee.FirstName;
                chgEnity.Patronymic = employee.Patronymic;
                chgEnity.Age = employee.Age;
                chgEnity.DateBirth = employee.DateBirth;
                chgEnity.DateEmplayed = employee.DateEmplayed;

            }

        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly List<Employee> _Employees;
        private int _CurrentMaxId;
        public InMemoryEmployeesData()
        {
            _Employees = TestData.Employees;
            _CurrentMaxId = _Employees.Max(x => x?.Id ?? 1);
        }
        public int Add(Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));
            if (_Employees.Contains(employee)) return employee.Id;
            employee.Id = ++_CurrentMaxId;
            _Employees.Add(employee);
            return employee.Id;
        }

        public bool Delete(int id)
        {
            var db_item = Get(id);
            if (db_item is null) return false;
            return _Employees.Remove(db_item);

        }

        public IEnumerable<Employee> Get() => _Employees;

        public Employee Get(int id) => _Employees.FirstOrDefault(employee => employee.Id == id);

        public void Update(Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));
            if (_Employees.Contains(employee)) return;
            var db_item = Get(employee.Id);
            if (db_item is null) return;

            db_item.Age = employee.Age;
            db_item.DateBirth = employee.DateBirth;
            db_item.DateEmplayed = employee.DateEmplayed;
            db_item.LastName = employee.LastName;
            db_item.FirstName = employee.FirstName;
            db_item.Patronymic = employee.Patronymic;


        }
    }
}

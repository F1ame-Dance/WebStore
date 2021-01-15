using System;

namespace WebStore.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public int Age { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime DateEmplayed { get; set; }
    }
}
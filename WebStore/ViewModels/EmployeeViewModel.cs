using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class EmployeeViewModel 
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; init; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия обязательна")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина от 2 до 15 символов")]
        [RegularExpression(@"[А-ЯЁ][а-яё]+|([a-z][a-z]+)", ErrorMessage = "Неверный формат фамилии")]
        public string FirstName { get; init; }
        [Display(Name = "Имя")]
        public string LastName { get; init; }
        [Display(Name = "Отчество")]
        public string MiddleName { get; init; }
        [Display(Name = "Возраст")]
        [Range(18, 80, ErrorMessage = "Возраст от 18 до 80")]
        public int Age { get; init; }
        [Display(Name = "Дата рождения")]
        public DateTime DateBirth { get; init; }
        [Display(Name = "Дата нвйма")]
        public DateTime DateEmplayed { get; init; }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            yield return ValidationResult.Success;
        }

    }
}

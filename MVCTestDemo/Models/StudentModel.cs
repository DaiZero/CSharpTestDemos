using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
//using System.Web.ModelBinding;
using System.Web.Mvc;

namespace DZero.Mvc.TestDemo.Models
{

    public class FirstNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) // Checking for Empty Value
            {
                return new ValidationResult("Please Provide First Name");
            }
            else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("First Name should contain @");
                }
            }
            return ValidationResult.Success;
        }
    }

    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }

        [FirstNameValidation]
        public string FirstName { get; set; }

        [StringLength(5, ErrorMessage = "Last Name length should not be greater than 5")]
        public string LastName { get; set; }

        public int Age { get; set; }
    }

}
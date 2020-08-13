using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo1.Models
{
    public class Student : IValidatableObject
    {
        public Student()
        {
        }

        public Student(int id, string name, DateTime dateOfBirth, Gender gender)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }
        [Display(Name = "Student ID")]
        public int Id { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Display(Name = "Student Date of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please select Date of birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Student Gender")]
        [Range(1, 3, ErrorMessage = "Please select gender")]
        public Gender Gender { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth > DateTime.Now)
                yield return new ValidationResult("Date of birth cannot be in future", 
                    new[] { nameof(DateOfBirth) }); 
        }
    }
}
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.DAL.Entities;

namespace WebApplication1.Models
{
    public class EmployeeVM
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        [MinLength(3, ErrorMessage = "Min Length is 3")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Please Enter Salary")]
        //[Range(3000,1000, ErrorMessage = "Enter salary from 3K to 10K")]
        public float Salary { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}", ErrorMessage = "Enter like 12-StreetName-CityName-CountryName")]
        public string Address { get; set; }
        public DateTime HireDate { get; set; }

        [EmailAddress(ErrorMessage = "Enter email address")]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public string departmentId { get; set; } //string to store department.name in the EmployeeRep getEmployeeById()
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }

        public string PhotoName { get; set; }
        public IFormFile PhotoUrl { get; set; }


        public string CvName { get; set; }
        public IFormFile CvUrl { get; set; }



    }
}

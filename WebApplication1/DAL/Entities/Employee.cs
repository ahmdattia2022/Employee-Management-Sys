using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.DAL.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        public string EmployeeName { get; set; }

        public  float Salary { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }

        public string PhotoName { get; set; }
        public string CvName { get; set; }


        //Foreign Keys
        public int departmentId { get; set; }
        public int DistrictId { get; set; }
        //*

        //**
        [ForeignKey("departmentId")]
        public Department Department { get; set; }

        [ForeignKey("DistrictId")]
        public District District { get; set; }



    }
}

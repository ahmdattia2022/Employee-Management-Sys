using AutoMapper;
using System.ComponentModel.DataAnnotations;
using WebApplication1.DAL.Entities;

namespace WebApplication1.Models
{
    public class DepartmentVM
    {
        //this is department view model
        
        public int id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [MaxLength(25, ErrorMessage = "Max length is 25")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please Enter Code")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        [MaxLength(10, ErrorMessage = "Max length is 10")]
        public string Code { get; set; }
        public void Mapping(Profile profile)
        {
            var c = profile.CreateMap<Department, DepartmentVM>()
                .ForMember(d => d.id, opt => opt.MapFrom(s => s.id));
        }

    }
}

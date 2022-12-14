using AutoMapper;
using System;
using System.Linq;
using System.Reflection;
using WebApplication1.DAL.Entities;
using WebApplication1.Models;

namespace WebApplication1.BL.AutoMapper
{
    public class DomainProfile : Profile
    {

        public DomainProfile()
        {
            //department mapping
            //CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>()
                .ForMember(e => e.id, d => d.MapFrom(a => a.id))
                .ReverseMap();

            CreateMap<EmployeeVM, Employee>()//review
                .ForMember(e => e.id, d => d.MapFrom(a => a.id))
                .ForMember(e => e.departmentId, d => d.MapFrom(a => a.departmentId))
                .ReverseMap();
        }
        //private void AApplyMappingsFromAssembly(Assembly assembly)
        //{
        //    var types = assembly.GetExportedTypes()
        //    .Where(t => t.GetInterfaces().Any(i =>
        //        i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
        //    .ToList();
        //    foreach (var type in types)
        //    {
        //        var instance = Activator.CreateInstance(type);

        //        var methodInfo = type.GetMethod("Mapping") ??
        //                         type.GetInterface("IMapFrom`1").GetMethod("Mapping");

        //        methodInfo?.Invoke(instance, new object[] { this });
        //    }
        //}
    }
}
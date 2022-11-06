using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using WebApplication1.BL.Helper;
using WebApplication1.BL.Interface;
using WebApplication1.DAL.Database;
using WebApplication1.DAL.Entities;
using WebApplication1.Models;

namespace WebApplication1.BL.Reposatory
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;
        private int id;
        public EmployeeRep(DbContainer db, IMapper _mapper)
        {
            this.db = db;
            mapper = _mapper;
            id = 0;
        }

        public void Add(EmployeeVM emp)
         {
            var data = mapper.Map<Employee>(emp);
            data.PhotoName = UploadFileHelper.SaveFile(emp.PhotoUrl, "Photos");
            data.CvName = UploadFileHelper.SaveFile(emp.CvUrl, "Docs");
            
            db.Employee.Add(data);
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            var oldEmp = db.Employee.Find(ID);
            UploadFileHelper.RemoveFile("Photos/", oldEmp.PhotoName);//remove from server
            UploadFileHelper.RemoveFile("Docs/", oldEmp.CvName);//remove from server
            db.Employee.Remove(oldEmp);
            db.SaveChanges();
        }

        public IQueryable<EmployeeVM> Get()
        {
            IQueryable<EmployeeVM> data = GetAllEmps();
            return data;
        }
        private IQueryable<EmployeeVM> GetAllEmps()
        {
            return db.Employee
                       .Select(a => new EmployeeVM
                       {
                           id = a.id,
                           EmployeeName = a.EmployeeName,
                           Address = a.Address,
                           Email = a.Email,
                           HireDate = a.HireDate,
                           IsActive = a.IsActive,
                           Notes = a.Notes,
                           Salary = a.Salary,
                           departmentId = a.Department.Name,
                           DistrictId = a.DistrictId,
                           DistrictName = a.District.Name,
                           PhotoName = a.PhotoName,
                           CvName = a.CvName
                       });
        }
        public EmployeeVM GetByID(int ID)
        {
            EmployeeVM data = GetEmployeeByID(ID);
            return data;
        }
        private EmployeeVM GetEmployeeByID(int id)
        {
            this.id = id;
            return db.Employee.Where(a => a.id == id)
                                    .Select(a => new EmployeeVM
                                    {
                                        id = a.id,
                                        EmployeeName = a.EmployeeName,
                                        Address = a.Address,
                                        Email = a.Email,
                                        HireDate = a.HireDate,
                                        IsActive = a.IsActive,
                                        Notes = a.Notes,
                                        Salary = a.Salary,
                                        departmentId = a.Department.Name,
                                        DistrictId = a.DistrictId,
                                        DistrictName = a.District.Name,
                                        PhotoName = a.PhotoName,
                                        CvName = a.CvName
                                    }).FirstOrDefault();
        }

        public void Update(EmployeeVM emp)
        {
            var data = mapper.Map<Employee>(emp);
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges(); 
            }

        }
    }


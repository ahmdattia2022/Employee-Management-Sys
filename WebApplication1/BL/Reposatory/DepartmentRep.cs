using AutoMapper;
using System.Linq;
using WebApplication1.BL.Interface;
using WebApplication1.DAL.Database;
using WebApplication1.DAL.Entities;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.BL.Reposatory
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;
        public DepartmentRep(DbContainer db, IMapper _mapper)
        {
            this.db = db;
            mapper = _mapper;
        }

        public void Add(DepartmentVM dept)
        {
            //Department d = new Department();
            //old mapping between department db model and departmentVM
            //d.DeptId = dept.Id;
            //d.Name = dept.DepartmentName;
            //d.Code = dept.DepartmentCode;

            //mapping
            var data = mapper.Map<Department>(dept);

            db.Department.Add(data);
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            var oldDept = db.Department.Find(ID);
            db.Department.Remove(oldDept);
            db.SaveChanges();
        }

        public IQueryable<DepartmentVM> Get()
        {
            IQueryable<DepartmentVM> data = GetAllDepts();
            return data;
        }

       
        public DepartmentVM GetByID(int ID)
        {
            DepartmentVM d = GetDepartmentByID(ID);
            return d;
        }


        public void Update(DepartmentVM dept)
        {
            //var oldDept = db.Department.Find(dept.DeptId);

            //old data mapping
            //oldDept.Name = dept.DepartmentName;
            //oldDept.Code = dept.DepartmentCode;


            var department = mapper.Map<Department>(dept);
            
            db.Entry(department).State = EntityState.Modified;

            var saved = false;
            while (!saved)
            {
                try
                {
                    // Attempt to save changes to the database
                    db.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is Department)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues[property];

                                // TODO: decide which value should be written to database
                                // proposedValues[property] = <value to be saved>;
                            }

                            // Refresh original values to bypass next concurrency check
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            throw new NotSupportedException(
                                "Don't know how to handle concurrency conflicts for "
                                + entry.Metadata.Name);
                        }
                    }
                }
            }
        }


        //Refactor
        private DepartmentVM GetDepartmentByID(int id)
        {
            return db.Department.Where(a => a.id == id)
                                    .Select(a => new DepartmentVM { id = a.id, Name = a.Name, Code = a.Code })
                                    .FirstOrDefault();
        }

        private IQueryable<DepartmentVM> GetAllDepts()
        {
            return db.Department
                       .Select(a => new DepartmentVM { id = a.id, Name = a.Name, Code = a.Code });
        }


    }
}

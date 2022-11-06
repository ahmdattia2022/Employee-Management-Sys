using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.BL.Reposatory;
using WebApplication1.DAL.Database;
using WebApplication1.Models;

using System.Diagnostics; //to log exceptions
using WebApplication1.BL.Interface;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        //loosly coupled
        private readonly DbContainer db;
        private readonly IDepartmentRep department;
        

        public DepartmentController(IDepartmentRep department, DbContainer db)
        {
            this.department = department;
            this.db = db;
        }
        public IActionResult Index()
        {
            var data = department.Get();
            return View(data);
           
        }
        
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        public IActionResult Create(DepartmentVM _department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Add(_department);
                    return RedirectToAction("Index", "Department");
                }

                return View(_department);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(_department);
            }

           

        }

        public IActionResult Update(int id)
        {
            var data = department.GetByID(id);
            data.id = id;
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(DepartmentVM _department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Update(_department);
                    return RedirectToAction("Index", "Department");
                }

                return View(_department);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(_department);
            }
        }
        public IActionResult Delete(int id)
        {
            var dept = department.GetByID(id);
            if (dept == null)
            {

            }
            return View(dept);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                department.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }
        }
    }
}

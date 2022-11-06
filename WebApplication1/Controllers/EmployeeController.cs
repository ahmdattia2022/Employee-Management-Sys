using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebApplication1.BL.Interface;
using WebApplication1.DAL.Database;
using WebApplication1.Models;
using System.Net.Http.Headers;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRep _employee;
        private readonly IDepartmentRep _department;
        private readonly ICountryRep _country;
        private readonly ICityRep _city;
        private readonly IDistrictRep _district;
        private readonly DbContainer db;

        public EmployeeController(IEmployeeRep employee, IDepartmentRep department, ICountryRep country,ICityRep city,IDistrictRep district, DbContainer db)
        {
            this._employee = employee;
            this._department = department;
            this._country = country;
            this._city = city;
            this._district = district;
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = _employee.Get();
            return View(data);
        }

        public IActionResult Create()
        {
            var data = _department.Get();
            ViewBag.departmentList = new SelectList(data, "id", "Name");
            var countries = _country.Get();
            ViewBag.countryList = new SelectList(countries, "id", "Name");
            return View();
        //XmlWriterTraceListener
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employee.Add(emp);
                    return RedirectToAction("Index", "Employee");
                }
                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }
        }

        public IActionResult Update(int id)
        {
            var data = _employee.GetByID(id);
            var deptData = _department.Get();
            ViewBag.departmentList = new SelectList(deptData, "id", "Name", data.departmentId);

            return View(data);
        }
        [HttpPost]
        public IActionResult Update(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employee.Update(emp);
                    return RedirectToAction("Index", "Employee");
                }
                var deptData = _department.Get();
                ViewBag.departmentList = new SelectList(deptData, "id", "Name", emp.departmentId);
                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }
        }

        public IActionResult Delete(int id)
        {
            var emp = _employee.GetByID(id);
            //if (emp == null)
            //{
            //}
            var deptData = _department.Get();
            ViewBag.departmentList = new SelectList(deptData, "id", "Name", emp.departmentId);
            return View(emp);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                _employee.Delete(id);

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

        //-----------------------------Ajax call-------------------------------------------
        [HttpPost]
        public JsonResult GetCityDataByCountyId(int countryId)
        {
            var data = _city.Get().Where(c => c.CountryId == countryId).ToList();
            return Json(data);
        }
        [HttpPost]
        public JsonResult GetDistrictDataByCountyId(int cityId)
        {
            var data = _district.Get().Where(d => d.CityId == cityId);
            return Json(data);
        }

    }
}

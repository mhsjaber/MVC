using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private GarmentsManagementEntities db = new GarmentsManagementEntities();

        public ActionResult Index()
        {
            ViewData["Designations"] = db.EmpDesignations
                .Where(d => d.Status == 1)
                .Select(d=> new DesignationsViewModel{
                    Id = d.Id,
                    Name = d.Name
                })
                .ToList();

            var empDetails = db.EmpDetails
                .Include(e => e.EmpDesignation)
                .Where(e => e.Status == 1)
                .Select(e => new EmployeesViewModel
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Mobile = e.Mobile,
                    Email = e.Email,
                    Address = e.Address,
                    Image = e.Image,
                    EmployeeType = e.EmployeeType,
                    Designation = e.EmpDesignation.Name
                });
            return View(empDetails.ToList());
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Address,Email,LastName,FirstName,Mobile,UpdateDate,UpdatedBy,Status,EmployeeType,CreatedBy,CreateDate,DesignationId")] EmpDetail empDetail)
        {
            try
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 - .]");
                empDetail.FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rgx.Replace(empDetail.FirstName, "").ToLower()).Trim();
                empDetail.LastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rgx.Replace(empDetail.LastName, "").ToLower()).Trim();
                empDetail.Email = empDetail.Email.ToLower().Trim();
                empDetail.UpdateDate = DateTime.Now;
                empDetail.CreatedBy = 234;
                empDetail.CreateDate = DateTime.Now;
                empDetail.UpdatedBy = 234;
                empDetail.Status = 1;

                if (ModelState.IsValid)
                {
                    db.EmpDetails.Add(empDetail);
                    db.SaveChanges();
                    return Json(1);
                }
                else
                {
                    return Json(2);
                }
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

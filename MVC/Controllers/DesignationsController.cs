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

namespace MVC.Controllers
{
    public class DesignationsController : Controller
    {
        private GarmentsManagementEntities db = new GarmentsManagementEntities();
        
        public ActionResult Index()
        {
            var empDesignations = db
                .EmpDesignations
                .Include(e => e.SystemUser)
                .Select(s => new DesignationsViewModel
                {
                    Name = s.Name,
                    CreatedBy = s.SystemUser.Email,
                    UpdateDate = s.UpdateDate,
                    Id = s.Id,
                    Status = s.Status
                });
            return View(empDesignations.ToList());
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,CreatedBy,CreateDate,UpdateDate,UpdatedBy,Status")] EmpDesignation empDesignation)
        {
            try
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 - .]");
                empDesignation.Name = rgx.Replace(empDesignation.Name, "").Trim();
                empDesignation.UpdateDate = DateTime.Now;
                empDesignation.CreateDate = DateTime.Now;
                empDesignation.CreatedBy = 234;
                empDesignation.UpdatedBy = 234;
                empDesignation.Status = 1;

                if (ModelState.IsValid)
                {
                    db.EmpDesignations.Add(empDesignation);
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

        [HttpPost]
        public ActionResult EditValue(int? id)
        {
            if (id == null)
            {
                return Json(0);
            }
            var systemUser = db.EmpDesignations
                    .Include(s => s.SystemUser)
                    .Where(s => s.Id == id)
                    .Select(s => new DesignationsViewModel
                    {
                        Name = s.Name,
                        Status = s.Status
                    }).Single();
            return Json(systemUser);
        }


        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,UpdateDate,UpdatedBy,Status")] EmpDesignation empDesignation)
        {
            try
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 - .]");
                empDesignation.Name = rgx.Replace(empDesignation.Name, "").Trim();
                empDesignation.UpdateDate = DateTime.Now;
                empDesignation.UpdatedBy = 234;

                var des = db.EmpDesignations
                    .Include(s => s.SystemUser)
                    .Where(s => s.Id == empDesignation.Id)
                    .Select(s => new FabricDetailsViewModel
                    {
                        CreateDate = s.CreateDate,
                        CreatedBy = s.CreatedBy
                    })
                    .Single();

                empDesignation.CreateDate = des.CreateDate;
                empDesignation.CreatedBy = des.CreatedBy;

                if (ModelState.IsValid)
                {
                    db.Entry(empDesignation).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(1);
                }
                return Json(2);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
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

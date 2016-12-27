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
    public class FabricDetailsController : Controller
    {
        private GarmentsManagementEntities1 db = new GarmentsManagementEntities1();
        
        public ActionResult Index()
        {
            var fabricDetails = db.FabricDetails
                .Include(f => f.SystemUser)
                .Select(s => new FabricDetailsViewModel
                {
                    FabricCode = s.FabricCode,
                    FabricName = s.FabricName,
                    Description = s.Description,
                    UpdatedBy = s.UpdatedBy,
                    Id = s.Id,
                    Status = s.Status,
                    UpdateDate = s.UpdateDate
                });
            return View(fabricDetails.ToList());
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "FabricName,FabricCode,Description,CreateDate,UpdateDate,UpdatedBy,Status")] FabricDetail fabricDetail)
        {
            try
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 - .]");
                fabricDetail.FabricName = rgx.Replace(fabricDetail.FabricName, "").Trim();
                fabricDetail.FabricCode = fabricDetail.FabricCode.Trim();
                fabricDetail.UpdateDate = DateTime.Now;
                fabricDetail.CreateDate = DateTime.Now;
                fabricDetail.CreatedBy = 234;
                fabricDetail.Status = 1;

                if (ModelState.IsValid)
                {
                    db.FabricDetails.Add(fabricDetail);
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
            var fabricDetail = db.FabricDetails
                    .Include(s => s.SystemUser)
                    .Where(s => s.Id == id)
                    .Select(s => new FabricDetailsViewModel
                    {
                        FabricCode = s.FabricCode,
                        FabricName = s.FabricName,
                        Description = s.Description,
                        Status = s.Status
                    }).OrderBy(s => new { s.Status, s.FabricName }).Single();
            return Json(fabricDetail);
        }


        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,FabricName,FabricCode,Description,UpdateDate,UpdatedBy,Status")] FabricDetail fabricDetail)
        {
            try
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 - .]");
                fabricDetail.FabricName = rgx.Replace(fabricDetail.FabricName, "").Trim();
                fabricDetail.FabricCode = fabricDetail.FabricCode.Trim();
                fabricDetail.UpdateDate = DateTime.Now;
                fabricDetail.UpdatedBy = 234;

                var person = db.FabricDetails
                    .Include(s => s.SystemUser)
                    .Where(s => s.Id == fabricDetail.Id)
                    .Select(s => new FabricDetailsViewModel
                    {
                        CreateDate = s.CreateDate,
                        CreatedBy = s.CreatedBy
                    })
                    .Single();

                fabricDetail.CreateDate = person.CreateDate;
                fabricDetail.CreatedBy = person.CreatedBy;

                if (ModelState.IsValid)
                {
                    db.Entry(fabricDetail).State = EntityState.Modified;
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

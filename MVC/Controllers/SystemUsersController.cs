using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVC.Models;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MVC.Controllers
{
    public class SystemUsersController : Controller
    {
        private GarmentsManagementEntities db = new GarmentsManagementEntities();
        
        public ActionResult Index()
        {
            var systemUsers = db.SystemUsers
                    .Include(s => s.SystemUser1)
                    .Select(s => new SystemUserViewModel
                    {
                        FullName = s.FullName,
                        Email = s.Email,
                        Image = s.Image,
                        UpdateDate = s.UpdateDate,
                        UpdatedBy = s.UpdatedBy,
                        Id = s.Id,
                        Status = s.Status,
                        EditedBy = s.SystemUser1.FullName + " ("+s.SystemUser1.Email+")"
                    }).OrderBy(s => new { s.Status, s.FullName});
            return View(systemUsers);
        }
        
        [HttpPost]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Json(0);
            }
            var systemUser = db.SystemUsers
                    .Include(s => s.SystemUser1)
                    .Where(s=> s.Id==id)
                    .Select(s => new SystemUserViewModel
                    {
                        FullName = s.FullName,
                        Email = s.Email,
                        Image = s.Image,
                        UpdateDateString = s.UpdateDate.ToString(),
                        UpdatedBy = s.UpdatedBy,
                        Id = s.Id,
                        Status = s.Status,
                        EditedBy = s.SystemUser1.FullName + " (" + s.SystemUser1.Email + ")"
                    }).OrderBy(s => new { s.Status, s.FullName }).Single();
            return Json(systemUser);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Email,Password,FullName,UpdateDate,UpdatedBy,Status")] SystemUser systemUser)
        {
            try
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 - .]");
                systemUser.FullName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rgx.Replace(systemUser.FullName, "").ToLower()).Trim();
                systemUser.Email = systemUser.Email.ToLower().Trim();
                systemUser.UpdateDate = DateTime.Now;
                systemUser.UpdatedBy = null;
                systemUser.Status = 1;

                if (ModelState.IsValid)
                {
                    db.SystemUsers.Add(systemUser);
                    db.SaveChanges();
                    return Json(1);
                }
                else
                {
                    return Json(2);
                }
            }
            catch (Exception e) {
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
            var systemUser = db.SystemUsers
                    .Include(s => s.SystemUser1)
                    .Where(s => s.Id == id)
                    .Select(s => new SystemUserViewModel
                    {
                        FullName = s.FullName,
                        Email = s.Email,
                        Status = s.Status
                    }).OrderBy(s => new { s.Status, s.FullName }).Single();
            return Json(systemUser);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Email,FullName,UpdateDate,UpdatedBy,Status")] SystemUser systemUser)
        {
            try
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 - .]");
                systemUser.FullName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rgx.Replace(systemUser.FullName, "").ToLower()).Trim();
                systemUser.Email = systemUser.Email.ToLower().Trim();
                systemUser.UpdateDate = DateTime.Now;

                var person = db.SystemUsers
                    .Include(s => s.SystemUser1)
                    .Where(s => s.Id == systemUser.Id)
                    .Select(s => new SystemUserViewModel
                    {
                        Password = s.Password
                    }).Single();

                systemUser.Password = person.Password;
                systemUser.UpdatedBy = null;

                if (ModelState.IsValid)
                {
                    db.Entry(systemUser).State = EntityState.Modified;
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

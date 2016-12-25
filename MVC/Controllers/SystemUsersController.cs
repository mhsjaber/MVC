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
        private GarmentsManagementEntities2 db = new GarmentsManagementEntities2();
        
        public ActionResult Index(string msg="")
        {
            ViewBag.Message = msg;
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
                systemUser.FullName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rgx.Replace(systemUser.FullName, "").ToLower());
                systemUser.Email = systemUser.Email.ToLower();
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

        // GET: SystemUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemUser systemUser = db.SystemUsers.Find(id);
            if (systemUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.UpdatedBy = new SelectList(db.SystemUsers, "Id", "UserName", systemUser.UpdatedBy);
            return View(systemUser);
        }

        // POST: SystemUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,FullName,UpdateDate,UpdatedBy,Status")] SystemUser systemUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(systemUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UpdatedBy = new SelectList(db.SystemUsers, "Id", "UserName", systemUser.UpdatedBy);
            return View(systemUser);
        }

        // GET: SystemUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemUser systemUser = db.SystemUsers.Find(id);
            if (systemUser == null)
            {
                return HttpNotFound();
            }
            return View(systemUser);
        }

        // POST: SystemUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SystemUser systemUser = db.SystemUsers.Find(id);
            db.SystemUsers.Remove(systemUser);
            db.SaveChanges();
            return RedirectToAction("Index");
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

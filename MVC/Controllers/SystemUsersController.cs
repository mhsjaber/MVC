using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Data.SqlClient;

namespace MVC.Controllers
{
    public class SystemUsersController : Controller
    {
        private GarmentsManagementEntities2 db = new GarmentsManagementEntities2();

        // GET: SystemUsers
        public ActionResult Index()
        {
            var systemUsers = db.SystemUsers.Include(s => s.SystemUser1);
            return View(systemUsers.ToList());
        }

        // GET: SystemUsers/Details/5
        public ActionResult Details(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Password,FullName,UpdateDate,UpdatedBy,Status")] SystemUser systemUser)
        {
            try
            {
                systemUser.UpdateDate = DateTime.Now;
                systemUser.UpdatedBy = 1;
                systemUser.Status = 1;

                if (ModelState.IsValid)
                {
                    db.SystemUsers.Add(systemUser);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return Json(1);
                }
            }
            catch (SqlException e)
            {
                return Json(e.Number);
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

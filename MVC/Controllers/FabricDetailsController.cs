using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class FabricDetailsController : Controller
    {
        private GarmentsManagementEntities2 db = new GarmentsManagementEntities2();
        
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
                    EditedBy = s.SystemUser.Email
                });
            return View(fabricDetails.ToList());
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HttpErrorController : Controller
    {
        // GET: HttpError
        public ActionResult Error404()
        {
            return View();
        }
    }
}
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Monopura" };
            return View(movie);
        }
        public ActionResult Edit(int Id)
        {
            return Content("Id = " + Id);
        }
        public ActionResult Index(int? PageIndex, string SortBy)
        {
            if (!PageIndex.HasValue) {
                PageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(SortBy)) {
                SortBy = "Name";
            }
            return Content("Page Index = " + PageIndex + ", Sort By = " + SortBy);
        }
    }
}
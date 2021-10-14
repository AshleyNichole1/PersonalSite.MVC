using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalsiteConverted.Controllers
{
    public class ResumeController : Controller
    {
        // GET: Resume
        public ActionResult Index()
        {
            ViewBag.Message = "Your resume page.";

            return View();
        }
    }
}
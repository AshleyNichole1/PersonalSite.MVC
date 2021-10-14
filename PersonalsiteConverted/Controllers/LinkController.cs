using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalsiteConverted.Controllers
{
    public class LinkController : Controller
    {
        // GET: Link
        public ActionResult Index()
        {
            ViewBag.Message = "Your Links page.";

            return View();
        }
    }
}
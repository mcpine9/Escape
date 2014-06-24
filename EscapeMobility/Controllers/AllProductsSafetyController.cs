using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeMobility.Controllers
{
    public partial class AllProductsSafetyController : Controller
    {
        // GET: Safety
        public virtual ActionResult Index()
        {
            return RedirectToAction("EmergencyAid");
        }

        public virtual ActionResult EmergencyAid()
        {
            return View("~/Views/Safety/EmergencyAid.cshtml");
        }

        public virtual ActionResult Lockers()
        {
            return View("~/Views/Safety/Lockers.cshtml");
        }

        public virtual ActionResult Smokehood()
        {
            return View("~/Views/Safety/Smokehood.cshtml");
        }
    }
}
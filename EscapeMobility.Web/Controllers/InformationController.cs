using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeMobility.Controllers
{
    public partial class InformationController : Controller
    {
        // GET: Information
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult CompanyInfo()
        {
            return RedirectToAction("Index");
        }

        public virtual ActionResult Innovation()
        {
            return View();
        }

        public virtual ActionResult References()
        {
            return View();
        }

        public virtual ActionResult Events()
        {
            return View();
        }

        public virtual ActionResult History()
        {
            return View();
        }

        public virtual ActionResult Brochures()
        {
            return View();
        }

        public virtual ActionResult WorldwideDistribution()
        {
            return View();
        }

        public virtual ActionResult DistributorsWanted()
        {
            return View();
        }

        public virtual ActionResult News()
        {
            return View();
        }
    }
}
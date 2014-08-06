using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeMobility.Controllers
{
    public partial class ServiceController : Controller
    {
        // GET: Service
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult CustomerService()
        {
            return RedirectToAction("Index");
        }

        public virtual ActionResult Contact()
        {
            return View();
        }

        public virtual ActionResult PrivacyStatement()
        {
            return View();
        }

        public virtual ActionResult Terms()
        {
            return View();
        }
    }
}
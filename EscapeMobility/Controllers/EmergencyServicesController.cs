using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeMobility.Controllers
{
    public partial class EmergencyServicesController : Controller
    {
        // GET: EmergencyServices
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult EscapeChair()
        {
            return View();
        }

        public virtual ActionResult EscapeCarryChair()
        {
            return View();
        }

        public virtual ActionResult EscpaeMattress()
        {
            return View();
        }

        public virtual ActionResult Accessories()
        {
            return View();
        }
    }
}
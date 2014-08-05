using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeMobility.Controllers
{
    public partial class OfficeBuildingsController : Controller
    {
        // GET: OfficeBuildings
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult EscapeChair()
        {
            return View();
        }

        public virtual ActionResult EscapeMattress()
        {
            return View();
        }

        public virtual ActionResult Accessories()
        {
            return View();
        }

        public virtual ActionResult Safety(string category)
        {
            switch (category)
            {
                case "EmergencyAid":
                    return View("Safety/EmergencyAid", new SafetyEquipment(ControllerContext));
                case "Lockers":
                    return View("Safety/Lockers", new SafetyEquipment(ControllerContext));
                case "Smokehood":
                    return View("Safety/Smokehood", new SafetyEquipment(ControllerContext));
                default:
                    return RedirectToAction("Index");
            }
        }
}
}
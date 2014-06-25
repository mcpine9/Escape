using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeMobility.Controllers
{
    public partial class AllProductsController : Controller
    {
        // GET: AllProducts
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
                    return PartialView("~/Views/Safety/EmergencyAid.cshtml", new SafetyEquipment(ControllerContext));
                case "Lockers":
                    return PartialView("~/Views/Safety/Lockers.cshtml", new SafetyEquipment(ControllerContext));
                case "Smokers":
                    return PartialView("~/Views/Safety/Smokehood.cshtml", new SafetyEquipment(ControllerContext));
                default:
                    return RedirectToAction("Index");
            }
        }

        public virtual ActionResult MainLeftMenu()
        {
            return PartialView("MainLeftMenu");
        }
    }

    public class SafetyEquipment
    {
        public SafetyEquipment(ControllerContext context)
        {
            var cname = context.RouteData.Values["Controller"].ToString();
        }
    }

}
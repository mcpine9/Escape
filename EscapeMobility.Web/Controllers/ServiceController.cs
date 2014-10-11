using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EscapeMobility.Web.Models;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Contact([Bind(Include = "FirstName,LastName,MiddleName,Title,Email,Phone,Phone2,Address1,Address2,City,State,Zip")] ContactFormViewModel vm)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeMobility.Controllers
{
    public partial class QuoteController : Controller
    {
        // GET: Quote
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeMobility.Controllers
{
    public partial class EducationController : Controller
    {
        // GET: Education
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escape.Data;
using Escape.Data.Model;
using EscapeMobility.Web.Models;
using EscapeMobility.Web.WebUtilities;

namespace EscapeMobility.Controllers
{
    public partial class IndustryController : Controller
    {
        private EscapeDataModel _db;

        public IndustryController()
        {
            _db = new EscapeDataModel();
        }
        // GET: Industry
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult EscapeChair()
        {
            ViewBag.IsDevSubDomain = DomainResolver.IsDevSubDomain(HttpContext);
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryId == 7));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeChair)
            };
            return View(model);
        }

        public virtual ActionResult EscapeCarryChair()
        {
            ViewBag.IsDevSubDomain = DomainResolver.IsDevSubDomain(HttpContext);
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryId == 7));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeCarryChair)
            };
            return View(model);
        }

        public virtual ActionResult EscapeMattress()
        {
            ViewBag.IsDevSubDomain = DomainResolver.IsDevSubDomain(HttpContext);
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryId == 7));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeMattress)
            };
            return View(model);
        }

        public virtual ActionResult Accessories()
        {
            ViewBag.IsDevSubDomain = DomainResolver.IsDevSubDomain(HttpContext);
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryId == 7));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.Accessories)
            };
            return View(model);
        }

        public virtual ActionResult Safety(string category)
        {
            ViewBag.IsDevSubDomain = DomainResolver.IsDevSubDomain(HttpContext);
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryId == 2));
            var model = new ProductHighlightModels();
            switch (category)
            {
                case "EmergencyAid":
                    model.ProductHighlights = ProductHelper.ToSafetyTypeProductHighlights(products, SafetyType.EmergencyAid);
                    return View("Safety/EmergencyAid", model);
                case "Lockers":
                    model.ProductHighlights = ProductHelper.ToSafetyTypeProductHighlights(products, SafetyType.Lockers);
                    return View("Safety/Lockers", model);
                case "Smokehood":
                    model.ProductHighlights = ProductHelper.ToSafetyTypeProductHighlights(products, SafetyType.Smokehood);
                    return View("Safety/Smokehood", model);
                default:
                    return RedirectToAction("Index");
            }
        }

        public virtual ActionResult Details(int id)
        {
            ProductSpecification spec = _db.Products.SingleOrDefault(s => s.Id == id).ProductSpecification;
            Product product = _db.Products.Find(id);
            if (spec != null)
            {
                var vm = new ProductSpecificationsViewModel()
                {
                    ArticleNumber = product.ArticleNumber,
                    Discount = product.Discount,
                    ImageFileName = product.ImageFileName,
                    LongDescription = product.LongDescription,
                    Price = product.Price,
                    ShortDescription = product.ShortDescription,
                    Title = product.Title

                };
                return View(vm);
            }
            return View(MVC.Industry.Index());
        }
    }
}
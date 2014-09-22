using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escape.Data;
using Escape.Data.Model;
using EscapeMobility.Web.Models;

namespace EscapeMobility.Controllers
{
    public partial class HealthCareController : Controller
    {
        private EscapeDataContext _db;

        public HealthCareController()
        {
            _db = new EscapeDataContext();
        }
        // GET: HealthCare
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult ProductHighlightList(ProductHighlightModel highlight)
        {
            return PartialView("_ProductHighlight", highlight);
        }

        public virtual ActionResult EscapeChair()
        {
            var products = _db.Product.Where(p => p.Categories.Any(c => c.CategoryId == 3));
            var highlights = (
                from p in products
                where p.EvacuationType == EvacuationType.EscapeChair
                select new ProductHighlightModel()
                {
                    ProductID = p.ProductId,
                    ImageFileName = p.ImageFileName,
                    Name = p.Title,
                    Price = p.Price,
                    ShortDescription = p.ShortDescription
                }).ToList();
            var model = new ProductHighlightModels
            {
                ProductHighlights = highlights
            };
            return View(model);
        }

        public virtual ActionResult EscapeMattress()
        {
            var products = _db.Product.Where(p => p.Categories.Any(c => c.CategoryId == 3));
            var highlights = (
                from p in products
                where p.EvacuationType == EvacuationType.EscapeMattress
                select new ProductHighlightModel()
                {
                    ProductID = p.ProductId,
                    ImageFileName = p.ImageFileName,
                    Name = p.Title,
                    Price = p.Price,
                    ShortDescription = p.ShortDescription
                }).ToList();
            var model = new ProductHighlightModels
            {
                ProductHighlights = highlights
            };
            return View(model);
        }

        public virtual ActionResult Accessories()
        {
            var products = _db.Product.Where(p => p.Categories.Any(c => c.CategoryId == 3));
            var highlights = (
                from p in products
                where p.IsAccessory
                select new ProductHighlightModel()
                {
                    ProductID = p.ProductId,
                    ImageFileName = p.ImageFileName,
                    Name = p.Title,
                    Price = p.Price,
                    ShortDescription = p.ShortDescription
                }).ToList();
            var model = new ProductHighlightModels
            {
                ProductHighlights = highlights
            };
            return View(model);
        }

        public virtual ActionResult Safety(string category)
        {
            var products = _db.Product.Where(p => p.Categories.Any(c => c.CategoryId == 2));
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
    }
}
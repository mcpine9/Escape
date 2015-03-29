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
    public partial class HealthCareController : Controller
    {
        private EscapeDataModel _db;

        public HealthCareController()
        {
            _db = new EscapeDataModel();
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
            
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryId == 3));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeChair),
                IsDev = (bool) DomainResolver.IsDevSubDomain(HttpContext)
            };
            return View(model);
        }

        public virtual ActionResult EscapeMattress()
        {
            
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryId == 3));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeMattress),
                IsDev = (bool) DomainResolver.IsDevSubDomain(HttpContext)
            };
            return View(model);
        }

        public virtual ActionResult Accessories()
        {
            
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryId == 3));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.Accessories),
                IsDev = (bool) DomainResolver.IsDevSubDomain(HttpContext)
            };
            return View(model);
        }

        public virtual ActionResult Safety(string category)
        {
            
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
            CustomSpecification spec = _db.CustomeSpecifications.SingleOrDefault(s => s.Products.Any(p => p.Id == id));
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
                    Title = product.Title,
                    ProductId = product.Id,
                    json = spec.SpecificationObject,
                    Show = spec.Show,
                    ShowInProd = spec.ShowInProd

                };
                return View(vm);
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
    }
}
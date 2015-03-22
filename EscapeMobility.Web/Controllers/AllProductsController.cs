﻿using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Escape.Data;
using Escape.Data.Model;
using EscapeMobility.Web.Models;
using EscapeMobility.Web.WebUtilities;
using Microsoft.Ajax.Utilities;
using WebGrease.Css.Ast.Selectors;

namespace EscapeMobility.Controllers
{
    public partial class AllProductsController : Controller
    {
        private EscapeDataModel _db { get; set; }

        public AllProductsController()
        {
            _db = new EscapeDataModel();
        }

        public virtual ActionResult ProductHighlightList(ProductHighlightModel highlight)
        {
            return PartialView("_ProductHighlight", highlight);
        }

        // GET: AllProducts

        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult EscapeChair()
        {
            ViewBag.IsDevDomain = DomainResolver.IsDevSubDomain(HttpContext);
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryId == 2));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeChair)
            };
            return View(model);
        }

        public virtual ActionResult EscapeCarryChair()
        {
            ViewBag.IsDevDomain = DomainResolver.IsDevSubDomain(HttpContext);
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryId == 2));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeCarryChair)
            };
            return View(model);
        }

        public virtual ActionResult EscapeMattress()
        {
            ViewBag.IsDevDomain = DomainResolver.IsDevSubDomain(HttpContext);
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryId == 2));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeMattress)
            };
            return View(model);
        }

        public virtual ActionResult Accessories()
        {
            ViewBag.IsDevDomain = DomainResolver.IsDevSubDomain(HttpContext);
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryId == 2));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.Accessories)
            };
            return View(model);
        }

        public virtual ActionResult Safety(string category)
        {
            ViewBag.IsDevDomain = DomainResolver.IsDevSubDomain(HttpContext);
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
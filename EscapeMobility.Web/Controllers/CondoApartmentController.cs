using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escape.Data;
using Escape.Data.Model;
using EscapeMobility.Controllers;
using EscapeMobility.Web.Models;

namespace EscapeMobility.Web.Controllers
{
    public partial class CondoApartmentController : Controller
    {
        private EscapeDataModel _db;
        public CondoApartmentController()
        {
            _db = new EscapeDataModel();
        }

        public virtual ActionResult ProductHighlightList(ProductHighlightModel highlight)
        {
            return PartialView("_ProductHighlight", highlight);
        }

        // GET: CondoApartment
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult EscapeChair()
        {
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryName == "Condo/Apartments"));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeChair)
            };
            return View(model);
        }

        public virtual ActionResult EscapeCarryChair()
        {
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryName == "Condo/Apartments"));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeCarryChair)
            };
            return View(model);
        }

        public virtual ActionResult EscapeMattress()
        {
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryName == "Condo/Apartments"));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeMattress)
            };
            return View(model);
        }

        public virtual ActionResult Accessories()
        {
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryName == "Condo/Apartments"));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.Accessories)
            };
            return View(model);
        }
        public virtual ActionResult Safety(string category)
        {
            var products = _db.Products.Where(p => p.Categories.Any(c => c.CategoryName == "Condo/Apartments"));
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
                    Armrest = spec.Armrest,
                    ArticleNumber = product.ArticleNumber,
                    Backrest = spec.Backrest,
                    DimensionsFoldedUp = spec.DimensionsFoldedUp,
                    Discount = product.Discount,
                    Footrest = spec.Footrest,
                    HasAniSlipHandle = spec.HasAniSlipHandle,
                    HasDustCover = spec.HasDustCover,
                    HasErgonomicBackrest = spec.HasErgonomicBackrest,
                    HasGlidingBeltSystem = spec.HasGlidingBeltSystem,
                    HasImmobilizationBand = spec.HasImmobilizationBand,
                    HasUnfoldingStand = spec.HasUnfoldingStand,
                    ImageFileName = product.ImageFileName,
                    IsEasyToOperate = spec.IsEasyToOperate,
                    IsReadyForUse = spec.IsReadyForUse,
                    LongDescription = product.LongDescription,
                    Material = spec.Material,
                    MaxAngleOfStairs = spec.MaxAngleOfStairs,
                    MaxCarryingCapacity = spec.MaxCarryingCapacity,
                    OperatingHandle = spec.OperatingHandle,
                    HasPaddedHeadRest = spec.HasPaddedHeadRest,
                    Price = product.Price,
                    Seat = spec.Seat,
                    ShortDescription = product.ShortDescription,
                    Title = product.Title,
                    LimitedWarranty = spec.LimitedWarranty,
                    Weight = spec.Weight

                };
                return View(vm);
            }
            return View(MVC.CondoApartment.Index());
        }
    }
}
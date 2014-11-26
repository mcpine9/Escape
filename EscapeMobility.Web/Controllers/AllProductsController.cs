using System.Linq;
using System.Web.Mvc;
using Escape.Data;
using Escape.Data.Model;
using EscapeMobility.Web.Models;
using WebGrease.Css.Ast.Selectors;

namespace EscapeMobility.Controllers
{
    public partial class AllProductsController : Controller
    {
        private EscapeDataContext _db { get; set; }

        public AllProductsController()
        {
            _db = new EscapeDataContext();
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
            var products = _db.Product.Where(p => p.Categories.Any(c => c.CategoryId == 2));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeChair)
            };
            return View(model);
        }

        public virtual ActionResult EscapeCarryChair()
        {
            var products = _db.Product.Where(p => p.Categories.Any(c => c.CategoryId == 2));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeCarryChair)
            };
            return View(model);
        }

        public virtual ActionResult EscapeMattress()
        {
            var products = _db.Product.Where(p => p.Categories.Any(c => c.CategoryId == 2));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.EscapeMattress)
            };
            return View(model);
        }

        public virtual ActionResult Accessories()
        {
            var products = _db.Product.Where(p => p.Categories.Any(c => c.CategoryId == 2));
            var model = new ProductHighlightModels
            {
                ProductHighlights = ProductHelper.ToEvacuationTypeProductHighlights(products, EvacuationType.Accessories)
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

        public virtual ActionResult Details(int id)
        {
            ProductSpecification spec = _db.Product.SingleOrDefault(s => s.ProductId == id).ProductSpecification;
            Product product = _db.Product.Find(id);
            if (spec != null)
            {
                var vm = new ProductSpecificationsViewModel()
                {
                    Armrest = spec.Armrest,
                    ArticleNumber = product.ArticleNumber,
                    Backrest = spec.Backrest,
                    Dimensions = spec.DimensionsFoldedUp,
                    DimentionsFoldedUp = spec.DimensionsFoldedUp,
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
                    Warranty = spec.LimitedWarranty,
                    Weight = spec.Weight

                };
                return View(vm);   
            }
            return View(new ProductSpecificationsViewModel());
        }
    }
}
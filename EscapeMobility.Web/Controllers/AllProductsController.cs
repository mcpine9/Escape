using System.Linq;
using System.Web.Mvc;
using Escape.Data;
using EscapeMobility.Web.Models;

namespace EscapeMobility.Controllers
{
    public partial class AllProductsController : Controller
    {
        private EscapeDataContext _db { get; set; }

        public AllProductsController()
        {
            _db = new EscapeDataContext();
        }
        // GET: AllProducts
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Details(int id)
        {
            return View();
        }

        public virtual ActionResult EscapeChair()
        {
            var products = _db.Product.ToList();
            var highlights = (
                from p in products
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

        public virtual ActionResult EscapeChairHighlightList(ProductHighlightModel highlight)
        {
            return PartialView("_ProductHighlightList", highlight);
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
                    return View("Safety/EmergencyAid", new SafetyEquipment(ControllerContext));
                case "Lockers":
                    return View("Safety/Lockers", new SafetyEquipment(ControllerContext));
                case "Smokehood":
                    return View("Safety/Smokehood", new SafetyEquipment(ControllerContext));
                default:
                    return RedirectToAction("Index");
            }
        }

    }
}
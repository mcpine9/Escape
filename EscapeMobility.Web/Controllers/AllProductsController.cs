﻿using System.Linq;
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
            var products = _db.Product.Where(p => p.Categories.Any(c => c.CategoryId == 2));
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

        public virtual ActionResult ProductHighlightList(ProductHighlightModel highlight)
        {
            return PartialView("_ProductHighlight", highlight);
        }

        public virtual ActionResult EscapeCarryChair()
        {
            var products = _db.Product.Where(p => p.Categories.Any(c => c.CategoryId == 2));
            var highlights = (
                from p in products
                where p.EvacuationType == EvacuationType.EscapeCarryChair
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
            var products = _db.Product.Where(p => p.Categories.Any(c => c.CategoryId == 2));
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
            var products = _db.Product.Where(p => p.Categories.Any(c => c.CategoryId == 2));
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
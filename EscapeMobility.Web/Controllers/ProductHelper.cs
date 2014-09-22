using System.Collections.Generic;
using System.Linq;
using Escape.Data.Model;
using EscapeMobility.Web.Models;

namespace EscapeMobility.Controllers
{
    public static class ProductHelper
    {
        public static List<ProductHighlightModel> ToSafetyTypeProductHighlights(IQueryable<Product> products, SafetyType type)
        {
            return (
                from p in products
                where p.SafetyType == type
                select new ProductHighlightModel()
                {
                    ProductID = p.ProductId,
                    ImageFileName = p.ImageFileName,
                    Name = p.Title,
                    Price = p.Price,
                    ShortDescription = p.ShortDescription
                }).ToList();
        }

        public static List<ProductHighlightModel> ToEvacuationTypeProductHighlights(IQueryable<Product> products, EvacuationType type)
        {
            return (
                from p in products
                where p.EvacuationType == type
                select new ProductHighlightModel()
                {
                    ProductID = p.ProductId,
                    ImageFileName = p.ImageFileName,
                    Name = p.Title,
                    Price = p.Price,
                    ShortDescription = p.ShortDescription
                }).ToList();
        }
    }
}
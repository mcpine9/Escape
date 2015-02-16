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
                where p.SafetyType == (decimal) type
                select new ProductHighlightModel()
                {
                    ProductID = p.Id,
                    ImageFileName = p.ImageFileName,
                    Name = p.Title,
                    Price = p.Price,
                    ShortDescription = p.ShortDescription,
                    HasSpec = !p.ProductSpecification.Equals(null)
                }).ToList();
        }

        public static List<ProductHighlightModel> ToEvacuationTypeProductHighlights(IQueryable<Product> products, EvacuationType type)
        {
            return (
                from p in products
                where p.EvacuationType == (decimal) type
                select new ProductHighlightModel()
                {
                    ProductID = p.Id,
                    ImageFileName = p.ImageFileName,
                    Name = p.Title,
                    Price = p.Price,
                    ShortDescription = p.ShortDescription,
                    HasSpec = !p.ProductSpecification.Equals(null)
                }).ToList();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Escape.Data.Model;
using EscapeMobility.Web.Models;
using Microsoft.Ajax.Utilities;

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
                    HasSpec = !p.ProductSpecification.Equals(null),
                    Show = p.CustomSpecifications.Any() && p.CustomSpecifications.FirstOrDefault(x => x.Products.Contains(p)).Show,
                    ShowInProd = p.CustomSpecifications.Any() && p.CustomSpecifications.FirstOrDefault(x => x.Products.Contains(p)).ShowInProd
                }).ToList();
        }

        public static List<ProductHighlightModel> ToEvacuationTypeProductHighlights(IQueryable<Product> products, EvacuationType type)
        {
            return (
                from p in products
                where p.EvacuationType == (decimal)type
                select new ProductHighlightModel()
                {
                    ProductID = p.Id,
                    ImageFileName = p.ImageFileName,
                    Name = p.Title,
                    Price = p.Price,
                    ShortDescription = p.ShortDescription,
                    HasSpec = !p.ProductSpecification.Equals(null),
                    Show = p.CustomSpecifications.Any() && p.CustomSpecifications.FirstOrDefault(x => x.Products.Contains(p)).Show,
                    ShowInProd = p.CustomSpecifications.Any() && p.CustomSpecifications.FirstOrDefault(x => x.Products.Contains(p)).ShowInProd
                }).ToList();
        }
    }
}
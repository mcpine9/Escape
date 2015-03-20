using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Escape.Data.Model;

namespace EscapeMobility.Web.Models
{
    public class ProductSpecificationsViewModel
    {
        #region Product

        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Thumbnailfolder { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public long ArticleNumber { get; set; }
        public string VideoSampleURL { get; set; }
        public string SafetyTags { get; set; }
        public string RelatedTags { get; set; }
        public bool IsAccessory { get; set; }
        public string ImageFileName { get; set; }

        #endregion


        #region Product Specification

        public string json { get; set; }
        public bool Show { get; set; }
        public bool ShowInProd { get; set; }

        #endregion
        public List<ProductHighlightModel> ProductHighlights { get; set; }
    }
}
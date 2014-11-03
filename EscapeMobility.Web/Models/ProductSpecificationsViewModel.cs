using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Escape.Data.Model;

namespace EscapeMobility.Web.Models
{
    public class ProductSpecificationsViewModel
    {
        #region Product

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

        public bool IsSpecificationOn { get; set; }
        public string Material { get; set; }
        public bool IsEasyToOperate { get; set; }
        public bool IsReadyForUse { get; set; }
        public bool HasUnfoldingStand { get; set; }
        public bool HasErgonomicBackrest { get; set; }
        public bool HasGlidingBeltSystem { get; set; }
        public bool HasDustCover { get; set; }
        public bool HasAniSlipHandle { get; set; }
        public int? MaxCarryingCapacity { get; set; }
        public int? MaxAngleOfStairs { get; set; }
        public string OperatingHandle { get; set; }
        public string Seat { get; set; }
        public string Backrest { get; set; }
        public string Footrest { get; set; }
        public string Armrest { get; set; }
        public bool HasImmobilizationBand { get; set; }
        public string PaddedHeadrest { get; set; }
        public string DimentionsFoldedUp { get; set; }
        public string Warranty { get; set; }
        public string Weight { get; set; }
        public string Dimensions { get; set; }
        public string LimitedWarranty { get; set; }

        #endregion

    }
}
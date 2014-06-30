using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Data
{
    class ProductSpecifications
    {
        public int SpecificationId { get; set; }
        public bool IsSpecificationOn { get; set; }
        public string Material   { get; set; }
        public bool IsEasyToOperate { get; set; }
        public bool IsReadyForUse { get; set; }
        public bool HasUnfoldingStand { get; set; }
        public bool HasErgonomicBackrest { get; set; }
        public bool HasGlidingBeltSystem{ get; set; }
        public bool HasDustCover{ get; set; }
        public bool HasAniSlipHandle{ get; set; }
        public int MaxCarryingCapacity{ get; set; }
        public int MaxAngleOfStairs{ get; set; }
        public string OperatingHandle{ get; set; }
        public string Seat { get; set; }
        public string Backrest{ get; set; }
        public string Footrest{ get; set; }
        public string Armrest{ get; set; }
        public bool HasImmobilizationBand{ get; set; }
        public bool HasPaddedHeadrest{ get; set; }
        public string DimentionsFoldedUp{ get; set; }
        public string Waranty{ get; set; }
    }
}

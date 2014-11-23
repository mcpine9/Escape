using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escape.Data.Model
{
    public class ProductSpecification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductSpecificationId { get; set; }
        public bool IsSpecificationOn { get; set; }
        public string Material   { get; set; }
        [Display(Name = "Light weight, easy to operate:")]
        public bool IsEasyToOperate { get; set; }
        [Display(Name = "Ready for use within a few seconds:")]
        public bool IsReadyForUse { get; set; }
        [Display(Name = "Unfolding stand with wide wheel base for horizontal transport:")]
        public bool HasUnfoldingStand { get; set; }
        [Display(Name = "Ergonomic backrest:")]
        public bool HasErgonomicBackrest { get; set; }
        [Display(Name = "Gliding belt system in safe closed exchangeable cassette:")]
        public bool HasGlidingBeltSystem{ get; set; }
        [Display(Name = "Supplied with dust cover:")]
        public bool HasDustCover{ get; set; }
        [Display(Name = "Anti-slip on operating handle and lower bracket:")]
        public bool HasAniSlipHandle{ get; set; }
        [Display(Name = "Maximum carrying capacity:")]
        public string MaxCarryingCapacity{ get; set; }
        [Display(Name = "Maximum angle of stairs:")]
        public string  MaxAngleOfStairs{ get; set; }
        [Display(Name = "Operating handle:")]
        public string OperatingHandle{ get; set; }
        [Display(Name = "Seat:")]
        public string Seat { get; set; }
        [Display(Name = "Backrest:")]
        public string Backrest{ get; set; }
        [Display(Name = "Footrest:")]
        public string Footrest{ get; set; }
        [Display(Name = "Armrests:")]
        public string Armrest{ get; set; }
        [Display(Name = "Head rest including immobilization band:")]
        public bool HasImmobilizationBand { get; set; }
        [Display(Name = "Dimensions folded up (H x W x D):")]
        public string DimensionsFoldedUp{ get; set; }
        [Display(Name = "Weight:")]
        public string Weight { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Display(Name = "Padded (upholstered) headrest:")]
        public bool HasPaddedHeadRest { get; set; }
        [Display(Name = "Limited Warranty")]
        public string LimitedWarranty { get; set; }
    }
}

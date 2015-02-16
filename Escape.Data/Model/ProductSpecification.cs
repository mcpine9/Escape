using System.ComponentModel.DataAnnotations.Schema;

namespace Escape.Data.Model
{
    [Table("ProductSpecification")]
    public partial class ProductSpecification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Material { get; set; }

        public bool IsEasyToOperate { get; set; }

        public bool IsReadyForUse { get; set; }

        public bool HasUnfoldingStand { get; set; }

        public bool HasErgonomicBackrest { get; set; }

        public bool HasGlidingBeltSystem { get; set; }

        public bool HasDustCover { get; set; }

        public bool HasAniSlipHandle { get; set; }

        public string MaxCarryingCapacity { get; set; }

        public string MaxAngleOfStairs { get; set; }

        public string OperatingHandle { get; set; }

        public string Seat { get; set; }

        public string Backrest { get; set; }

        public string Footrest { get; set; }

        public string Armrest { get; set; }

        public bool HasImmobilizationBand { get; set; }

        public string DimensionsFoldedUp { get; set; }

        public string Weight { get; set; }

        public bool HasPaddedHeadRest { get; set; }

        public string LimitedWarranty { get; set; }

        public virtual Product Product { get; set; }
    }
}

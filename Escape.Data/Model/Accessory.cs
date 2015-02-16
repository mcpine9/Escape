using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escape.Data.Model
{
    [Table("Accessory")]
    public partial class Accessory
    {
        public Accessory()
        {
            Products = new HashSet<Product>();
        }

        public int AccessoryId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

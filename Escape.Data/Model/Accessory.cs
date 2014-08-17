using System.Collections.Generic;

namespace Escape.Data.Model
{
    public class Accessory
    {
        public int AccessoryId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
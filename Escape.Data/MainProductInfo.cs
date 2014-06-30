using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Data
{
    class MainProductInfo
    {
        public MainProductInfo()
        {
            
        }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int SpecificationId { get; set; }
        public string Thumbnailfolder { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public long ArticleNumber { get; set; }
        public string VideoSample { get; set; }
        public string CategoryTags { get; set; }
        public string SafetyTags { get; set; }
        public string SimilarTags { get; set; }
 
    }
}

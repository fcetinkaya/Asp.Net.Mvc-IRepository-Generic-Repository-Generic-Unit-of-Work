using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_ECommece.Data.Domain
{
    //Schema ile çalış..
  //  [Table("Product", Schema = "Production")]
    public class Product : BaseEntity, IAuditEntity
    {
        private IList<ProductCategoryMapping> _productCategories;

        public Product()
        {
            _productCategories = new List<ProductCategoryMapping>();
        }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
        public bool ShowOnHomePage { get; set; }

        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }


        private IList<ProductCategoryMapping> ProductCategories { get; set; }
    }
}

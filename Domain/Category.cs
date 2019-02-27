using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_ECommece.Data.Domain
{
 //   [Table("Category")]
    public class Category : BaseEntity,IAuditEntity
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int PictureId { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }



        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}

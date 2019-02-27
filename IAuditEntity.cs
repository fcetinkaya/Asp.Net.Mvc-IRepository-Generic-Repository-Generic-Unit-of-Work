using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_ECommece.Data
{
    public interface IAuditEntity
    {
        int CreateUserId { get; set; }
        DateTime CreateDate { get; set; }
        int UpdateUserId { get; set; }
        DateTime UpdateDate { get; set; }
    }
}

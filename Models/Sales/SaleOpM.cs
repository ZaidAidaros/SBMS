using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Models.Sales
{
    class SaleOpM
    {
        internal int Id { get; set; }
        internal int EmpId { get; set; }
        internal int CustomerId { get; set; }
        internal decimal Total { get; set; }
        internal List<SItemM> items { get; set; }
        internal List<SDateM> dates { get; set; }
    }
}

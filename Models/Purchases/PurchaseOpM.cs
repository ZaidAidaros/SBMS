using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Models.Purchases
{
    class PurchaseOpM
    {
        internal int Id { get; set; }
        internal int EmpId { get; set; }
        internal int SupplierId { get; set; }
        internal decimal Total { get; set; }
        internal List<PuItemM> items { get; set; }
        internal List<PuDateM> dates { get; set; }
    }
}

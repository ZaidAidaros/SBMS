using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Models.Purchases
{
    class PuItemM
    {
        internal int Id { get; set; }
        internal int PurchaseId { get; set; }
        internal int ProductId { get; set; }
        internal decimal Quantity { get; set; }
        internal decimal TotalPrice { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Models.Stores
{
    class ProductDetialsM
    {
        internal int Id { get; set; }
        internal int ProductId { get; set; }
        internal DateTime StoreDate { get; set; }
        internal DateTime ExpireDate { get; set; }
        internal DateTime ProduceDate { get; set; }
        internal decimal Cost { get; set; }
        internal decimal Price { get; set; }
        internal decimal Quantity { get; set; }
    }
}

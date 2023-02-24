using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Models.Stores
{
    class ProductM
    {
        internal int Id { get; set; }
        internal int BarCode { get; set; }
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal string Note { get; set; }
        internal string UnitId { get; set; }
        internal string GroupId { get; set; }
        internal string CategoryId { get; set; }
        internal PLocatioonM Location { get; set; }


    }
}

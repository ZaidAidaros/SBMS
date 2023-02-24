using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Models.Sales
{
    class SDateM
    {
        internal int Id { get; set; }
        internal int SaleId { get; set; }
        internal DateTime Date { get; set; }
        internal string Note { get; set; }
    }
}

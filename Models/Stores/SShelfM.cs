using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Models.Stores
{
    class SShelfM
    {
        internal int Id { get; set; }
        internal int StoreId { get; set; }
        internal int NumberOfRows { get; set; }
        internal int NumberOfColumns { get; set; }
    }
}

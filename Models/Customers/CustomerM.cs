using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Models.Customers
{
    class CustomerM
    {
        internal int Id { get; set; }
        internal int AccountId { get; set; }
        internal int CategoryId { get; set; }
        internal int GenderId { get; set; }
        internal int NIC { get; set; }
        internal string Name { get; set; }
        internal string Address { get; set; }
        internal DateTime BirtDate { get; set; }

    }
}

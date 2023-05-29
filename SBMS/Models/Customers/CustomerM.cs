using SBMS.Models.General;
using System;

namespace SBMS.Models.Customers
{
    class CustomerM
    {
        
        public int Id { get; set; }
        public int NIC { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string Gender { get; set; }
        public int GenderId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }

        public CustomerM()
        {
        }

    }
    
}

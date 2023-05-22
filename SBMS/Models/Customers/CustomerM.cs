using SBMS.Models.General;
using System;

namespace SBMS.Models.Customers
{
    class CustomerM
    {
        public CustCategoryM CategoryM { get; set; }
        public GenderM GenderM { get; set; }
        public int Id { get; set; }
        public int NIC { get; set; }
        public string Name { get; set; }
        public string Category { get => CategoryM.Name; set => CategoryM.Name = value; }
        public string Gender { get => GenderM.Name; set => GenderM.Name = value; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }

        public CustomerM()
        {
            CategoryM = new CustCategoryM();
            GenderM = new GenderM();
        }

    }
    
}

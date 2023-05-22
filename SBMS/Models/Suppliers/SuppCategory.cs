using SBMS.Models.General;

namespace SBMS.Models.Suppliers
{
    class SuppCategory : ICategoryM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

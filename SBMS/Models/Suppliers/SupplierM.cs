namespace SBMS.Models.Suppliers
{
    class SupplierM:ISupplierM
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public SuppCategory CategoryM { get; set; }
        public string Category { get=>CategoryM.Name; set=>CategoryM.Name=value; }

        public SupplierM()
        {
            CategoryM = new SuppCategory();
        }
    }
    interface ISupplierM
    {
        int Id { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
        string Address { get; set; }
        string Category { get; set; }
    }
}

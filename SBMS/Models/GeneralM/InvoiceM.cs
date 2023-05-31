using System;

namespace SBMS.Models.General
{
    class InvoiceM
    {
        public int Id { get; set; }
        public string NameOnInvoice { get; set; }
        public string EmpName { get; set; }
        public int EmpId { get; set; }
        public string Supplier { get; set; }
        public int SupplierId { get; set; }
        public string Customer { get; set; }
        public int CustomerId { get; set; }
        public string Note { get; set; }
        public string MonyStateName { get; set; }
        public int MonyStateId { get; set; }
        public string InvoiceTypeName { get; set; }
        public int InvoiceTypeId { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public DateTime Date { get; set; }
    }
}

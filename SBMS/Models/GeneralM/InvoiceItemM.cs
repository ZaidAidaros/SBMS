using SBMS.Models.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Models.General
{
    class InvoiceItemM
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int ProductDId { get; set; }
        public int OfferId { get; set; }
        public string Offer { get; set; }
        public int BarCode { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Price  { get; set; }
        public decimal DefPrice  { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice => this.Quantity*this.Price;
        public string ExpireDate { get; set; }

        public bool IsEqualTo(InvoiceItemM purchaseInvItem)
        {
            if (   this.Id == purchaseInvItem.Id
                && this.ProductId == purchaseInvItem.ProductId
                && this.InvoiceId == purchaseInvItem.InvoiceId
                && this.Price == purchaseInvItem.Price
                && this.Quantity == purchaseInvItem.Quantity
                && this.ExpireDate == purchaseInvItem.ExpireDate
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }

   
}

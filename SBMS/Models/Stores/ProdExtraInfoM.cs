using System;

namespace SBMS.Models.Stores
{
    public class ProdExtraInfoM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PurchaseId { get; set; }

        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }


        public decimal TotalCost { get=>Quantity*Cost; }
        public decimal TotalPrice { get=>Quantity*Price; }
        public decimal TotlBinifet { get => this.TotalPrice - this.TotalCost; }
        public decimal Binifet { get => this.Price - this.Cost; }

        public DateTime StoreDate { get; set; }
        public string ExpireDate { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

        public bool IsEqualTo(ProdExtraInfoM prodExtraInfo)
        {
            if (this.Id == prodExtraInfo.Id
                && this.ProductId == prodExtraInfo.ProductId
                && this.PurchaseId == prodExtraInfo.PurchaseId
                && this.PurchaseId == prodExtraInfo.PurchaseId
                && this.Quantity == prodExtraInfo.Quantity
                && this.ExpireDate == prodExtraInfo.ExpireDate
                && this.StoreDate == prodExtraInfo.StoreDate
                && (this.Price == prodExtraInfo.Price || this.Cost == prodExtraInfo.Cost)
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

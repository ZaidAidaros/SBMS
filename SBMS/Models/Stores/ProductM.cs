using System;

namespace SBMS.Models.Stores
{
    public class ProductM 
    {
        public int Id { get; set; }
        public int DId { get; set; }
        public int BarCode { get; set; }
        public string Name { get; set; }
        //public ProdCategoryM PCategory { get; set; }
        //public ProdUnitM PUnit { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string Unit { get; set; }
        public int UnitId { get; set; }
        public decimal DefPrice { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Price * Quantity;
        public decimal TotalCost => Cost * Quantity;
        public decimal Cost { get; set; }
        public DateTime StoreDate { get; set; }
        public string ExpireDate { get; set; }


        public bool IsEqualTo(ProductM productM)
        {
            if (  this.Id == productM.Id
                && this.BarCode == productM.BarCode
                && this.Name == productM.Name
                && this.Description == productM.Description
                && this.CategoryId == productM.CategoryId
                && this.UnitId == productM.UnitId
                //&& this.ProdExtraInfo.IsEqualTo(productM.ProdExtraInfo)
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

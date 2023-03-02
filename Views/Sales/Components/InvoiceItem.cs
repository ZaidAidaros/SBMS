using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Sales.Components
{
    public partial class InvoiceItem : UserControl
    {
        public InvoiceItem()
        {
            InitializeComponent();
        }
        string PName
        {
            get
            {
                return PName;
            }
            set
            {
                labelName.Text = PName;
            }
        }
        decimal Price
        {
            get
            {
                return Price;
            }
            set
            {
                labelName.Text = Price.ToString();
            }
        }
        decimal Quantity
        {
            get
            {
                return Quantity;
            }
            set
            {
                labelName.Text = Quantity.ToString();
            }
        }
        decimal Total
        {
            get
            {
                return Total;
            }
            set
            {
                labelName.Text = Total.ToString();
            }
        }

        internal void SetItem(string name, decimal price, decimal quantity)
        {
            PName = name;
            Price = price;
            Quantity = quantity;
            Total = price * quantity;

        }
    }
    
    
}

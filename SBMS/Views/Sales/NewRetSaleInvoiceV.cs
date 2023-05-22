using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Sales
{
    public partial class NewRetSaleInvoiceV : Form
    {
        private static NewRetSaleInvoiceV instance;
        public static NewRetSaleInvoiceV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new NewRetSaleInvoiceV();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
        private NewRetSaleInvoiceV()
        {
            InitializeComponent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Screens
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void butHClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTopBarMinue_Click(object sender, EventArgs e)
        {
            if (homeMinueSidePanelFL.Width > 40)
            {
                homeMinueSidePanelFL.Width = 40;
            }
            else
            {
                homeMinueSidePanelFL.Width = 134;
            }
        }
    }
}

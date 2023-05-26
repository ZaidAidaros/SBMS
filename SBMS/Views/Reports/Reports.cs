using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Reports
{
    public partial class ReportsHV : Form
    {
        private static ReportsHV instance;
        public static ReportsHV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ReportsHV();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
        private ReportsHV()
        {
            InitializeComponent();
        }
    }
}

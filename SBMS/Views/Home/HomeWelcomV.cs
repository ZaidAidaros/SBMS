using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Home
{
    public partial class HomeWelcomV : Form
    {
        private HomeWelcomV()
        {
            InitializeComponent();
        }
        //Singleton pattern (Open a single form instance)
        private static HomeWelcomV instance;
        public static HomeWelcomV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new HomeWelcomV();
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
                instance.Show();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
    }
}

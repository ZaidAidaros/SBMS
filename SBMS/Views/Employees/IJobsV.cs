using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Purchases
{
    interface IJobsV
    {
        bool IsAEJobTitleFormVisable { get; set; }
        string JobName { get; set; }
        string JobDescription { get; set; }
        DataGridView DGVJobs { get; }

        //Events Product Categories View
        event EventHandler ShowAddJobForm;
        event EventHandler ShowEditJobForm;
        event EventHandler DeleteSelectedJob;
        event EventHandler OnAEJobSave;
        event EventHandler OnAEJobCancel;
        event EventHandler OnSelectJob;

        bool ShowMsgBox(string msg, string title, bool isYesNo);
    }
}

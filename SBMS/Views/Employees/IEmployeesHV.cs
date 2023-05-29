﻿using System;
using System.Windows.Forms;

namespace SBMS.Views.Employees
{
    interface IEmployeesHV
    {
        Panel PnlEmployeesView { get; set; }
        Panel PnlJobsView { get; set; }

        string HeaderTitle { get; set; }

        // View Header
        event EventHandler ShowEmployeesView;
        event EventHandler ShowJobsView;
        event EventHandler OnDisposed;

    }
}

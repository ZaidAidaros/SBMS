using SBMS.Views.Employees;

namespace SBMS.Presenters.EmployeesPres
{
    class EmployeesHVPres
    {
        IEmployeesHV employeesHV;
        private EmployeesHVPres()
        {
            employeesHV = EmployeesHV.GetInstance();
            ShowEmployeesView();
            employeesHV.ShowEmployeesView += delegate { ShowEmployeesView(); };
            employeesHV.ShowJobsView += delegate { ShowJobsView(); };
            employeesHV.OnDisposed += delegate { Dispose(); };
        }
        /// <summary>
        /// 
        /// </summary>
        private static EmployeesHVPres instance;
        public static EmployeesHVPres GetInstance()
        {
            if (instance == null) instance = new EmployeesHVPres();
            return instance;
        }
        public static void Dispose()
        {
            instance = null;
        }

        private void ShowEmployeesView()
        {
            EmployeesVPres.GetInstance();
            employeesHV.HeaderTitle = "Employees";
            employeesHV.PnlEmployeesView.BringToFront();
        }

        private void ShowJobsView()
        {
            JobsVPres.GetInstance();
            employeesHV.HeaderTitle = "Employee Jobs";
            employeesHV.PnlJobsView.BringToFront();
        }

    }
}

using SBMS.Views.Employees;

namespace SBMS.Presenters.EmployeesPres
{
    class EmployeesHVPres
    {
        IEmployeesHV employeesHV;
        private EmployeesHVPres()
        {
            this.employeesHV = EmployeesHV.GetInstance();
            ShowEmployeesView();
            this.employeesHV.ShowEmployeesView += delegate { ShowEmployeesView(); };
            this.employeesHV.ShowJobsView += delegate { ShowJobsView(); };
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
        /// <summary>
        /// 
        /// </summary>

        private void ShowEmployeesView()
        {
            EmployeesVPres.GetInstance();
            this.employeesHV.HeaderTitle = "Employees";
            this.employeesHV.PnlEmployeesView.BringToFront();
        }

        private void ShowJobsView()
        {
            JobsVPres.GetInstance();
            this.employeesHV.HeaderTitle = "Employee Jobs";
            this.employeesHV.PnlJobsView.BringToFront();
        }

    }
}

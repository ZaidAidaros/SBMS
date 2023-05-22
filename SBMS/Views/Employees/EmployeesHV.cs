using SBMS.Presenters.EmployeesPres;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMS.Views.Purchases
{
    public partial class EmployeesHV : Form, IEmployeesHV,IEmployeesV,IJobsV
    {
        private EmployeesHV()
        {
            InitializeComponent();
            SbsEmployeesHVEvents();
            SbsEmployeesVEvents();
            SbsJobsVEvents();
            InitProp();
        }
        /// <summary>
        /// 
        /// </summary>
        //Singleton pattern (Open a single form instance)
        private static EmployeesHV instance;
        public static EmployeesHV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new EmployeesHV();
                EmployeesHVPres.GetInstance();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        public Panel PnlEmployeesView { get => this.pnlEmployeesView; set => this.pnlEmployeesView = value; }
        public Panel PnlJobsView { get => this.pnlJobsView; set => this.pnlJobsView = value; }
        public string HeaderTitle { get => this.lblHeaderTitle.Text; set => this.lblHeaderTitle.Text = value; }
        //
        public string EmployeeName { get => this.tbEmployeeName.Text; set => this.tbEmployeeName.Text = value; }
        public string EmployeeNIC { get => this.tbEmployeeNIC.Text; set => this.tbEmployeeNIC.Text = value; }
        public string EmployeePhone { get => this.tbEmployeePhone.Text; set => this.tbEmployeePhone.Text = value; }
        public string EmployeeAddress { get => this.tbEmployeeAddress.Text; set => this.tbEmployeeAddress.Text = value; }
        public string SearchValue { get => this.tbSearchEmployee.Text; set => this.tbSearchEmployee.Text = value; }
        public string EmployeeSalary { get => this.tbEmployeeSalary.Text; set => this.tbEmployeeSalary.Text = value; }
        public string EmployeeNote { get => this.tbEmployeeNote.Text; set => this.tbEmployeeNote.Text = value; }
        public ComboBox CBXEmployeeJob { get => this.cbxJobSelects; }
        public ComboBox CBXEmployeeGender { get => this.cbxGenderSelects; }
        public ComboBox CBXJobFilter { get => this.cbxJobFilter; }
        public DateTime DTEmployeeBirthDay { get => this.dtpEmployeeBDate.Value; set => this.dtpEmployeeBDate.Value = value; }
        public bool IsAEEmployeeFormVisable { get => this.fpnlAEEmployeeForm.Visible; set => this.fpnlAEEmployeeForm.Visible = value; }
        public DataGridView DGVEmployees { get => this.dgvEmployees; }
        //
        public bool IsAEJobTitleFormVisable { get => this.fpnlAEJobForm.Visible; set => this.fpnlAEJobForm.Visible = value; }
        public string JobName { get => this.tbJobName.Text; set => this.tbJobName.Text = value; }
        public string JobDescription { get => this.tbJobDescription.Text; set => this.tbJobDescription.Text = value; }
        public DataGridView DGVJobs { get => this.dgvJobs; }

        public event EventHandler ShowEmployeesView;
        public event EventHandler ShowJobsView;
        public event EventHandler ShowAddEmployeeForm;
        public event EventHandler ShowEditEmployeeForm;
        public event EventHandler DeleteSelectedEmployee;
        public event EventHandler OnJobFilterChanged;
        public event EventHandler OnSearchButtonClicked;
        public event EventHandler OnSelectEmployee;
        public event EventHandler OnAEEmployeeSave;
        public event EventHandler OnAEEmployeeCancel;
        public event EventHandler OnVRefresh;
        public event EventHandler ShowAddJobForm;
        public event EventHandler ShowEditJobForm;
        public event EventHandler DeleteSelectedJob;
        public event EventHandler OnAEJobSave;
        public event EventHandler OnAEJobCancel;
        public event EventHandler OnSelectJob;

        private void SbsEmployeesHVEvents()
        {
            this.btnShowEmployeesView.Click += delegate { this.ShowEmployeesView?.Invoke(this, EventArgs.Empty); };
            this.btnShowJobsView.Click += delegate { this.ShowJobsView?.Invoke(this, EventArgs.Empty); };
        }

        private void SbsEmployeesVEvents()
        {
            this.btnAddEmployee.Click += delegate { this.ShowAddEmployeeForm?.Invoke(this, EventArgs.Empty); };
            this.btnEditEmployee.Click += delegate { this.ShowEditEmployeeForm?.Invoke(this, EventArgs.Empty); };
            this.btnDeleteEmployee.Click += delegate { this.DeleteSelectedEmployee?.Invoke(this, EventArgs.Empty); };
            this.btnAEEmployeeSave.Click += delegate { this.OnAEEmployeeSave?.Invoke(this, EventArgs.Empty); };
            this.btnAEEmployeeCancel.Click += delegate { this.OnAEEmployeeCancel?.Invoke(this, EventArgs.Empty); };
            this.btnSearch.Click += delegate { this.OnSearchButtonClicked?.Invoke(this, EventArgs.Empty); };
            this.btnVRefresh.Click += delegate { this.OnVRefresh?.Invoke(this, EventArgs.Empty); };
            this.cbxJobFilter.SelectedIndexChanged += delegate { this.OnJobFilterChanged?.Invoke(this, EventArgs.Empty); };
            this.dgvEmployees.SelectionChanged += delegate { this.OnSelectEmployee?.Invoke(this, EventArgs.Empty); };
        }
        private void SbsJobsVEvents()
        {
            this.btnAddJob.Click += delegate { this.ShowAddJobForm?.Invoke(this, EventArgs.Empty); };
            this.btnEditJob.Click += delegate { this.ShowEditJobForm?.Invoke(this, EventArgs.Empty); };
            this.btnDeleteJob.Click += delegate { this.DeleteSelectedJob?.Invoke(this, EventArgs.Empty); };
            this.btnAEJobSave.Click += delegate { this.OnAEJobSave?.Invoke(this, EventArgs.Empty); };
            this.btnAEJobCancel.Click += delegate { this.OnAEJobCancel?.Invoke(this, EventArgs.Empty); };
            this.dgvJobs.SelectionChanged += delegate { this.OnSelectJob?.Invoke(this, EventArgs.Empty); };
        }
        private void InitProp()
        {
            this.fpnlAEEmployeeForm.Visible = false;
            this.fpnlAEJobForm.Visible = false;
        }
        public bool ShowMsgBox(string msg, string title, bool isYesNo)
        {
            DialogResult res = MessageBox.Show(msg, title, isYesNo ? MessageBoxButtons.YesNo : MessageBoxButtons.OK);
            if (res == DialogResult.Yes)
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

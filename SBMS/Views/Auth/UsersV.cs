using SBMS.Presenters.UsersPres;
using System;
using System.Windows.Forms;

namespace SBMS.Views.Auth
{
    public partial class UsersV : Form, IUsersV
    {
        public UsersV()
        {
            InitializeComponent();
            SbsUsersVEvents();
            InitProp();
        }
        private static UsersV instance;
        public static UsersV GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new UsersV();
                UsersVPres.GetInstance();
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
        public bool IsAEUserFormVisable { get => this.fpnlAEUserForm.Visible; set => this.fpnlAEUserForm.Visible = value; }
        public string UserName { get => this.tbUserName.Text; set => this.tbUserName.Text = value; }
        public string UserPassword { get => this.tbUserPassword.Text; set => this.tbUserPassword.Text = value; }
        public string SearchValue { get => this.tbSearchUsers.Text; set => this.tbSearchUsers.Text = value; }
        public ComboBox CBXPermmisions => this.cbxPermissionSelects; 
        public ComboBox CBXPermmisionFilter => this.cbxPermissionFilter;
        public ComboBox CBXEmployees => this.cbxEmployeeSelects; 
        public DataGridView DGVUsers => this.dgvUsers;
        

        public event EventHandler ShowAddUserForm;
        public event EventHandler ShowEditUserForm;
        public event EventHandler DeleteSelectedUser;
        public event EventHandler OnAEUserSave;
        public event EventHandler OnAEUserCancel;
        public event EventHandler OnSelectUser;
        public event EventHandler OnVRefresh;
        public event EventHandler OnPermmisionFilterChanged;
        public event EventHandler OnSearchBClicked;

        private void SbsUsersVEvents()
        {
            this.btnAddUser.Click += delegate { this.ShowAddUserForm?.Invoke(this,EventArgs.Empty); };
            this.btnEditUser.Click += delegate { this.ShowEditUserForm?.Invoke(this, EventArgs.Empty); };
            this.btnDeleteUser.Click += delegate { this.DeleteSelectedUser?.Invoke(this, EventArgs.Empty); };
            this.btnAEUserSave.Click += delegate { this.OnAEUserSave?.Invoke(this, EventArgs.Empty); };
            this.btnAEUserCancel.Click += delegate { this.OnAEUserCancel?.Invoke(this, EventArgs.Empty); };
            this.btnSearch.Click += delegate { this.OnSearchBClicked?.Invoke(this, EventArgs.Empty); };
            this.btnVRefresh.Click += delegate { this.OnVRefresh?.Invoke(this, EventArgs.Empty); };
            this.dgvUsers.SelectionChanged += delegate { this.OnSelectUser?.Invoke(this, EventArgs.Empty); };
            this.cbxPermissionFilter.SelectedIndexChanged += delegate { this.OnPermmisionFilterChanged?.Invoke(this, EventArgs.Empty); };
        }
        private void InitProp()
        {
            this.fpnlAEUserForm.Visible = false;
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

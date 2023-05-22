﻿namespace SBMS.Views.Auth
{
    partial class UsersV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlCategory = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxPermissionSelects = new System.Windows.Forms.ComboBox();
            this.pnlPU = new System.Windows.Forms.Panel();
            this.cbxEmployeeSelects = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearchUsers = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblValidateMsg = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnVRefresh = new System.Windows.Forms.Button();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.btnShowUsersView = new System.Windows.Forms.Button();
            this.pnlName = new System.Windows.Forms.Panel();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlINC = new System.Windows.Forms.Panel();
            this.tbUserPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fpnlSaveCancelBtns = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAEUserCancel = new System.Windows.Forms.Button();
            this.btnAEUserSave = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbUsersControl = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPermissionFilter = new System.Windows.Forms.ComboBox();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.pnlUsersVBody = new System.Windows.Forms.Panel();
            this.pnlUsersView = new System.Windows.Forms.Panel();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.fpnlAEUserForm = new System.Windows.Forms.FlowLayoutPanel();
            this.fpnlUserControl = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeaderControls = new System.Windows.Forms.Panel();
            this.pnlCategory.SuspendLayout();
            this.pnlPU.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlName.SuspendLayout();
            this.pnlINC.SuspendLayout();
            this.fpnlSaveCancelBtns.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.gbUsersControl.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlUsersVBody.SuspendLayout();
            this.pnlUsersView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.fpnlAEUserForm.SuspendLayout();
            this.fpnlUserControl.SuspendLayout();
            this.pnlHeaderControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCategory
            // 
            this.pnlCategory.Controls.Add(this.label1);
            this.pnlCategory.Controls.Add(this.cbxPermissionSelects);
            this.pnlCategory.Location = new System.Drawing.Point(3, 155);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Size = new System.Drawing.Size(171, 70);
            this.pnlCategory.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Permission :";
            // 
            // cbxPermissionSelects
            // 
            this.cbxPermissionSelects.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxPermissionSelects.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxPermissionSelects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPermissionSelects.FormattingEnabled = true;
            this.cbxPermissionSelects.Location = new System.Drawing.Point(9, 34);
            this.cbxPermissionSelects.Name = "cbxPermissionSelects";
            this.cbxPermissionSelects.Size = new System.Drawing.Size(151, 24);
            this.cbxPermissionSelects.TabIndex = 2;
            // 
            // pnlPU
            // 
            this.pnlPU.Controls.Add(this.cbxEmployeeSelects);
            this.pnlPU.Controls.Add(this.label5);
            this.pnlPU.Location = new System.Drawing.Point(3, 231);
            this.pnlPU.Name = "pnlPU";
            this.pnlPU.Size = new System.Drawing.Size(171, 70);
            this.pnlPU.TabIndex = 5;
            // 
            // cbxEmployeeSelects
            // 
            this.cbxEmployeeSelects.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxEmployeeSelects.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxEmployeeSelects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEmployeeSelects.FormattingEnabled = true;
            this.cbxEmployeeSelects.Location = new System.Drawing.Point(9, 34);
            this.cbxEmployeeSelects.Name = "cbxEmployeeSelects";
            this.cbxEmployeeSelects.Size = new System.Drawing.Size(151, 24);
            this.cbxEmployeeSelects.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Employee :";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Green;
            this.btnSearch.Location = new System.Drawing.Point(66, 79);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // tbSearchUsers
            // 
            this.tbSearchUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchUsers.Location = new System.Drawing.Point(9, 53);
            this.tbSearchUsers.Name = "tbSearchUsers";
            this.tbSearchUsers.Size = new System.Drawing.Size(144, 22);
            this.tbSearchUsers.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblValidateMsg);
            this.panel4.Location = new System.Drawing.Point(3, 307);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(171, 56);
            this.panel4.TabIndex = 10;
            // 
            // lblValidateMsg
            // 
            this.lblValidateMsg.AutoSize = true;
            this.lblValidateMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidateMsg.ForeColor = System.Drawing.Color.White;
            this.lblValidateMsg.Location = new System.Drawing.Point(6, 10);
            this.lblValidateMsg.Name = "lblValidateMsg";
            this.lblValidateMsg.Size = new System.Drawing.Size(0, 16);
            this.lblValidateMsg.TabIndex = 0;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnVRefresh);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.tbSearchUsers);
            this.pnlSearch.Controls.Add(this.label2);
            this.pnlSearch.Location = new System.Drawing.Point(3, 3);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(165, 107);
            this.pnlSearch.TabIndex = 2;
            // 
            // btnVRefresh
            // 
            this.btnVRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVRefresh.ForeColor = System.Drawing.Color.Green;
            this.btnVRefresh.Location = new System.Drawing.Point(74, 3);
            this.btnVRefresh.Name = "btnVRefresh";
            this.btnVRefresh.Size = new System.Drawing.Size(87, 23);
            this.btnVRefresh.TabIndex = 8;
            this.btnVRefresh.Text = "Refresh";
            this.btnVRefresh.UseVisualStyleBackColor = true;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(666, 6);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(49, 16);
            this.lblHeaderTitle.TabIndex = 11;
            this.lblHeaderTitle.Text = "Users";
            // 
            // btnShowUsersView
            // 
            this.btnShowUsersView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowUsersView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowUsersView.ForeColor = System.Drawing.Color.Green;
            this.btnShowUsersView.Location = new System.Drawing.Point(0, 0);
            this.btnShowUsersView.Name = "btnShowUsersView";
            this.btnShowUsersView.Size = new System.Drawing.Size(131, 29);
            this.btnShowUsersView.TabIndex = 8;
            this.btnShowUsersView.Text = "Users";
            this.btnShowUsersView.UseVisualStyleBackColor = true;
            this.btnShowUsersView.Visible = false;
            // 
            // pnlName
            // 
            this.pnlName.Controls.Add(this.tbUserName);
            this.pnlName.Controls.Add(this.label10);
            this.pnlName.Location = new System.Drawing.Point(3, 3);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(171, 70);
            this.pnlName.TabIndex = 9;
            // 
            // tbUserName
            // 
            this.tbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserName.Location = new System.Drawing.Point(9, 34);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(151, 22);
            this.tbUserName.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(6, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "User Name :";
            // 
            // pnlINC
            // 
            this.pnlINC.Controls.Add(this.tbUserPassword);
            this.pnlINC.Controls.Add(this.label7);
            this.pnlINC.Location = new System.Drawing.Point(3, 79);
            this.pnlINC.Name = "pnlINC";
            this.pnlINC.Size = new System.Drawing.Size(171, 70);
            this.pnlINC.TabIndex = 8;
            // 
            // tbUserPassword
            // 
            this.tbUserPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserPassword.Location = new System.Drawing.Point(9, 34);
            this.tbUserPassword.Name = "tbUserPassword";
            this.tbUserPassword.Size = new System.Drawing.Size(151, 22);
            this.tbUserPassword.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(6, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "User Password:";
            // 
            // fpnlSaveCancelBtns
            // 
            this.fpnlSaveCancelBtns.Controls.Add(this.btnAEUserCancel);
            this.fpnlSaveCancelBtns.Controls.Add(this.btnAEUserSave);
            this.fpnlSaveCancelBtns.Location = new System.Drawing.Point(3, 369);
            this.fpnlSaveCancelBtns.Name = "fpnlSaveCancelBtns";
            this.fpnlSaveCancelBtns.Size = new System.Drawing.Size(169, 28);
            this.fpnlSaveCancelBtns.TabIndex = 6;
            // 
            // btnAEUserCancel
            // 
            this.btnAEUserCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAEUserCancel.ForeColor = System.Drawing.Color.Maroon;
            this.btnAEUserCancel.Location = new System.Drawing.Point(3, 3);
            this.btnAEUserCancel.Name = "btnAEUserCancel";
            this.btnAEUserCancel.Size = new System.Drawing.Size(70, 23);
            this.btnAEUserCancel.TabIndex = 9;
            this.btnAEUserCancel.Text = "Cancel";
            this.btnAEUserCancel.UseVisualStyleBackColor = true;
            // 
            // btnAEUserSave
            // 
            this.btnAEUserSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAEUserSave.ForeColor = System.Drawing.Color.Green;
            this.btnAEUserSave.Location = new System.Drawing.Point(79, 3);
            this.btnAEUserSave.Name = "btnAEUserSave";
            this.btnAEUserSave.Size = new System.Drawing.Size(80, 23);
            this.btnAEUserSave.TabIndex = 10;
            this.btnAEUserSave.Text = "Save";
            this.btnAEUserSave.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.Green;
            this.btnAddUser.Location = new System.Drawing.Point(3, 3);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(165, 23);
            this.btnAddUser.TabIndex = 7;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            // 
            // btnEditUser
            // 
            this.btnEditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditUser.ForeColor = System.Drawing.Color.Green;
            this.btnEditUser.Location = new System.Drawing.Point(3, 32);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(165, 23);
            this.btnEditUser.TabIndex = 8;
            this.btnEditUser.Text = "Edit User";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Visible = false;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.ForeColor = System.Drawing.Color.Green;
            this.btnDeleteUser.Location = new System.Drawing.Point(3, 61);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(165, 23);
            this.btnDeleteUser.TabIndex = 9;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnAddUser);
            this.flowLayoutPanel2.Controls.Add(this.btnEditUser);
            this.flowLayoutPanel2.Controls.Add(this.btnDeleteUser);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(159, 92);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // gbUsersControl
            // 
            this.gbUsersControl.Controls.Add(this.flowLayoutPanel2);
            this.gbUsersControl.ForeColor = System.Drawing.Color.Crimson;
            this.gbUsersControl.Location = new System.Drawing.Point(3, 202);
            this.gbUsersControl.Name = "gbUsersControl";
            this.gbUsersControl.Size = new System.Drawing.Size(165, 111);
            this.gbUsersControl.TabIndex = 8;
            this.gbUsersControl.TabStop = false;
            this.gbUsersControl.Text = "Users";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Filter By Permission :";
            // 
            // cbxPermissionFilter
            // 
            this.cbxPermissionFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPermissionFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxPermissionFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxPermissionFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPermissionFilter.FormattingEnabled = true;
            this.cbxPermissionFilter.Location = new System.Drawing.Point(6, 42);
            this.cbxPermissionFilter.Name = "cbxPermissionFilter";
            this.cbxPermissionFilter.Size = new System.Drawing.Size(147, 24);
            this.cbxPermissionFilter.TabIndex = 1;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.cbxPermissionFilter);
            this.pnlFilter.Location = new System.Drawing.Point(3, 116);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(165, 80);
            this.pnlFilter.TabIndex = 9;
            // 
            // pnlUsersVBody
            // 
            this.pnlUsersVBody.Controls.Add(this.pnlUsersView);
            this.pnlUsersVBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUsersVBody.Location = new System.Drawing.Point(0, 29);
            this.pnlUsersVBody.Name = "pnlUsersVBody";
            this.pnlUsersVBody.Size = new System.Drawing.Size(855, 527);
            this.pnlUsersVBody.TabIndex = 5;
            // 
            // pnlUsersView
            // 
            this.pnlUsersView.Controls.Add(this.dgvUsers);
            this.pnlUsersView.Controls.Add(this.fpnlAEUserForm);
            this.pnlUsersView.Controls.Add(this.fpnlUserControl);
            this.pnlUsersView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUsersView.Location = new System.Drawing.Point(0, 0);
            this.pnlUsersView.Name = "pnlUsersView";
            this.pnlUsersView.Size = new System.Drawing.Size(855, 527);
            this.pnlUsersView.TabIndex = 0;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(170, 0);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(507, 527);
            this.dgvUsers.TabIndex = 11;
            // 
            // fpnlAEUserForm
            // 
            this.fpnlAEUserForm.Controls.Add(this.pnlName);
            this.fpnlAEUserForm.Controls.Add(this.pnlINC);
            this.fpnlAEUserForm.Controls.Add(this.pnlCategory);
            this.fpnlAEUserForm.Controls.Add(this.pnlPU);
            this.fpnlAEUserForm.Controls.Add(this.panel4);
            this.fpnlAEUserForm.Controls.Add(this.fpnlSaveCancelBtns);
            this.fpnlAEUserForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.fpnlAEUserForm.Location = new System.Drawing.Point(677, 0);
            this.fpnlAEUserForm.Name = "fpnlAEUserForm";
            this.fpnlAEUserForm.Size = new System.Drawing.Size(178, 527);
            this.fpnlAEUserForm.TabIndex = 5;
            // 
            // fpnlUserControl
            // 
            this.fpnlUserControl.Controls.Add(this.pnlSearch);
            this.fpnlUserControl.Controls.Add(this.pnlFilter);
            this.fpnlUserControl.Controls.Add(this.gbUsersControl);
            this.fpnlUserControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.fpnlUserControl.Location = new System.Drawing.Point(0, 0);
            this.fpnlUserControl.Name = "fpnlUserControl";
            this.fpnlUserControl.Size = new System.Drawing.Size(170, 527);
            this.fpnlUserControl.TabIndex = 2;
            // 
            // pnlHeaderControls
            // 
            this.pnlHeaderControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlHeaderControls.Controls.Add(this.lblHeaderTitle);
            this.pnlHeaderControls.Controls.Add(this.btnShowUsersView);
            this.pnlHeaderControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderControls.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderControls.Name = "pnlHeaderControls";
            this.pnlHeaderControls.Size = new System.Drawing.Size(855, 29);
            this.pnlHeaderControls.TabIndex = 6;
            // 
            // UsersV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(855, 556);
            this.Controls.Add(this.pnlUsersVBody);
            this.Controls.Add(this.pnlHeaderControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UsersV";
            this.Text = "Users ";
            this.pnlCategory.ResumeLayout(false);
            this.pnlCategory.PerformLayout();
            this.pnlPU.ResumeLayout(false);
            this.pnlPU.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.pnlINC.ResumeLayout(false);
            this.pnlINC.PerformLayout();
            this.fpnlSaveCancelBtns.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.gbUsersControl.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlUsersVBody.ResumeLayout(false);
            this.pnlUsersView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.fpnlAEUserForm.ResumeLayout(false);
            this.fpnlUserControl.ResumeLayout(false);
            this.pnlHeaderControls.ResumeLayout(false);
            this.pnlHeaderControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxPermissionSelects;
        private System.Windows.Forms.Panel pnlPU;
        private System.Windows.Forms.ComboBox cbxEmployeeSelects;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearchUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblValidateMsg;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnVRefresh;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button btnShowUsersView;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlINC;
        private System.Windows.Forms.TextBox tbUserPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel fpnlSaveCancelBtns;
        private System.Windows.Forms.Button btnAEUserCancel;
        private System.Windows.Forms.Button btnAEUserSave;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox gbUsersControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxPermissionFilter;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlUsersVBody;
        private System.Windows.Forms.Panel pnlUsersView;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.FlowLayoutPanel fpnlAEUserForm;
        private System.Windows.Forms.FlowLayoutPanel fpnlUserControl;
        private System.Windows.Forms.Panel pnlHeaderControls;
    }
}
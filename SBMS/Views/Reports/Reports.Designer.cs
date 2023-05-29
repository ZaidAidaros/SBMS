namespace SBMS.Views.Reports
{
    partial class ReportsHV
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
            this.pnlReportHeader = new System.Windows.Forms.Panel();
            this.pnlInvReportControl = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbInvTotal = new System.Windows.Forms.TextBox();
            this.btnReportReLoad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInvName = new System.Windows.Forms.TextBox();
            this.gbxDates = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.pnlUsersReportControl = new System.Windows.Forms.Panel();
            this.pnlEmployeesReportControl = new System.Windows.Forms.Panel();
            this.pnlProductsReportControl = new System.Windows.Forms.Panel();
            this.pnlReportHeadControls = new System.Windows.Forms.Panel();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnShowUsersReportView = new System.Windows.Forms.Button();
            this.btnShowEmployeesReportView = new System.Windows.Forms.Button();
            this.btnShowProductsReportView = new System.Windows.Forms.Button();
            this.btnShowPurchasesReportView = new System.Windows.Forms.Button();
            this.btnShowSalesReportView = new System.Windows.Forms.Button();
            this.pnlReportViewer = new System.Windows.Forms.Panel();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlReportHeader.SuspendLayout();
            this.pnlInvReportControl.SuspendLayout();
            this.gbxDates.SuspendLayout();
            this.pnlReportHeadControls.SuspendLayout();
            this.pnlReportViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReportHeader
            // 
            this.pnlReportHeader.Controls.Add(this.pnlInvReportControl);
            this.pnlReportHeader.Controls.Add(this.pnlUsersReportControl);
            this.pnlReportHeader.Controls.Add(this.pnlEmployeesReportControl);
            this.pnlReportHeader.Controls.Add(this.pnlProductsReportControl);
            this.pnlReportHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportHeader.Location = new System.Drawing.Point(0, 29);
            this.pnlReportHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlReportHeader.Name = "pnlReportHeader";
            this.pnlReportHeader.Size = new System.Drawing.Size(977, 100);
            this.pnlReportHeader.TabIndex = 0;
            // 
            // pnlInvReportControl
            // 
            this.pnlInvReportControl.Controls.Add(this.label4);
            this.pnlInvReportControl.Controls.Add(this.tbInvTotal);
            this.pnlInvReportControl.Controls.Add(this.btnReportReLoad);
            this.pnlInvReportControl.Controls.Add(this.label3);
            this.pnlInvReportControl.Controls.Add(this.tbInvName);
            this.pnlInvReportControl.Controls.Add(this.gbxDates);
            this.pnlInvReportControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInvReportControl.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlInvReportControl.Location = new System.Drawing.Point(0, 0);
            this.pnlInvReportControl.Margin = new System.Windows.Forms.Padding(2);
            this.pnlInvReportControl.Name = "pnlInvReportControl";
            this.pnlInvReportControl.Size = new System.Drawing.Size(977, 100);
            this.pnlInvReportControl.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(290, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Invoice Total :";
            // 
            // tbInvTotal
            // 
            this.tbInvTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInvTotal.Location = new System.Drawing.Point(420, 55);
            this.tbInvTotal.Margin = new System.Windows.Forms.Padding(2);
            this.tbInvTotal.Name = "tbInvTotal";
            this.tbInvTotal.Size = new System.Drawing.Size(134, 23);
            this.tbInvTotal.TabIndex = 4;
            // 
            // btnReportReLoad
            // 
            this.btnReportReLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportReLoad.ForeColor = System.Drawing.Color.Green;
            this.btnReportReLoad.Location = new System.Drawing.Point(856, 66);
            this.btnReportReLoad.Name = "btnReportReLoad";
            this.btnReportReLoad.Size = new System.Drawing.Size(116, 29);
            this.btnReportReLoad.TabIndex = 11;
            this.btnReportReLoad.Text = "ReLoad Report";
            this.btnReportReLoad.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(290, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name On Invoice:";
            // 
            // tbInvName
            // 
            this.tbInvName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInvName.Location = new System.Drawing.Point(420, 19);
            this.tbInvName.Margin = new System.Windows.Forms.Padding(2);
            this.tbInvName.Name = "tbInvName";
            this.tbInvName.Size = new System.Drawing.Size(134, 23);
            this.tbInvName.TabIndex = 2;
            // 
            // gbxDates
            // 
            this.gbxDates.BackColor = System.Drawing.Color.Black;
            this.gbxDates.Controls.Add(this.label2);
            this.gbxDates.Controls.Add(this.label1);
            this.gbxDates.Controls.Add(this.dtpToDate);
            this.gbxDates.Controls.Add(this.dtpFromDate);
            this.gbxDates.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbxDates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxDates.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDates.ForeColor = System.Drawing.Color.White;
            this.gbxDates.Location = new System.Drawing.Point(0, 0);
            this.gbxDates.Margin = new System.Windows.Forms.Padding(2);
            this.gbxDates.Name = "gbxDates";
            this.gbxDates.Padding = new System.Windows.Forms.Padding(2);
            this.gbxDates.Size = new System.Drawing.Size(281, 100);
            this.gbxDates.TabIndex = 1;
            this.gbxDates.TabStop = false;
            this.gbxDates.Text = "Date Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "To :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "From :";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(89, 60);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(185, 23);
            this.dtpToDate.TabIndex = 1;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(89, 21);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(185, 23);
            this.dtpFromDate.TabIndex = 0;
            // 
            // pnlUsersReportControl
            // 
            this.pnlUsersReportControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUsersReportControl.Location = new System.Drawing.Point(0, 0);
            this.pnlUsersReportControl.Margin = new System.Windows.Forms.Padding(2);
            this.pnlUsersReportControl.Name = "pnlUsersReportControl";
            this.pnlUsersReportControl.Size = new System.Drawing.Size(977, 100);
            this.pnlUsersReportControl.TabIndex = 1;
            // 
            // pnlEmployeesReportControl
            // 
            this.pnlEmployeesReportControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEmployeesReportControl.Location = new System.Drawing.Point(0, 0);
            this.pnlEmployeesReportControl.Margin = new System.Windows.Forms.Padding(2);
            this.pnlEmployeesReportControl.Name = "pnlEmployeesReportControl";
            this.pnlEmployeesReportControl.Size = new System.Drawing.Size(977, 100);
            this.pnlEmployeesReportControl.TabIndex = 2;
            // 
            // pnlProductsReportControl
            // 
            this.pnlProductsReportControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProductsReportControl.Location = new System.Drawing.Point(0, 0);
            this.pnlProductsReportControl.Margin = new System.Windows.Forms.Padding(2);
            this.pnlProductsReportControl.Name = "pnlProductsReportControl";
            this.pnlProductsReportControl.Size = new System.Drawing.Size(977, 100);
            this.pnlProductsReportControl.TabIndex = 1;
            // 
            // pnlReportHeadControls
            // 
            this.pnlReportHeadControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlReportHeadControls.Controls.Add(this.btnSuppliers);
            this.pnlReportHeadControls.Controls.Add(this.btnCustomers);
            this.pnlReportHeadControls.Controls.Add(this.btnShowUsersReportView);
            this.pnlReportHeadControls.Controls.Add(this.btnShowEmployeesReportView);
            this.pnlReportHeadControls.Controls.Add(this.btnShowProductsReportView);
            this.pnlReportHeadControls.Controls.Add(this.btnShowPurchasesReportView);
            this.pnlReportHeadControls.Controls.Add(this.btnShowSalesReportView);
            this.pnlReportHeadControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportHeadControls.Location = new System.Drawing.Point(0, 0);
            this.pnlReportHeadControls.Name = "pnlReportHeadControls";
            this.pnlReportHeadControls.Size = new System.Drawing.Size(977, 29);
            this.pnlReportHeadControls.TabIndex = 3;
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuppliers.ForeColor = System.Drawing.Color.Green;
            this.btnSuppliers.Location = new System.Drawing.Point(786, 0);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(131, 29);
            this.btnSuppliers.TabIndex = 15;
            this.btnSuppliers.Text = "Suppliers Report";
            this.btnSuppliers.UseVisualStyleBackColor = true;
            // 
            // btnCustomers
            // 
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.ForeColor = System.Drawing.Color.Green;
            this.btnCustomers.Location = new System.Drawing.Point(655, 0);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(131, 29);
            this.btnCustomers.TabIndex = 14;
            this.btnCustomers.Text = "Customers Report";
            this.btnCustomers.UseVisualStyleBackColor = true;
            // 
            // btnShowUsersReportView
            // 
            this.btnShowUsersReportView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowUsersReportView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowUsersReportView.ForeColor = System.Drawing.Color.Green;
            this.btnShowUsersReportView.Location = new System.Drawing.Point(524, 0);
            this.btnShowUsersReportView.Name = "btnShowUsersReportView";
            this.btnShowUsersReportView.Size = new System.Drawing.Size(131, 29);
            this.btnShowUsersReportView.TabIndex = 10;
            this.btnShowUsersReportView.Text = "Users Report";
            this.btnShowUsersReportView.UseVisualStyleBackColor = true;
            // 
            // btnShowEmployeesReportView
            // 
            this.btnShowEmployeesReportView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowEmployeesReportView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowEmployeesReportView.ForeColor = System.Drawing.Color.Green;
            this.btnShowEmployeesReportView.Location = new System.Drawing.Point(393, 0);
            this.btnShowEmployeesReportView.Name = "btnShowEmployeesReportView";
            this.btnShowEmployeesReportView.Size = new System.Drawing.Size(131, 29);
            this.btnShowEmployeesReportView.TabIndex = 9;
            this.btnShowEmployeesReportView.Text = "Employees Report";
            this.btnShowEmployeesReportView.UseVisualStyleBackColor = true;
            // 
            // btnShowProductsReportView
            // 
            this.btnShowProductsReportView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowProductsReportView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowProductsReportView.ForeColor = System.Drawing.Color.Green;
            this.btnShowProductsReportView.Location = new System.Drawing.Point(262, 0);
            this.btnShowProductsReportView.Name = "btnShowProductsReportView";
            this.btnShowProductsReportView.Size = new System.Drawing.Size(131, 29);
            this.btnShowProductsReportView.TabIndex = 8;
            this.btnShowProductsReportView.Text = "Products Report";
            this.btnShowProductsReportView.UseVisualStyleBackColor = true;
            // 
            // btnShowPurchasesReportView
            // 
            this.btnShowPurchasesReportView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowPurchasesReportView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowPurchasesReportView.ForeColor = System.Drawing.Color.Green;
            this.btnShowPurchasesReportView.Location = new System.Drawing.Point(131, 0);
            this.btnShowPurchasesReportView.Name = "btnShowPurchasesReportView";
            this.btnShowPurchasesReportView.Size = new System.Drawing.Size(131, 29);
            this.btnShowPurchasesReportView.TabIndex = 13;
            this.btnShowPurchasesReportView.Text = "Purchases Report";
            this.btnShowPurchasesReportView.UseVisualStyleBackColor = true;
            // 
            // btnShowSalesReportView
            // 
            this.btnShowSalesReportView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowSalesReportView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowSalesReportView.ForeColor = System.Drawing.Color.Green;
            this.btnShowSalesReportView.Location = new System.Drawing.Point(0, 0);
            this.btnShowSalesReportView.Name = "btnShowSalesReportView";
            this.btnShowSalesReportView.Size = new System.Drawing.Size(131, 29);
            this.btnShowSalesReportView.TabIndex = 12;
            this.btnShowSalesReportView.Text = "Sales Report";
            this.btnShowSalesReportView.UseVisualStyleBackColor = true;
            // 
            // pnlReportViewer
            // 
            this.pnlReportViewer.Controls.Add(this.reportViewer);
            this.pnlReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReportViewer.Location = new System.Drawing.Point(0, 129);
            this.pnlReportViewer.Margin = new System.Windows.Forms.Padding(2);
            this.pnlReportViewer.Name = "pnlReportViewer";
            this.pnlReportViewer.Size = new System.Drawing.Size(977, 410);
            this.pnlReportViewer.TabIndex = 1;
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(977, 410);
            this.reportViewer.TabIndex = 0;
            // 
            // ReportsHV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(977, 539);
            this.Controls.Add(this.pnlReportViewer);
            this.Controls.Add(this.pnlReportHeader);
            this.Controls.Add(this.pnlReportHeadControls);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReportsHV";
            this.ShowIcon = false;
            this.Text = "Reports";
            this.pnlReportHeader.ResumeLayout(false);
            this.pnlInvReportControl.ResumeLayout(false);
            this.pnlInvReportControl.PerformLayout();
            this.gbxDates.ResumeLayout(false);
            this.gbxDates.PerformLayout();
            this.pnlReportHeadControls.ResumeLayout(false);
            this.pnlReportViewer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReportHeader;
        private System.Windows.Forms.Panel pnlReportViewer;
        private System.Windows.Forms.Panel pnlReportHeadControls;
        private System.Windows.Forms.Button btnShowUsersReportView;
        private System.Windows.Forms.Button btnShowEmployeesReportView;
        private System.Windows.Forms.Button btnShowProductsReportView;
        private System.Windows.Forms.Button btnShowPurchasesReportView;
        private System.Windows.Forms.Button btnShowSalesReportView;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Panel pnlUsersReportControl;
        private System.Windows.Forms.Panel pnlEmployeesReportControl;
        private System.Windows.Forms.Panel pnlProductsReportControl;
        private System.Windows.Forms.Panel pnlInvReportControl;
        private System.Windows.Forms.GroupBox gbxDates;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbInvName;
        private System.Windows.Forms.Button btnReportReLoad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbInvTotal;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnCustomers;
    }
}
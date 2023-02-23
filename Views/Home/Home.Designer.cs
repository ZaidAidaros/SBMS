namespace SBMS.Views.Screens
{
    partial class Home
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
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.topBarMinueButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.topBarUserNameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.topBarDateLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.topBarTitleLabel = new System.Windows.Forms.Label();
            this.butHClose = new System.Windows.Forms.Button();
            this.homeMinueSidePanelFL = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonAccounts = new System.Windows.Forms.Button();
            this.buttonStores = new System.Windows.Forms.Button();
            this.buttonEmployees = new System.Windows.Forms.Button();
            this.buttonSuppliers = new System.Windows.Forms.Button();
            this.buttonCustomers = new System.Windows.Forms.Button();
            this.buttonPurchases = new System.Windows.Forms.Button();
            this.buttonSalese = new System.Windows.Forms.Button();
            this.buttonReports = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.panelTopBar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.homeMinueSidePanelFL.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelTopBar.Controls.Add(this.topBarMinueButton);
            this.panelTopBar.Controls.Add(this.panel2);
            this.panelTopBar.Controls.Add(this.panel1);
            this.panelTopBar.Controls.Add(this.topBarTitleLabel);
            this.panelTopBar.Controls.Add(this.butHClose);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Margin = new System.Windows.Forms.Padding(1);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Padding = new System.Windows.Forms.Padding(5);
            this.panelTopBar.Size = new System.Drawing.Size(989, 42);
            this.panelTopBar.TabIndex = 0;
            // 
            // topBarMinueButton
            // 
            this.topBarMinueButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.topBarMinueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.topBarMinueButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.topBarMinueButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.topBarMinueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.topBarMinueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topBarMinueButton.Location = new System.Drawing.Point(937, 6);
            this.topBarMinueButton.Margin = new System.Windows.Forms.Padding(5);
            this.topBarMinueButton.Name = "topBarMinueButton";
            this.topBarMinueButton.Size = new System.Drawing.Size(38, 30);
            this.topBarMinueButton.TabIndex = 1;
            this.topBarMinueButton.UseVisualStyleBackColor = false;
            this.topBarMinueButton.Click += new System.EventHandler(this.buttonTopBarMinue_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel2.Controls.Add(this.topBarUserNameLabel);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(249, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(247, 26);
            this.panel2.TabIndex = 1;
            // 
            // topBarUserNameLabel
            // 
            this.topBarUserNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.topBarUserNameLabel.AutoSize = true;
            this.topBarUserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.topBarUserNameLabel.Location = new System.Drawing.Point(60, 3);
            this.topBarUserNameLabel.Name = "topBarUserNameLabel";
            this.topBarUserNameLabel.Size = new System.Drawing.Size(71, 20);
            this.topBarUserNameLabel.TabIndex = 1;
            this.topBarUserNameLabel.Text = "علي صالح";
            this.topBarUserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(137, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "المستخدم الحالي:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.Controls.Add(this.topBarDateLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(76, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(167, 26);
            this.panel1.TabIndex = 1;
            // 
            // topBarDateLabel
            // 
            this.topBarDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topBarDateLabel.AutoSize = true;
            this.topBarDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.topBarDateLabel.Location = new System.Drawing.Point(2, 3);
            this.topBarDateLabel.Name = "topBarDateLabel";
            this.topBarDateLabel.Size = new System.Drawing.Size(89, 20);
            this.topBarDateLabel.TabIndex = 1;
            this.topBarDateLabel.Text = "2022/2/22";
            this.topBarDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(97, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "التاريخ:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // topBarTitleLabel
            // 
            this.topBarTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.topBarTitleLabel.AutoSize = true;
            this.topBarTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.topBarTitleLabel.Location = new System.Drawing.Point(866, 9);
            this.topBarTitleLabel.Name = "topBarTitleLabel";
            this.topBarTitleLabel.Size = new System.Drawing.Size(67, 24);
            this.topBarTitleLabel.TabIndex = 1;
            this.topBarTitleLabel.Text = "الرئيسية";
            // 
            // butHClose
            // 
            this.butHClose.BackColor = System.Drawing.Color.DarkRed;
            this.butHClose.Dock = System.Windows.Forms.DockStyle.Left;
            this.butHClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.butHClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.butHClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butHClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHClose.Location = new System.Drawing.Point(5, 5);
            this.butHClose.Margin = new System.Windows.Forms.Padding(5);
            this.butHClose.Name = "butHClose";
            this.butHClose.Size = new System.Drawing.Size(38, 32);
            this.butHClose.TabIndex = 0;
            this.butHClose.Text = "X";
            this.butHClose.UseVisualStyleBackColor = false;
            this.butHClose.Click += new System.EventHandler(this.butHClose_Click);
            // 
            // homeMinueSidePanelFL
            // 
            this.homeMinueSidePanelFL.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.homeMinueSidePanelFL.Controls.Add(this.buttonHome);
            this.homeMinueSidePanelFL.Controls.Add(this.buttonAccounts);
            this.homeMinueSidePanelFL.Controls.Add(this.buttonStores);
            this.homeMinueSidePanelFL.Controls.Add(this.buttonEmployees);
            this.homeMinueSidePanelFL.Controls.Add(this.buttonSuppliers);
            this.homeMinueSidePanelFL.Controls.Add(this.buttonCustomers);
            this.homeMinueSidePanelFL.Controls.Add(this.buttonPurchases);
            this.homeMinueSidePanelFL.Controls.Add(this.buttonSalese);
            this.homeMinueSidePanelFL.Controls.Add(this.buttonReports);
            this.homeMinueSidePanelFL.Controls.Add(this.buttonSettings);
            this.homeMinueSidePanelFL.Dock = System.Windows.Forms.DockStyle.Right;
            this.homeMinueSidePanelFL.Location = new System.Drawing.Point(855, 42);
            this.homeMinueSidePanelFL.Name = "homeMinueSidePanelFL";
            this.homeMinueSidePanelFL.Padding = new System.Windows.Forms.Padding(2);
            this.homeMinueSidePanelFL.Size = new System.Drawing.Size(134, 519);
            this.homeMinueSidePanelFL.TabIndex = 1;
            this.homeMinueSidePanelFL.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // buttonHome
            // 
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.Location = new System.Drawing.Point(8, 5);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(119, 40);
            this.buttonHome.TabIndex = 2;
            this.buttonHome.Text = "الرئيسية";
            this.buttonHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHome.UseVisualStyleBackColor = true;
            // 
            // buttonAccounts
            // 
            this.buttonAccounts.FlatAppearance.BorderSize = 0;
            this.buttonAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAccounts.Location = new System.Drawing.Point(8, 51);
            this.buttonAccounts.Name = "buttonAccounts";
            this.buttonAccounts.Size = new System.Drawing.Size(119, 40);
            this.buttonAccounts.TabIndex = 2;
            this.buttonAccounts.Text = "الحسابات";
            this.buttonAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAccounts.UseVisualStyleBackColor = true;
            // 
            // buttonStores
            // 
            this.buttonStores.FlatAppearance.BorderSize = 0;
            this.buttonStores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStores.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStores.Location = new System.Drawing.Point(8, 97);
            this.buttonStores.Name = "buttonStores";
            this.buttonStores.Size = new System.Drawing.Size(119, 40);
            this.buttonStores.TabIndex = 2;
            this.buttonStores.Text = " الماخزن";
            this.buttonStores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonStores.UseVisualStyleBackColor = true;
            // 
            // buttonEmployees
            // 
            this.buttonEmployees.FlatAppearance.BorderSize = 0;
            this.buttonEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEmployees.Location = new System.Drawing.Point(8, 143);
            this.buttonEmployees.Name = "buttonEmployees";
            this.buttonEmployees.Size = new System.Drawing.Size(119, 40);
            this.buttonEmployees.TabIndex = 2;
            this.buttonEmployees.Text = " الموظفين";
            this.buttonEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEmployees.UseVisualStyleBackColor = true;
            // 
            // buttonSuppliers
            // 
            this.buttonSuppliers.FlatAppearance.BorderSize = 0;
            this.buttonSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSuppliers.Location = new System.Drawing.Point(8, 189);
            this.buttonSuppliers.Name = "buttonSuppliers";
            this.buttonSuppliers.Size = new System.Drawing.Size(119, 40);
            this.buttonSuppliers.TabIndex = 2;
            this.buttonSuppliers.Text = "الموردين";
            this.buttonSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSuppliers.UseVisualStyleBackColor = true;
            // 
            // buttonCustomers
            // 
            this.buttonCustomers.FlatAppearance.BorderSize = 0;
            this.buttonCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustomers.Location = new System.Drawing.Point(8, 235);
            this.buttonCustomers.Name = "buttonCustomers";
            this.buttonCustomers.Size = new System.Drawing.Size(119, 40);
            this.buttonCustomers.TabIndex = 2;
            this.buttonCustomers.Text = "العملاء";
            this.buttonCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCustomers.UseVisualStyleBackColor = true;
            // 
            // buttonPurchases
            // 
            this.buttonPurchases.FlatAppearance.BorderSize = 0;
            this.buttonPurchases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPurchases.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPurchases.Location = new System.Drawing.Point(8, 281);
            this.buttonPurchases.Name = "buttonPurchases";
            this.buttonPurchases.Size = new System.Drawing.Size(119, 40);
            this.buttonPurchases.TabIndex = 2;
            this.buttonPurchases.Text = "المشتريات";
            this.buttonPurchases.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPurchases.UseVisualStyleBackColor = true;
            // 
            // buttonSalese
            // 
            this.buttonSalese.FlatAppearance.BorderSize = 0;
            this.buttonSalese.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalese.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalese.Location = new System.Drawing.Point(8, 327);
            this.buttonSalese.Name = "buttonSalese";
            this.buttonSalese.Size = new System.Drawing.Size(119, 40);
            this.buttonSalese.TabIndex = 2;
            this.buttonSalese.Text = "المبيعات";
            this.buttonSalese.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSalese.UseVisualStyleBackColor = true;
            // 
            // buttonReports
            // 
            this.buttonReports.FlatAppearance.BorderSize = 0;
            this.buttonReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReports.Location = new System.Drawing.Point(8, 373);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(119, 40);
            this.buttonReports.TabIndex = 2;
            this.buttonReports.Text = "التقارير";
            this.buttonReports.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonReports.UseVisualStyleBackColor = true;
            // 
            // buttonSettings
            // 
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSettings.Location = new System.Drawing.Point(8, 419);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(119, 40);
            this.buttonSettings.TabIndex = 2;
            this.buttonSettings.Text = "الإعدادت";
            this.buttonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSettings.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(989, 561);
            this.Controls.Add(this.homeMinueSidePanelFL);
            this.Controls.Add(this.panelTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelTopBar.ResumeLayout(false);
            this.panelTopBar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.homeMinueSidePanelFL.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Button butHClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label topBarUserNameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label topBarDateLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label topBarTitleLabel;
        private System.Windows.Forms.FlowLayoutPanel homeMinueSidePanelFL;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonAccounts;
        private System.Windows.Forms.Button buttonStores;
        private System.Windows.Forms.Button buttonEmployees;
        private System.Windows.Forms.Button buttonSuppliers;
        private System.Windows.Forms.Button buttonCustomers;
        private System.Windows.Forms.Button buttonPurchases;
        private System.Windows.Forms.Button buttonSalese;
        private System.Windows.Forms.Button buttonReports;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button topBarMinueButton;
    }
}
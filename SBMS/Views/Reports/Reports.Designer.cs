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
            this.pnlReportViewer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlReportHeader
            // 
            this.pnlReportHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlReportHeader.Name = "pnlReportHeader";
            this.pnlReportHeader.Size = new System.Drawing.Size(1410, 146);
            this.pnlReportHeader.TabIndex = 0;
            // 
            // pnlReportViewer
            // 
            this.pnlReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReportViewer.Location = new System.Drawing.Point(0, 146);
            this.pnlReportViewer.Name = "pnlReportViewer";
            this.pnlReportViewer.Size = new System.Drawing.Size(1410, 636);
            this.pnlReportViewer.TabIndex = 1;
            // 
            // ReportsHV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1410, 782);
            this.Controls.Add(this.pnlReportViewer);
            this.Controls.Add(this.pnlReportHeader);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportsHV";
            this.Text = "Reports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReportHeader;
        private System.Windows.Forms.Panel pnlReportViewer;
    }
}
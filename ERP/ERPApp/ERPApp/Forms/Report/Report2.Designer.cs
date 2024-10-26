namespace ERPApp.Forms.Report
{
    partial class Report2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report2));
            this.reportGenerator1 = new DevExpress.XtraReports.ReportGeneration.ReportGenerator(this.components);
            this.expensereport = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.stafeport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.cusreport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.firmreport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.expensereport)).BeginInit();
            this.expensereport.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // expensereport
            // 
            this.expensereport.Location = new System.Drawing.Point(12, 12);
            this.expensereport.Name = "expensereport";
            this.expensereport.SelectedTabPage = this.xtraTabPage3;
            this.expensereport.Size = new System.Drawing.Size(1900, 675);
            this.expensereport.TabIndex = 0;
            this.expensereport.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.stafeport);
            this.xtraTabPage3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage3.ImageOptions.Image")));
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(1898, 629);
            this.xtraTabPage3.Text = "STAFF REPORT";
            // 
            // stafeport
            // 
            this.stafeport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stafeport.Location = new System.Drawing.Point(0, 0);
            this.stafeport.Name = "stafeport";
            this.stafeport.ServerReport.BearerToken = null;
            this.stafeport.Size = new System.Drawing.Size(1898, 629);
            this.stafeport.TabIndex = 0;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.cusreport);
            this.xtraTabPage1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage1.ImageOptions.Image")));
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1898, 629);
            this.xtraTabPage1.Text = "CUSTOMER REPORT";
            // 
            // cusreport
            // 
            this.cusreport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cusreport.LocalReport.ReportEmbeddedResource = "ERPApp.CusReport (2).rdlc";
            this.cusreport.Location = new System.Drawing.Point(0, 0);
            this.cusreport.Name = "cusreport";
            this.cusreport.ServerReport.BearerToken = null;
            this.cusreport.ServerReport.ReportPath = "FirmReport";
            this.cusreport.ServerReport.ReportServerUrl = new System.Uri("C", System.UriKind.Relative);
            this.cusreport.Size = new System.Drawing.Size(1898, 629);
            this.cusreport.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.firmreport);
            this.xtraTabPage2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage2.ImageOptions.Image")));
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1898, 629);
            this.xtraTabPage2.Text = "FİRM REPORT";
            // 
            // firmreport
            // 
            this.firmreport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firmreport.Location = new System.Drawing.Point(0, 0);
            this.firmreport.Name = "firmreport";
            this.firmreport.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.firmreport.ServerReport.BearerToken = null;
            this.firmreport.Size = new System.Drawing.Size(1898, 629);
            this.firmreport.TabIndex = 0;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.reportViewer4);
            this.xtraTabPage4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage4.ImageOptions.Image")));
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(1898, 629);
            this.xtraTabPage4.Text = "EXPENSE REPORT";
            // 
            // reportViewer4
            // 
            this.reportViewer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer4.Location = new System.Drawing.Point(0, 0);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.ServerReport.BearerToken = null;
            this.reportViewer4.Size = new System.Drawing.Size(1898, 629);
            this.reportViewer4.TabIndex = 0;
            // 
            // Report2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 699);
            this.Controls.Add(this.expensereport);
            this.Name = "Report2";
            this.Text = "Report2";
            this.Load += new System.EventHandler(this.Report2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.expensereport)).EndInit();
            this.expensereport.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraReports.ReportGeneration.ReportGenerator reportGenerator1;
        private DevExpress.XtraTab.XtraTabControl expensereport;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private Microsoft.Reporting.WinForms.ReportViewer stafeport;
        private Microsoft.Reporting.WinForms.ReportViewer cusreport;
        private Microsoft.Reporting.WinForms.ReportViewer firmreport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer4;
    }
}
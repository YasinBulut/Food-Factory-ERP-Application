﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPApp.Forms.Report
{
    public partial class Report2 : Form
    {
        public Report2()
        {
            InitializeComponent();
        }

        private void Report2_Load(object sender, EventArgs e)
        {

            this.stafeport.RefreshReport();
            this.stafeport.RefreshReport();
            this.cusreport.RefreshReport();
            this.firmreport.RefreshReport();
            this.reportViewer4.RefreshReport();
        }
    }
}

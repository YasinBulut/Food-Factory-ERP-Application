using ERPApp.Forms.Customers;
using ERPApp.Forms.Products;
using ERPApp.Forms.Firms;
using ERPApp.Forms.Staff;
using ERPApp.Forms.Directory;
using ERPApp.Forms.Expenses;
using ERPApp.Forms.Banks;
using ERPApp.Forms.Bills;
using ERPApp.Forms.Notes;
using ERPApp.Forms.Activities;
using ERPApp.Forms.Report;
using ERPApp.Forms.Inventory;
using ERPApp.Forms.Settings;
using ERPApp.Forms.Cash;
using ERPApp.Forms.HomePage;
using ERPApp.Forms.Proect;
using ERPApp.Forms.Recipe;
using ERPApp.Forms.MAINTENANCE;
using ERPApp.Forms.WorkOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPApp
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        public Home()
        {
            InitializeComponent();
        }
        Product fr;
        private void btnproduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr ==null || fr.IsDisposed)
            {
                fr = new Product();
                fr.MdiParent = this;
                fr.Show();
            }
          
        }
        FrmCustomers fr2;
        private void btncustomers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new FrmCustomers();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        FrmFirms fr3;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new FrmFirms();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }
        Staff fr4;
        private void btnstaff_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new Staff();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }
        Directory fr5;
        private void btndirectory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new Directory();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }
        Expenses fr6;
        private void btnexpenses_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new Expenses();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }
        FrmBanks fr7;
        private void brnbanks_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new FrmBanks();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }
        FrmBills fr8;
        private void btnbilss_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new FrmBills();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }
        FrmNote fr9;
        private void btnnotes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new FrmNote();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }
        FrmAct fr10;
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null || fr10.IsDisposed)
            {
                fr10 = new FrmAct();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (fr15 == null || fr15.IsDisposed)
            {
                fr15 = new Home2();
                fr15.MdiParent = this;
                fr15.Show();
            }
        }
        Report fr11;
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new Report();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }
        Stocks fr12;
        private void btninventory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new Stocks();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }
        Settings fr13;
        private void btnsettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null || fr13.IsDisposed)
            {
                fr13 = new Settings();
                fr13.Show();
            }
        }
        Cash fr14;
        private void btncashier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new Cash();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }
        Home2 fr15;
        private void btnhome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr15 == null || fr15.IsDisposed)
            {
                fr15 = new Home2();
                fr15.MdiParent = this;
                fr15.Show();
            }
        }
        Recipe fr16;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr16 == null || fr16.IsDisposed)
            {
                fr16 = new Recipe();
                fr16.MdiParent = this;
                fr16.Show();
            }
        }
        Project fr17;
        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr17 == null || fr17.IsDisposed)
            {
                fr17 = new Project();
                fr17.MdiParent = this;
                fr17.Show();
            }
        }
        WorkOrder fr18;
        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr18 == null || fr18.IsDisposed)
            {
                fr18 = new WorkOrder();
                fr18.MdiParent = this;
                fr18.Show();
            }
        }
        Maint fr19;
        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr19 == null || fr19.IsDisposed)
            {
                fr19 = new Maint();
                fr19.MdiParent = this;
                fr19.Show();
            }
        }
    }
}

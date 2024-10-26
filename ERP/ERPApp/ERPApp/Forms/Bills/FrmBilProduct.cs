using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ERPApp.Forms.Bills
{
    public partial class FrmBilProduct : Form
    {
        public FrmBilProduct()
        {
            InitializeComponent();
        }
        public string id;
        SqlConn con = new SqlConn();
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmBilPrdUpdate fr = new FrmBilPrdUpdate();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.productid = dr["INVOICEID"].ToString();
            }
            fr.Show();
        }
        void List()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FaturaDetay where INVOICEID='" + id+"'", con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmBilProduct_Load(object sender, EventArgs e)
        {
            List();
        }
    }
}

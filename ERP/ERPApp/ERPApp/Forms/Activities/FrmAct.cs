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

namespace ERPApp.Forms.Activities
{
    public partial class FrmAct : Form
    {
        public FrmAct()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        void FirmList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec Firm_Activate",con.conn());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }
        void CustList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec Customer_Activate", con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void SS_Click(object sender, EventArgs e)
        {

        }

        private void FrmAct_Load(object sender, EventArgs e)
        {
            FirmList();
            CustList();
        }
    }
}

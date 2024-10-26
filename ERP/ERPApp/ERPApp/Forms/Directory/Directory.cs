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

namespace ERPApp.Forms.Directory
{
    public partial class Directory : Form
    {
        public Directory()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        private void Directory_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select NAME,SURNAME,PHONE,PHONE2,MAIL From TBL_Musteriler ", con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select NAME,AUTHORIZEDNAME,AUTHORIZEDDUTY,PHONE1,PHONE2,PHONE3,MAIL,FAX From TBL_Firmalar ", con.conn());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            SendMail frm = new SendMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr!=null)
            {
                frm.mail = dr["MAIL"].ToString();
            }
            frm.Show();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            SendMail frm = new SendMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.mail = dr["MAIL"].ToString();
            }
            frm.Show();
        }
    }
}

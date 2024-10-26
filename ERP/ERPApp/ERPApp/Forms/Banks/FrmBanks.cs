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

namespace ERPApp.Forms.Banks
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        void List()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  TBL_Banks.ID,BANKNAME,BRANCH,IBAN,ACCOUNTNO,AUTHORIZED,DATE,ACCOUNTTYPE,NAME from TBL_Banks inner join TBL_Firmalar on TBL_Banks.FIRMAID=TBL_Firmalar.ID", con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void clean()
        {
            txtid.Text = "";
            txtname.Text = "";
            txtbranch.Text = "";
            txtiban.Text = "";
            txtno.Text = "";
            txtauth.Text = "";
            txtdate.Text = "";
            txttype.Text = "";
            txtfirma.Text = "";
        }
        void FirmList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,NAME from Tbl_Firmalar",con.conn());
            da.Fill(dt);
            txtfirma.Properties.NullText = "<PLEASE ENTER NAME>";
            txtfirma.Properties.ValueMember = "ID";
            txtfirma.Properties.DisplayMember = "NAME";
            txtfirma.Properties.DataSource = dt;
        }
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            List();
            FirmList();  
        }

        private void btnclean_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into TBL_Banks (ID,BANKNAME,BRANCH,IBAN,ACCOUNTNO,AUTHORIZED," +
                "DATE,ACCOUNTTYPE,FIRMAID) VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtname.Text);
            cmd.Parameters.AddWithValue("@p2", txtbranch.Text);
            cmd.Parameters.AddWithValue("@p3", txtiban.Text);
            cmd.Parameters.AddWithValue("@p4", txtno.Text);
            cmd.Parameters.AddWithValue("@p5", txtauth.Text);
            cmd.Parameters.AddWithValue("@p6", txtdate.Text);
            cmd.Parameters.AddWithValue("@p7", txttype.Text);
            cmd.Parameters.AddWithValue("@p8", txtfirma.EditValue);
            cmd.Parameters.AddWithValue("@p0", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Bank has been added successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            clean();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update TBL_Banks set BANKNAME=@p1,BRANCH=@p2,IBAN=@p3," +
               "ACCOUNTNO=@p4,AUTHORIZED=@p5,DATE=@p6,ACCOUNTTYPE=@p7,FIRMAID=@p8 where ID=@p9", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtname.Text);
            cmd.Parameters.AddWithValue("@p2", txtbranch.Text);
            cmd.Parameters.AddWithValue("@p3", txtiban.Text);
            cmd.Parameters.AddWithValue("@p4", txtno.Text);
            cmd.Parameters.AddWithValue("@p5", txtauth.Text);
            cmd.Parameters.AddWithValue("@p6", txtdate.Text);
            cmd.Parameters.AddWithValue("@p7", txttype.Text);
            cmd.Parameters.AddWithValue("@p8", txtfirma.EditValue);
            cmd.Parameters.AddWithValue("@p9", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Bank has been updated successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            clean();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from TBL_Banks where ID=@p1", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Bank was successfully deleted", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            List();
            clean();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtid.Text = dr["ID"].ToString();
            txtname.Text = dr["BANKNAME"].ToString();
            txtbranch.Text = dr["BRANCH"].ToString();
            txtiban.Text = dr["IBAN"].ToString();
            txtno.Text = dr["ACCOUNTNO"].ToString();
            txtauth.Text = dr["AUTHORIZED"].ToString();
            txtdate.Text = dr["DATE"].ToString();
            txttype.Text = dr["ACCOUNTTYPE"].ToString();
            txtfirma.Text = dr["NAME"].ToString();
        }
    }
}

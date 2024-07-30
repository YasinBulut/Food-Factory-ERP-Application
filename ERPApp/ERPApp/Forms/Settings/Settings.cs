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

namespace ERPApp.Forms.Settings
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        void List()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_Admin",con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        private void Settings_Load(object sender, EventArgs e)
        {
            List();
            txtuser.Text = "";
            txtpasw.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtuser.Text = dr["UserName"].ToString();
                txtpasw.Text = dr["UserPasw"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnsave.Text=="SAVE")
            {
                SqlCommand cmd = new SqlCommand("insert into TBL_Admin values (@p1,@p2)", con.conn());
                cmd.Parameters.AddWithValue("@p1", txtuser.Text);
                cmd.Parameters.AddWithValue("@p2", txtpasw.Text);
                cmd.ExecuteNonQuery();
                con.conn().Close();
                MessageBox.Show("New admin has been registered successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List();
            }
            else if (btnsave.Text=="UPDATE")
            {
                SqlCommand cmd1 = new SqlCommand("update TBL_Admin set UserPasw=@p2 where UserName=@p1", con.conn());
                cmd1.Parameters.AddWithValue("@p1", txtuser.Text);
                cmd1.Parameters.AddWithValue("@p2", txtpasw.Text);
                cmd1.ExecuteNonQuery();
                con.conn().Close();
                MessageBox.Show("Admin update has been registered successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List();
            }
          
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {
            if (txtuser.Text !="")
            {
                btnsave.Text = "UPDATE";
            }
            else
            {
                btnsave.Text = "SAVE";
            }
        }
    }
}

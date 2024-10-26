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

namespace ERPApp.Forms.Notes
{
    public partial class FrmNote : Form
    {
        public FrmNote()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        void List()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_Nots ", con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void clean()
        {
            txtid.Text = "";
            txtdate.Text = "";
            txthour.Text = "";
            txttitle.Text = "";
            txtcc.Text = "";
            txtdetail.Text = "";
        }
        private void FrmNote_Load(object sender, EventArgs e)
        {
            List();
        }

        private void btnclean_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtid.Text = dr["NOTID"].ToString();
            txtdate.Text = dr["DATE"].ToString();
            txthour.Text = dr["HOUR"].ToString();
            txttitle.Text = dr["TITLE"].ToString();
            txtdetail.Text = dr["DETAIL"].ToString();
            txtusername.Text = dr["USERNAME"].ToString();
            txtcc.Text = dr["NOTSEND"].ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update TBL_Nots set DATE=@p1,HOUR=@p2,TITLE=@p3,DETAIL=@p4," +
                "NOTSEND=@p5,USERNAME=@p6 where NOTID=@p", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtdate.Text);
            cmd.Parameters.AddWithValue("@p2", txthour.Text);
            cmd.Parameters.AddWithValue("@p3", txttitle.Text);
            cmd.Parameters.AddWithValue("@p4", txtdetail.Text);
            cmd.Parameters.AddWithValue("@p5", txtcc.Text);
            cmd.Parameters.AddWithValue("@p6", txtusername.Text);
            cmd.Parameters.AddWithValue("@p", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Note has been updated successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            clean();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from TBL_Nots where NOTID=@p1", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Note was successfully deleted", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            List();
            clean();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into TBL_Nots (DATE,HOUR,TITLE,DETAIL,USERNAME,NOTSEND" +
               ") VALUES (@p1,@p2,@p3,@p4,@p5,@p)", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtdate.Text);
            cmd.Parameters.AddWithValue("@p2", txthour.Text);
            cmd.Parameters.AddWithValue("@p3", txttitle.Text);
            cmd.Parameters.AddWithValue("@p4", txtdetail.Text);
            cmd.Parameters.AddWithValue("@p5", txtusername.Text);
            cmd.Parameters.AddWithValue("@p", txtcc.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Note has been added successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            clean();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay fr = new FrmNotDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.metin = dr["DETAIL"].ToString();
            }
            fr.Show();
        }
    }
}

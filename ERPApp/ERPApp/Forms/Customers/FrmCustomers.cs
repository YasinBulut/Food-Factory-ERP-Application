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

namespace ERPApp.Forms.Customers
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();

        void List()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_Musteriler ",con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void CityList()
        {
            SqlCommand cmd = new SqlCommand("Select sehir From iller",con.conn());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbprov.Properties.Items.Add(dr[0]);
            }
            con.conn().Close();
        }
        private void FrmCustomers_Load(object sender, EventArgs e)
        {
            List();
            CityList();
        }

        private void cmbprov_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdist.Properties.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select ilce from ilceler Where sehir=@p1",con.conn());
            cmd.Parameters.AddWithValue("@p1",cmbprov.SelectedIndex+1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbdist.Properties.Items.Add(dr[0]);
            }
            con.conn().Close();
        }
        void clean()
        {
            txtid.Text = "";
            txtname.Text = "";
            txtsurname.Text = "";
            mskph1.Text = "";
            mskph2.Text = "";
            msktc1.Text = "";
            txtmail.Text = "";
            cmbprov.Text = "";
            cmbdist.Text = "";
            txtadress.Text = "";
            txttax.Text = "";
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into TBL_Musteriler (NAME,SURNAME,PHONE,PHONE2,TC,MAIL," +
                "PROVINCE,DISTRICT,ADRESS,TAXOFFICE) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)",con.conn());
            cmd.Parameters.AddWithValue("@p1",txtname.Text);
            cmd.Parameters.AddWithValue("@p2",txtsurname.Text);
            cmd.Parameters.AddWithValue("@p3",mskph1.Text);
            cmd.Parameters.AddWithValue("@p4",mskph2.Text);
            cmd.Parameters.AddWithValue("@p5",msktc1.Text);
            cmd.Parameters.AddWithValue("@p6",txtmail.Text);
            cmd.Parameters.AddWithValue("@p7",cmbprov.Text);
            cmd.Parameters.AddWithValue("@p8",cmbdist.Text);
            cmd.Parameters.AddWithValue("@p9",txtadress.Text);
            cmd.Parameters.AddWithValue("@p10",txttax.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Customer has been added successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            clean();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from TBL_Musteriler where ID=@p1",con.conn());
            cmd.Parameters.AddWithValue("@p1",txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The customer was successfully deleted", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            List();
            clean();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtid.Text = dr["ID"].ToString();
            txtsurname.Text = dr["SURNAME"].ToString();
            txtname.Text = dr["NAME"].ToString();
            mskph1.Text = dr["PHONE"].ToString();
            mskph2.Text = dr["PHONE2"].ToString();
            msktc1.Text = dr["TC"].ToString();
            txtmail.Text = dr["MAIL"].ToString();
            cmbprov.Text = dr["PROVINCE"].ToString();
            cmbdist.Text = dr["DISTRICT"].ToString();
            txtadress.Text = dr["ADRESS"].ToString();
            txttax.Text = dr["TAXOFFICE"].ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update TBL_Musteriler set NAME=@p1,SURNAME=@p2,PHONE=@p3,PHONE2=@p4," +
                "TC=@p5,MAIL=@p6,PROVINCE=@p7,DISTRICT=@p8,ADRESS=@p9,TAXOFFICE=@p10 where ID=@p11",con.conn());
            cmd.Parameters.AddWithValue("@p1", txtname.Text);
            cmd.Parameters.AddWithValue("@p2", txtsurname.Text);
            cmd.Parameters.AddWithValue("@p3", mskph1.Text);
            cmd.Parameters.AddWithValue("@p4", mskph2.Text);
            cmd.Parameters.AddWithValue("@p5", msktc1.Text);
            cmd.Parameters.AddWithValue("@p6", txtmail.Text);
            cmd.Parameters.AddWithValue("@p7", cmbprov.Text);
            cmd.Parameters.AddWithValue("@p8", cmbdist.Text);
            cmd.Parameters.AddWithValue("@p9", txtadress.Text);
            cmd.Parameters.AddWithValue("@p10", txttax.Text);
            cmd.Parameters.AddWithValue("@p11", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Customer has been updated successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            clean(); 
        }

        private void btnclean_Click(object sender, EventArgs e)
        {
            clean();
        }
    }
}

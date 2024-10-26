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

namespace ERPApp.Forms.Staff
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        void List()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_Personeller ", con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void CityList()
        {
            SqlCommand cmd = new SqlCommand("Select sehir From iller", con.conn());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbprov.Properties.Items.Add(dr[0]);
            }
            con.conn().Close();
        }
        private void Staff_Load(object sender, EventArgs e)
        {
            List();
        }
        void clean()
        {
            txtid.Text = "";
            txtname.Text = "";
            txtsurname.Text = "";
            txtph1.Text = "";
            txttc.Text = "";
            txtmail.Text = "";
            cmbprov.Text = "";
            cmbdist.Text = "";
            txtadress.Text = "";
            txtduty.Text = "";
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update TBL_Personeller set NAME=@p1,SURNAME=@p2,PHONE=@p3," +
                "TC=@p4,MAIL=@p5,PROVINCE=@p6,DISTRICT=@p7,ADRESS=@p8,JOB=@p9 where ID=@p10", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtname.Text);
            cmd.Parameters.AddWithValue("@p2", txtsurname.Text);
            cmd.Parameters.AddWithValue("@p3", txtph1.Text);
            cmd.Parameters.AddWithValue("@p4", txttc.Text);
            cmd.Parameters.AddWithValue("@p5", txtmail.Text);
            cmd.Parameters.AddWithValue("@p6", cmbprov.Text);
            cmd.Parameters.AddWithValue("@p7", cmbdist.Text);
            cmd.Parameters.AddWithValue("@p8", txtadress.Text);
            cmd.Parameters.AddWithValue("@p9", txtduty.Text);
            cmd.Parameters.AddWithValue("@p10", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Staff has been updated successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            clean();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from TBL_Personeller where ID=@p1", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Staff was successfully deleted", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            List();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtid.Text = dr["ID"].ToString();
            txtname.Text = dr["NAME"].ToString();
            txtsurname.Text = dr["SURNAME"].ToString();
            txtph1.Text = dr["PHONE"].ToString();
            txttc.Text = dr["TC"].ToString();
            txtmail.Text = dr["MAIL"].ToString();
            cmbprov.Text = dr["PROVINCE"].ToString();
            cmbdist.Text = dr["DISTRICT"].ToString();
            txtadress.Text = dr["ADRESS"].ToString();
            txtduty.Text = dr["JOB"].ToString();
        }

        private void cmbprov_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdist.Properties.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select ilce from ilceler Where sehir=@p1", con.conn());
            cmd.Parameters.AddWithValue("@p1", cmbprov.SelectedIndex + 1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbdist.Properties.Items.Add(dr[0]);
            }
            con.conn().Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into TBL_Personeller (NAME,SURNAME,PHONE,TC,MAIL," +
                "PROVINCE,DISTRICT,ADRESS,JOB) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtname.Text);
            cmd.Parameters.AddWithValue("@p2", txtsurname.Text);
            cmd.Parameters.AddWithValue("@p3", txtph1.Text);
            cmd.Parameters.AddWithValue("@p4", txttc.Text);
            cmd.Parameters.AddWithValue("@p5", txtmail.Text);
            cmd.Parameters.AddWithValue("@p6", cmbprov.Text);
            cmd.Parameters.AddWithValue("@p7", cmbdist.Text);
            cmd.Parameters.AddWithValue("@p8", txtadress.Text);
            cmd.Parameters.AddWithValue("@p9", txtduty.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Staff has been added successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            clean();
        }

        private void btnclean_Click(object sender, EventArgs e)
        {
            clean();
        }
    }
}

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

namespace ERPApp.Forms.Firms
{
    public partial class FrmFirms : Form
    {
        public FrmFirms()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        void FirmsList()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_Firmalar",con.conn());
            DataTable dt = new DataTable();
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
        void clean()
        {
            txtid.Text = "";
            txtfirmname.Text = "";
            txtph1.Text = "";
            txtph2.Text = "";
            txtph3.Text = "";
            txtmail.Text = "";
            txtfax.Text = "";
            txtautname.Text = "";
            txtautduty.Text = "";
            cmbprov.Text = "";
            cmbdist.Text = "";
            txttax.Text = "";
            txtadress.Text = "";
        }

        private void FrmFirms_Load(object sender, EventArgs e)
        {
            FirmsList();
            CityList();
            clean();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["ID"].ToString();
                txtfirmname.Text = dr["NAME"].ToString();
                txtph1.Text = dr["PHONE1"].ToString();
                txtph2.Text = dr["PHONE2"].ToString();
                txtph3.Text = dr["PHONE3"].ToString();
                txtmail.Text = dr["MAIL"].ToString();
                txtfax.Text = dr["FAX"].ToString();
                txtautname.Text = dr["AUTHORIZEDNAME"].ToString();
                txtautduty.Text = dr["AUTHORIZEDDUTY"].ToString();
                cmbprov.Text = dr["PROVINCE"].ToString();
                cmbdist.Text = dr["DISTRICT"].ToString();
                txttax.Text = dr["TAXOFFICE"].ToString();
                txtadress.Text = dr["ADRESS"].ToString();
            }
          
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into TBL_Firmalar (NAME,AUTHORIZEDDUTY,AUTHORIZEDNAME," +
                "PHONE1,PHONE2,PHONE3,MAIL,FAX,PROVINCE,DISTRICT,TAXOFFICE,ADRESS) VALUES" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)",con.conn());
            cmd.Parameters.AddWithValue("@p1", txtfirmname.Text);
            cmd.Parameters.AddWithValue("@p2", txtautduty.Text);
            cmd.Parameters.AddWithValue("@p3", txtautname.Text);
            cmd.Parameters.AddWithValue("@p4", txtph1.Text);
            cmd.Parameters.AddWithValue("@p5", txtph2.Text);
            cmd.Parameters.AddWithValue("@p6", txtph3.Text);
            cmd.Parameters.AddWithValue("@p7", txtmail.Text);
            cmd.Parameters.AddWithValue("@p8", txtfax.Text);
            cmd.Parameters.AddWithValue("@p9", cmbprov.Text);
            cmd.Parameters.AddWithValue("@p10", cmbdist.Text);
            cmd.Parameters.AddWithValue("@p11", txttax.Text);
            cmd.Parameters.AddWithValue("@p12", txtadress.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Firms has been added successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmsList();
            clean();
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from TBL_Firmalar where ID=@p1", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Firms was successfully deleted", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            FirmsList();
            clean();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update TBL_Firmalar set NAME=@p1,AUTHORIZEDDUTY=@p2,AUTHORIZEDNAME=@p3,PHONE1=@p4," +
               "PHONE2=@p5,PHONE3=@p6,MAIL=@p7,FAX=@p8,PROVINCE=@p9,DISTRICT=@p10,TAXOFFICE=@p11,ADRESS=@p12 where ID=@p13", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtfirmname.Text);
            cmd.Parameters.AddWithValue("@p2", txtautduty.Text);
            cmd.Parameters.AddWithValue("@p3", txtautname.Text);
            cmd.Parameters.AddWithValue("@p4", txtph1.Text);
            cmd.Parameters.AddWithValue("@p5", txtph2.Text);
            cmd.Parameters.AddWithValue("@p6", txtph3.Text);
            cmd.Parameters.AddWithValue("@p7", txtmail.Text);
            cmd.Parameters.AddWithValue("@p8", txtfax.Text);
            cmd.Parameters.AddWithValue("@p9", cmbprov.Text);
            cmd.Parameters.AddWithValue("@p10", cmbdist.Text);
            cmd.Parameters.AddWithValue("@p11", txttax.Text);
            cmd.Parameters.AddWithValue("@p12", txtadress.Text);
            cmd.Parameters.AddWithValue("@p13", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Firms has been updated successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmsList();
            clean();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            clean();
        }
    }
}

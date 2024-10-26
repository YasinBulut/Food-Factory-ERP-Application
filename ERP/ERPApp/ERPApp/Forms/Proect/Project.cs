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
using S7.Net;
using S7.Net.Types;

namespace ERPApp.Forms.Proect
{
    public partial class Project : Form
    {
        public Project()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        private Plc plc = null;
        void clean()
        {
            txtid.Text = "";
            txtname.Text = "";
            txtdesc.Text = "";
            txttype.Text = "";
            cmbstatus.Text = "";

        }
        void List()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_WorkOrder ", con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void Project_Load(object sender, EventArgs e)
        {
            List();
            try
            {
                cmbcpu.DataSource = Enum.GetNames(typeof(CpuType));

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtid.Text = dr["WORKORDERID"].ToString();
            txtname.Text = dr["WORKORDERNAME"].ToString();
            txttype.Text = dr["WORKORDERTYPE"].ToString();
            txtdesc.Text = dr["DESCRIPTION"].ToString();
            cmbstatus.Text = dr["STATUS"].ToString();

        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (plc.IsConnected)
                {
                    plc.Close();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdate_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update TBL_WorkOrder set WORKORDERNAME=@p1,DESCRIPTION=@p2,WORKORDERTYPE=@p3,STATUS=@p4 " +
         "where WORKORDERID=@p11", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtname.Text);
            cmd.Parameters.AddWithValue("@p2", txtdesc.Text);
            cmd.Parameters.AddWithValue("@p3", txttype.Text);
            cmd.Parameters.AddWithValue("@p4", cmbstatus.Text);
            cmd.Parameters.AddWithValue("@p11", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The WorkOrder has been updated successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            clean();
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into TBL_WorkOrder (WORKORDERNAME,DESCRIPTION,WORKORDERTYPE,STATUS) VALUES (@p1,@p2,@p3,@p4)", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtname.Text);
            cmd.Parameters.AddWithValue("@p2", txtdesc.Text);
            cmd.Parameters.AddWithValue("@p3", txttype.Text);
            cmd.Parameters.AddWithValue("@p4", cmbstatus.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The WorkOrder has been added successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            clean();
        }

        private void btndelete_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from TBL_WorkOrder where WORKORDERID=@p1", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The WorkOrder was successfully deleted", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            List();
            clean();
        }

        private void btnclean_Click_1(object sender, EventArgs e)
        {
            clean();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            CpuType cpu = (CpuType)Enum.Parse(typeof(CpuType), Convert.ToString(cmbcpu.SelectedValue));
            plc = new Plc(cpu, txtip.Text, Convert.ToInt16(cmbrock.SelectedValue), Convert.ToInt16(cmbslot.SelectedValue));
            plc.Open();
            if (plc.IsConnected)
            {
            }

        }

        string W1, W2, W3, W4, W5, W6, W7, W8, W9, W10, W11, W12, W13, W14, W15;
        private void simpleButton3_Click(object sender, EventArgs e)
        {


            if (plc.IsConnected == true)
            {
                SqlCommand cmd1 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=1 ", con.conn());
                var result = cmd1.ExecuteScalar();
                if (result != null)
                {
                    W1 = result.ToString();
                }
                SqlCommand cmd2 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=2 ", con.conn());
                var result1 = cmd2.ExecuteScalar();
                if (result1 != null)
                {
                    W2 = result1.ToString();
                }
                SqlCommand cmd3 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=3 ", con.conn());
                var result2 = cmd3.ExecuteScalar();
                if (result2 != null)
                {
                    W3 = result2.ToString();
                }
                SqlCommand cmd4 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=4 ", con.conn());
                var result3 = cmd4.ExecuteScalar();
                if (result3 != null)
                {
                    W4 = result3.ToString();
                }
                SqlCommand cmd5 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=5 ", con.conn());
                var result4 = cmd5.ExecuteScalar();
                if (result4 != null)
                {
                    W5 = result4.ToString();
                }
                SqlCommand cmd6 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=6 ", con.conn());
                var result5 = cmd6.ExecuteScalar();
                if (result5 != null)
                {
                    W6 = result5.ToString();
                }
                SqlCommand cmd7 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=7 ", con.conn());
                var result6 = cmd7.ExecuteScalar();
                if (result6 != null)
                {
                    W7 = result6.ToString();
                }
                SqlCommand cmd8 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=8 ", con.conn());
                var result7 = cmd8.ExecuteScalar();
                if (result7 != null)
                {
                    W8 = result7.ToString();
                }
                SqlCommand cmd9 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=9 ", con.conn());
                var result8 = cmd9.ExecuteScalar();
                if (result8 != null)
                {
                    W9 = result8.ToString();
                }
                SqlCommand cmd10 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=10 ", con.conn());
                var result9 = cmd10.ExecuteScalar();
                if (result9 != null)
                {
                    W10 = result9.ToString();
                }
                SqlCommand cmd11 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=11 ", con.conn());
                var result10 = cmd11.ExecuteScalar();
                if (result10 != null)
                {
                    W11 = result10.ToString();
                }
                SqlCommand cmd12 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=12 ", con.conn());
                var result11 = cmd12.ExecuteScalar();
                if (result11 != null)
                {
                    W12 = result11.ToString();
                }
                SqlCommand cmd13 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=13 ", con.conn());
                var result12 = cmd13.ExecuteScalar();
                if (result12 != null)
                {
                    W13 = result12.ToString();
                }
                SqlCommand cmd14 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=14 ", con.conn());
                var result13 = cmd14.ExecuteScalar();
                if (result13 != null)
                {
                    W14 = result13.ToString();
                }
                SqlCommand cmd15 = new SqlCommand("Select STATUS From TBL_WorkOrder where WORKORDERID=15 ", con.conn());
                var result14 = cmd15.ExecuteScalar();
                if (result14 != null)
                {
                    W15 = result14.ToString();
                }
            }

            bool yazılandeğer1 = Convert.ToBoolean(W1.ToString());
            bool yazılandeğer2 = Convert.ToBoolean(W2.ToString());
            bool yazılandeğer3 = Convert.ToBoolean(W3.ToString());
            bool yazılandeğer4 = Convert.ToBoolean(W4.ToString());
            bool yazılandeğer5 = Convert.ToBoolean(W5.ToString());
            bool yazılandeğer6 = Convert.ToBoolean(W6.ToString());
            bool yazılandeğer7 = Convert.ToBoolean(W7.ToString());
            bool yazılandeğer8 = Convert.ToBoolean(W8.ToString());
            bool yazılandeğer9 = Convert.ToBoolean(W9.ToString());
            bool yazılandeğer10 = Convert.ToBoolean(W10.ToString());
            bool yazılandeğer11 = Convert.ToBoolean(W11.ToString());
            bool yazılandeğer12 = Convert.ToBoolean(W12.ToString());
            bool yazılandeğer13 = Convert.ToBoolean(W13.ToString());
            bool yazılandeğer14 = Convert.ToBoolean(W14.ToString());
            bool yazılandeğer15 = Convert.ToBoolean(W15.ToString());


            plc.Write("DB10.DBX0.0", yazılandeğer1);
            plc.Write("DB10.DBX0.1",yazılandeğer2);
            plc.Write("DB10.DBX0.2",yazılandeğer3);
            plc.Write("DB10.DBX0.3",yazılandeğer4);
            plc.Write("DB10.DBX0.4",yazılandeğer5);
            plc.Write("DB10.DBX0.5",yazılandeğer6);
            plc.Write("DB10.DBX0.6",yazılandeğer7);
            plc.Write("DB10.DBX0.7",yazılandeğer8);
            plc.Write("DB10.DBX1.0",yazılandeğer9);
            plc.Write("DB10.DBX1.1",yazılandeğer10);
            plc.Write("DB10.DBX1.2",yazılandeğer11);
            plc.Write("DB10.DBX1.3",yazılandeğer12);
            plc.Write("DB10.DBX1.4",yazılandeğer13);
            plc.Write("DB10.DBX1.5",yazılandeğer14);
            plc.Write("DB10.DBX1.6",yazılandeğer15);


            MessageBox.Show("The work order has been successfully transferred to the PLC.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);






        }
    }
}


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
    public partial class FrmBills : Form
    {
        public FrmBills()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        void List()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FaturaBilgi ", con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void clean()
        {
            txtid.Text = "";
            txtserial.Text = "";
            txtseq.Text = "";
            txtdate.Text = "";
            txthour.Text = "";
            txttax.Text = "";
            txtbuyer.Text = "";
            txtdel.Text = "";
            txtrece.Text = "";
            txtinvoiceid.Text = "";
            txtproductname.Text = "";
            txtquantity.Text = "";
            txtprice.Text = "";
            txtamount.Text = "";
            txtinvoiceid.Text = "";
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void FrmBills_Load(object sender, EventArgs e)
        {
            List();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtinvoiceid.Text=="")
            {
                SqlCommand cmd = new SqlCommand("insert into TBL_FaturaBilgi (ID,SERIAL,SEQUENCENO,DATE,HOUR,TAXOFFICE,BUYER," +
                 "DELIVEREDBY,RECEIVER) VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", con.conn());
                cmd.Parameters.AddWithValue("@p0", txtid.Text);
                cmd.Parameters.AddWithValue("@p1", txtserial.Text);
                cmd.Parameters.AddWithValue("@p2", txtseq.Text);
                cmd.Parameters.AddWithValue("@p3", txtdate.Text);
                cmd.Parameters.AddWithValue("@p4", txthour.Text);
                cmd.Parameters.AddWithValue("@p5", txttax.Text);
                cmd.Parameters.AddWithValue("@p6", txtbuyer.Text);
                cmd.Parameters.AddWithValue("@p7", txtdel.Text);
                cmd.Parameters.AddWithValue("@p8", txtrece.Text);
                cmd.ExecuteNonQuery();
                con.conn().Close();
                MessageBox.Show("The Bill has been added successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List();
                clean();
            }
            if (txtinvoiceid.Text !="")
            {
                double quantity, price, amount;
                amount = Convert.ToDouble(txtamount.Text);
                quantity = Convert.ToDouble(txtquantity.Text);
                price = amount * quantity;
                txtprice.Text = price.ToString();
                SqlCommand cmd2 = new SqlCommand("insert into TBL_FaturaDetay (INVOICEITEMID,PRODUCTNAME,QUANTITY,PRICE,AMOUNT,INVOICEID) VALUES (@p0,@p1,@p2,@p3,@p4,@p5)", con.conn());
                cmd2.Parameters.AddWithValue("@p0", txtinvoiceid.Text);
                cmd2.Parameters.AddWithValue("@p1", txtproductname.Text);
                cmd2.Parameters.AddWithValue("@p2", txtquantity.Text);
                cmd2.Parameters.AddWithValue("@p3", txtprice.Text);
                cmd2.Parameters.AddWithValue("@p4", txtamount.Text);
                cmd2.Parameters.AddWithValue("@p5", txtinvoiceid.Text);
                cmd2.ExecuteNonQuery();
                con.conn().Close();
                MessageBox.Show("Invoice sinformation has been successfully saved", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List();
                clean();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtid.Text = dr["ID"].ToString();
            txtserial.Text = dr["SERIAL"].ToString();
            txtseq.Text = dr["SEQUENCENO"].ToString();
            txtdate.Text = dr["DATE"].ToString();
            txthour.Text = dr["HOUR"].ToString();
            txttax.Text = dr["TAXOFFICE"].ToString();
            txtbuyer.Text = dr["BUYER"].ToString();
            txtdel.Text = dr["DELIVEREDBY"].ToString();
            txtrece.Text = dr["RECEIVER"].ToString();
        }

       private void simpleButton1_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void btndelete_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from TBL_FaturaBilgi where ID=@p1", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Bill was successfully deleted", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            List();
            clean();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update TBL_FaturaBilgi set SERIAL=@p1,SEQUENCENO=@p2,DATE=@p3,HOUR=@p4," +
               "TAXOFFICE=@p5,BUYER=@p6,DELIVEREDBY=@p7,RECEIVER=@p8 where ID=@p11", con.conn());
            cmd.Parameters.AddWithValue("@p0", txtid.Text);
            cmd.Parameters.AddWithValue("@p1", txtserial.Text);
            cmd.Parameters.AddWithValue("@p2", txtseq.Text);
            cmd.Parameters.AddWithValue("@p3", txtdate.Text);
            cmd.Parameters.AddWithValue("@p4", txthour.Text);
            cmd.Parameters.AddWithValue("@p5", txttax.Text);
            cmd.Parameters.AddWithValue("@p6", txtbuyer.Text);
            cmd.Parameters.AddWithValue("@p7", txtdel.Text);
            cmd.Parameters.AddWithValue("@p8", txtrece.Text);
            cmd.Parameters.AddWithValue("@p11", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Bill has been updated successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            clean();
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            FrmBilProduct fr = new FrmBilProduct();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.id = dr["ID"].ToString();
            }
            fr.Show();
        }
    }
}

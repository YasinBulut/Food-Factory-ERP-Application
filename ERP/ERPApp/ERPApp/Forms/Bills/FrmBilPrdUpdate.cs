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
    public partial class FrmBilPrdUpdate : Form
    {
        public FrmBilPrdUpdate()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        public string productid;
        private void FrmBilPrdUpdate_Load(object sender, EventArgs e)
        {
            txtdetailıd.Text = productid;

    
            SqlCommand cmd = new SqlCommand("Select * From TBL_FaturaDetay where INVOICEID=@p1", con.conn());
            cmd.Parameters.AddWithValue("@p1", productid);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtproductname.Text = dr[1].ToString();
                txtquantity.Text = dr[2].ToString();
                txtprice.Text = dr[3].ToString();
                txtamount.Text = dr[4].ToString();


            }
        }


        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update TBL_FaturaDetay set PRODUCTNAME=@p1,QUANTITY=@p2,PRICE=@p3,AMOUNT=@p4 where INVOICEITEMID=@p5", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtproductname.Text);
            cmd.Parameters.AddWithValue("@p2", txtquantity.Text);
            cmd.Parameters.AddWithValue("@p3",decimal.Parse(txtprice.Text));
            cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtamount.Text));
            cmd.Parameters.AddWithValue("@p5", txtdetailıd.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Bill product info has been updated successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from TBL_FaturaDetay where INVOICEITEMID=@p1", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtdetailıd.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Bill product info was successfully deleted", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}

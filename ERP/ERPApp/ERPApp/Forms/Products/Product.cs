using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ERPApp.Forms.Products
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        void List()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_Urunler", con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void clean()
        {
            txtid.Text = "";
            txtname.Text = "";
            txtcategory.Text = "";
            txtbrand.Text = "";
            nmrcquantity.Text = "";
            txtcost.Text = "";
            txtsales.Text = "";
            txtdetail.Text = "";
        }
        private void Product_Load(object sender, EventArgs e)
        {
            List();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            // Data Save
            SqlCommand cmd = new SqlCommand("insert into TBL_Urunler (CATEGORY,NAME,BRAND,QUANTITY,COST,SALES,DETAILS) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtcategory.Text);
            cmd.Parameters.AddWithValue("@p2", txtname.Text);
            cmd.Parameters.AddWithValue("@p3", txtbrand.Text);
            cmd.Parameters.AddWithValue("@p4", int.Parse((nmrcquantity.Value).ToString()));
            cmd.Parameters.AddWithValue("@p5", decimal.Parse(txtcost.Text));
            cmd.Parameters.AddWithValue("@p6", decimal.Parse(txtsales.Text));
            cmd.Parameters.AddWithValue("@p7", txtdetail.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The product has been added successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            clean();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update TBL_Urunler set CATEGORY=@p1,NAME=@p2,BRAND=@p3,QUANTITY=@p4 , " +
                "COST=@p5,SALES=@p6,DETAILS=@p7 where ID=@p8", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtcategory.Text);
            cmd.Parameters.AddWithValue("@p2", txtname.Text);
            cmd.Parameters.AddWithValue("@p3", txtbrand.Text);
            cmd.Parameters.AddWithValue("@p4", int.Parse((nmrcquantity.Value).ToString()));
            cmd.Parameters.AddWithValue("@p5", decimal.Parse(txtcost.Text));
            cmd.Parameters.AddWithValue("@p6", decimal.Parse(txtsales.Text));
            cmd.Parameters.AddWithValue("@p7", txtdetail.Text);
            cmd.Parameters.AddWithValue("@p8", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The product has been updated successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            clean();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmddelete = new SqlCommand("Delete From TBL_Urunler where ID=@p1", con.conn());
            cmddelete.Parameters.AddWithValue("@p1", txtid.Text);
            cmddelete.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The product was successfully deleted", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            List();
            clean();

        }

        private void btnclean_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtid.Text = dr["ID"].ToString();
            txtcategory.Text = dr["CATEGORY"].ToString();
            txtname.Text = dr["NAME"].ToString();
            txtbrand.Text = dr["BRAND"].ToString();
            nmrcquantity.Value = decimal.Parse(dr["QUANTITY"].ToString());
            txtcost.Text = dr["COST"].ToString();
            txtsales.Text = dr["SALES"].ToString();
            txtdetail.Text = dr["DETAILS"].ToString();
        }
    }
}

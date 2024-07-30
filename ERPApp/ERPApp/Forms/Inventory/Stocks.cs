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

namespace ERPApp.Forms.Inventory
{
    public partial class Stocks : Form
    {
        public Stocks()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        private void Stocks_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul",4);
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul",4);
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul",4);
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul",4);
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul",4);

            SqlDataAdapter da = new SqlDataAdapter("Select NAME,SUM(QUANTITY) as 'TOTAL' from Tbl_Urunler group by NAME",con.conn());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //Charta Stok miktarı listeleme
            SqlCommand cmd = new SqlCommand("Select NAME,SUM(QUANTITY) as 'TOTAL' from Tbl_Urunler group by NAME",con.conn());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(dr[0].ToString(),Convert.ToDouble(dr[1]));
            }
            con.conn().Close();


            //Charta Stok miktarı listeleme
            SqlCommand cmd2 = new SqlCommand("Select PROVINCE,Count(*)  from Tbl_Firmalar group by PROVINCE", con.conn());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(dr2[0].ToString(), Convert.ToDouble(dr2[1]));
            }
            con.conn().Close();



        }
    }
}

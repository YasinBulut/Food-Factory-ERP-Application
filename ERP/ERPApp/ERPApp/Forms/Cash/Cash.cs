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
using DevExpress.Charts;

namespace ERPApp.Forms.Cash
{
    public partial class Cash : Form
    {
        public Cash()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();

        void custact()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute Customer_Activate", con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void firmact()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Execute Firm_Activate", con.conn());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }
        void billact()
        {
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from TBL_Expense", con.conn());
            da3.Fill(dt3);
            gridControl3.DataSource = dt3;
        }
        private void Cash_Load(object sender, EventArgs e)
        {
            firmact();
            custact();
            billact();

            //total
            SqlCommand cmd1 = new SqlCommand("Select Sum(AMOUNT) from TBL_FaturaDetay", con.conn());
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                lbltotal.Text = dr1[0].ToString()+" TL";
            }
            con.conn().Close();

            //payments
            SqlCommand cmd2 = new SqlCommand("Select (ELECTRIC+WATER+NATURALGAS+INTERNET+EXTRA) from TBL_Expense order by ID asc", con.conn());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                lblpayments.Text = dr2[0].ToString() + " BIN";
            }
            con.conn().Close();

            //staff salary
            SqlCommand cmd3 = new SqlCommand("Select SALARY from TBL_Expense order by ID asc", con.conn());
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                lblstafsalary.Text = dr3[0].ToString() + " BIN";
            }
            con.conn().Close();

            //number of customer
            SqlCommand cmd4 = new SqlCommand("Select Count(*) from TBL_Musteriler", con.conn());
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                lblcustomer.Text = dr4[0].ToString();
            }
            con.conn().Close();

            //number of firms
            SqlCommand cmd5 = new SqlCommand("Select Count(*) from Tbl_Firmalar", con.conn());
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                lblfirms.Text = dr5[0].ToString();
            }
            con.conn().Close();
            //number of cities
            SqlCommand cmd6 = new SqlCommand("Select Count(Distinct(PROVINCE)) from Tbl_Firmalar", con.conn());
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            {
                lblcity.Text = dr6[0].ToString();
            }
            con.conn().Close();
            //number of cities
            SqlCommand cmd61 = new SqlCommand("Select Count(Distinct(PROVINCE)) from TBL_Musteriler", con.conn());
            SqlDataReader dr61 = cmd61.ExecuteReader();
            while (dr61.Read())
            {
                lblcit2.Text = dr61[0].ToString();
            }
            con.conn().Close();

            //number of STAFF
            SqlCommand cmd7 = new SqlCommand("Select Count(*) from TBL_Personeller", con.conn());
            SqlDataReader dr7 = cmd7.ExecuteReader();
            while (dr7.Read())
            {
                lblstaff.Text = dr7[0].ToString();
            }
            con.conn().Close();
            //number of STOCKS
            SqlCommand cmd8 = new SqlCommand("Select Sum(QUANTITY) from Tbl_Urunler", con.conn());
            SqlDataReader dr8 = cmd8.ExecuteReader();
            while (dr8.Read())
            {
                lblstock.Text = dr8[0].ToString();
            }
            con.conn().Close();


            //1.CHART ELECTRİC BİLL 
            SqlCommand Cmd9 = new SqlCommand("Select top 4 Month,ELECTRIC from TBL_Expense order by ID desc",con.conn());
            SqlDataReader dr9 = Cmd9.ExecuteReader();
            while (dr9.Read())
            {
                chartControl1.Series["MONTH"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
            }
            con.conn().Close();


            //1.CHART WATER BİLL 
            SqlCommand cmd10 = new SqlCommand("Select top 4 Month,WATER from TBL_Expense order by ID desc", con.conn());
            SqlDataReader dr10 = cmd10.ExecuteReader();
            while (dr10.Read())
            {
                chartControl2.Series["MONTH"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
            }
            con.conn().Close();
        }
    }
}

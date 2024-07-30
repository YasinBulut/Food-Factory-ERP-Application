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

namespace ERPApp.Forms.HomePage
{
    public partial class Home2 : Form
    {
        public Home2()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();

        void StocList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select NAME,SUM(QUANTITY) As 'QUANTITY' FROM Tbl_Urunler group by NAME having SUM(QUANTITY)<=25 order by SUM(QUANTITY)", con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void Agenda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select top 5 DATE,HOUR,TITLE from TBL_Nots order by NOTID desc", con.conn());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }
        void RecentAct()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute Firm_Activate2", con.conn());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }
        void Index()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select NAME,PHONE1,MAIL from Tbl_Firmalar", con.conn());
            da.Fill(dt);
            gridControl4.DataSource = dt;
        }
        private void Home2_Load(object sender, EventArgs e)
        {
            StocList();
            Agenda();
            RecentAct();
            Index();

            webBrowser1.Navigate("https://www.tcmb.gov.tr/wps/wcm/connect/tr/tcmb+tr/main+page+site+area/bugun");
            webBrowser2.Navigate("https://github.com/YasinBulut");
            webBrowser3.Navigate("https://www.google.com.tr/?hl=tr");
        }
    }
}

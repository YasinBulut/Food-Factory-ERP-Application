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

namespace ERPApp.Forms.Expenses
{
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        void clean()
        {
            txtid.Text = "";
            txtmonth.Text = "";
            txtyear.Text = "";
            txtelec.Text = "";
            txtwater.Text = "";
            txtgas.Text = "";
            txtint.Text = "";
            txtsalary.Text = "";
            txtextra.Text = "";
            txtnotes.Text = "";
        }
        void ExpensList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select* from TBL_Expense",con.conn());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void Expenses_Load(object sender, EventArgs e)
        {
            ExpensList();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into TBL_Expense (MONTH,YEAR,ELECTRIC,WATER,NATURALGAS," +
                "INTERNET,SALARY,EXTRA,NOTES) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtmonth.Text);
            cmd.Parameters.AddWithValue("@p2", txtyear.Text);
            cmd.Parameters.AddWithValue("@p3", decimal.Parse(txtelec.Text));
            cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtwater.Text));
            cmd.Parameters.AddWithValue("@p5", decimal.Parse(txtgas.Text));
            cmd.Parameters.AddWithValue("@p6", decimal.Parse(txtint.Text));
            cmd.Parameters.AddWithValue("@p7", decimal.Parse(txtsalary.Text));
            cmd.Parameters.AddWithValue("@p8", decimal.Parse(txtextra.Text));
            cmd.Parameters.AddWithValue("@p9", txtnotes.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Expense has been added successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ExpensList();
            clean();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update TBL_Expense set MONTH=@p1,YEAR=@p2,ELECTRIC=@p3," +
                "WATER=@p4,NATURALGAS=@p5,INTERNET=@p6,SALARY=@p7,EXTRA=@p8,NOTES=@p9 where ID=@p10", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtmonth.Text);
            cmd.Parameters.AddWithValue("@p2", txtyear.Text);
            cmd.Parameters.AddWithValue("@p3",decimal.Parse(txtelec.Text));
            cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtwater.Text));
            cmd.Parameters.AddWithValue("@p5", decimal.Parse(txtgas.Text));
            cmd.Parameters.AddWithValue("@p6", decimal.Parse(txtint.Text));
            cmd.Parameters.AddWithValue("@p7", decimal.Parse(txtsalary.Text));
            cmd.Parameters.AddWithValue("@p8", decimal.Parse(txtextra.Text));
            cmd.Parameters.AddWithValue("@p9", txtnotes.Text);
            cmd.Parameters.AddWithValue("@p10", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Expense has been updated successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ExpensList();
            clean();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from TBL_Expense where ID=@p1", con.conn());
            cmd.Parameters.AddWithValue("@p1", txtid.Text);
            cmd.ExecuteNonQuery();
            con.conn().Close();
            MessageBox.Show("The Expense was successfully deleted", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ExpensList();
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
            txtmonth.Text = dr["MONTH"].ToString();
            txtyear.Text = dr["YEAR"].ToString();
            txtelec.Text = dr["ELECTRIC"].ToString();
            txtwater.Text = dr["WATER"].ToString();
            txtgas.Text = dr["NATURALGAS"].ToString();
            txtint.Text = dr["INTERNET"].ToString();
            txtsalary.Text = dr["SALARY"].ToString();
            txtextra.Text = dr["EXTRA"].ToString();
            txtnotes.Text = dr["NOTES"].ToString();
        }
    }
}

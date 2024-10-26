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

namespace ERPApp.Forms.Admin
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        SqlConn con = new SqlConn();
        private void button1_MouseHover(object sender, EventArgs e)
        {
            txtlogin.BackColor = Color.GreenYellow;
        }

        private void txtlogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from TBL_Admin where UserName=@p1 and UserPasw=@p2",con.conn());
            cmd.Parameters.AddWithValue("@p1",txtusername.Text);
            cmd.Parameters.AddWithValue("@p2",txtpasw.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Home fr = new Home();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect login attempt","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            con.conn().Close();
        }
    }
}

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

namespace ERPApp.Forms.MAINTENANCE
{
    public partial class Maint : Form
    {
        public Maint()
        {
            InitializeComponent();
        }

        private void Maint_Load(object sender, EventArgs e)
        {
            try
            {
                cmbcpu.DataSource = Enum.GetNames(typeof(CpuType));

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private Plc plc = null;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            CpuType cpu = (CpuType)Enum.Parse(typeof(CpuType), Convert.ToString(cmbcpu.SelectedValue));
            plc = new Plc(cpu, txtip.Text, Convert.ToInt16(cmbrock.SelectedValue), Convert.ToInt16(cmbslot.SelectedValue));
            plc.Open();
            if (plc.IsConnected)
            {
            }
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
        private void btndataread_Click(object sender, EventArgs e)
        {
            try
            {
                object cv1flt = plc.Read("DB6.DBX0.0");
                object cv2flt = plc.Read("DB6.DBX0.1");
                object cv3flt = plc.Read("DB6.DBX0.2");
                object cv4flt = plc.Read("DB6.DBX0.3");
                object tt1flt = plc.Read("DB6.DBX0.4");
                object tt2flt = plc.Read("DB6.DBX0.5");
                object pt1flt = plc.Read("DB6.DBX0.6");
                object pt2flt = plc.Read("DB6.DBX0.7");
                object pmp1status = plc.Read("DB6.DBW2");
                object pmp2status = plc.Read("DB6.DBW4");
                object pmp3status = plc.Read("DB6.DBW6");
                object pmp4status = plc.Read("DB6.DBW8");
                object v1status = plc.Read("DB6.DBW10");
                object v2status = plc.Read("DB6.DBW12");
                object v3status = plc.Read("DB6.DBW14");
                object v4status = plc.Read("DB6.DBW16");
                object pmp1rpmvalue = plc.Read("DB6.DBW18");
                object pmp2rpmvalue = plc.Read("DB6.DBW20");
                object pmp3rpmvalue = plc.Read("DB6.DBW22");
                object pmp4rpmvalue = plc.Read("DB6.DBW24");
                object Ccv1percent = plc.Read("DB6.DBW26");
                object Ccv2percent = plc.Read("DB6.DBW28");
                object Ccv3percent = plc.Read("DB6.DBW30");
                object Ccv4percent = plc.Read("DB6.DBW32");
                object tt1value = plc.Read("DB6.DBW34");
                object tt2value = plc.Read("DB6.DBW36");
                object pt1value = plc.Read("DB6.DBW38");
                object pt2value = plc.Read("DB6.DBW40");

                int pmp1 = Convert.ToInt32(pmp1status);
                pmp1rpm.Text = pmp1rpmvalue.ToString();
                switch (pmp1)
                {
                    case 0:
                        pmp1rng.BackColor = Color.Transparent;
                        pmp1rnglbl.BackColor = Color.Transparent;
                        pmp1flt.BackColor = Color.Transparent;                   
                        pmp1fltlbl.BackColor = Color.Transparent;
                        break;
                    case 1:
                        pmp1rng.BackColor = Color.LightGreen; 
                        pmp1rnglbl.BackColor = Color.LightGreen;
                        pmp1flt.BackColor = Color.Transparent;
                        pmp1fltlbl.BackColor = Color.Transparent;
                        break;
                    case 2:
                        pmp1rng.BackColor = Color.Transparent;
                        pmp1flt.BackColor = Color.Red;
                        pmp1rnglbl.BackColor = Color.Transparent;
                        pmp1fltlbl.BackColor = Color.Red;
                        break;
                    default:
                        pmp1rng.BackColor = Color.Transparent;
                        pmp1rnglbl.BackColor = Color.Transparent;
                        pmp1flt.BackColor = Color.Transparent;
                        pmp1fltlbl.BackColor = Color.Transparent;
                        break;
                }

                int pmp2 = Convert.ToInt32(pmp2status);
                pmp2rpm.Text = pmp2rpmvalue.ToString();
                switch (pmp2)
                {
                    case 0:
                        pmp2rng.BackColor = Color.Transparent;
                        pmp2rnglbl.BackColor = Color.Transparent;
                        pmp2flt.BackColor = Color.Transparent;
                        pmp2fltlbl.BackColor = Color.Transparent;
                        break;
                    case 1:
                        pmp2rng.BackColor = Color.LightGreen;
                        pmp2rnglbl.BackColor = Color.LightGreen;
                        pmp2flt.BackColor = Color.Transparent;
                        pmp2fltlbl.BackColor = Color.Transparent;
                        break;
                    case 2:
                        pmp2rng.BackColor = Color.Transparent;
                        pmp2flt.BackColor = Color.Red;
                        pmp2rnglbl.BackColor = Color.Transparent;
                        pmp2fltlbl.BackColor = Color.Red;
                        break;
                    default:
                        pmp2rng.BackColor = Color.Transparent;
                        pmp2rnglbl.BackColor = Color.Transparent;
                        pmp2flt.BackColor = Color.Transparent;
                        pmp2fltlbl.BackColor = Color.Transparent;
                        break;
                }

                int pmp3 = Convert.ToInt32(pmp3status);
                pmp3rpm.Text = pmp3rpmvalue.ToString();
                switch (pmp3)
                {
                    case 0:
                        pmp3rng.BackColor = Color.Transparent;
                        pmp3rnglbl.BackColor = Color.Transparent;
                        pmp3flt.BackColor = Color.Transparent;
                        pmp3fltlbl.BackColor = Color.Transparent;
                        break;
                    case 1:
                        pmp3rng.BackColor = Color.LightGreen;
                        pmp3rnglbl.BackColor = Color.LightGreen;
                        pmp3flt.BackColor = Color.Transparent;
                        pmp3fltlbl.BackColor = Color.Transparent;
                        break;
                    case 2:
                        pmp3rng.BackColor = Color.Transparent;
                        pmp3flt.BackColor = Color.Red;
                        pmp3rnglbl.BackColor = Color.Transparent;
                        pmp3fltlbl.BackColor = Color.Red;
                        break;
                    default:
                        pmp3rng.BackColor = Color.Transparent;
                        pmp3rnglbl.BackColor = Color.Transparent;
                        pmp3flt.BackColor = Color.Transparent;
                        pmp3fltlbl.BackColor = Color.Transparent;
                        break;
                }

                int pmp4 = Convert.ToInt32(pmp4status);
                pmp4rpm.Text = pmp4rpmvalue.ToString();
                switch (pmp4)
                {
                    case 0:
                        pmp4rng.BackColor = Color.Transparent;
                        pmp4rnglbl.BackColor = Color.Transparent;
                        pmp4flt.BackColor = Color.Transparent;
                        pmp4fltlbl.BackColor = Color.Transparent;
                        break;
                    case 1:
                        pmp4rng.BackColor = Color.LightGreen;
                        pmp4rnglbl.BackColor = Color.LightGreen;
                        pmp4flt.BackColor = Color.Transparent;
                        pmp4fltlbl.BackColor = Color.Transparent;
                        break;
                    case 2:
                        pmp4rng.BackColor = Color.Transparent;
                        pmp4flt.BackColor = Color.Red;
                        pmp4rnglbl.BackColor = Color.Transparent;
                        pmp4fltlbl.BackColor = Color.Red;
                        break;
                    default:
                        pmp4rng.BackColor = Color.Transparent;
                        pmp4rnglbl.BackColor = Color.Transparent;
                        pmp4flt.BackColor = Color.Transparent;
                        pmp4fltlbl.BackColor = Color.Transparent;
                        break;
                }

                int v1 = Convert.ToInt32(v1status);
                switch (v1)
                {
                    case 0:
                        v1clsd.BackColor = Color.GreenYellow;
                        v1clsdlbl.BackColor = Color.GreenYellow;
                        v1opnd.BackColor = Color.Transparent;
                        v1opndlbl.BackColor = Color.Transparent;
                        v1flt.BackColor = Color.Transparent;
                        v1fltlbl.BackColor = Color.Transparent;
                        break;
                    case 1:
                        v1clsd.BackColor = Color.Transparent;
                        v1clsdlbl.BackColor = Color.Transparent;
                        v1opnd.BackColor = Color.GreenYellow;
                        v1opndlbl.BackColor = Color.GreenYellow;
                        v1flt.BackColor = Color.Transparent;
                        v1fltlbl.BackColor = Color.Transparent;
                        break;
                    case 2:
                        v1clsd.BackColor = Color.Transparent;
                        v1clsdlbl.BackColor = Color.Transparent;
                        v1opnd.BackColor = Color.Transparent;
                        v1opndlbl.BackColor = Color.Transparent;
                        v1flt.BackColor = Color.Red;
                        v1fltlbl.BackColor = Color.Red;
                        break;
                    default:
                      
                        break;
                }

                int v2 = Convert.ToInt32(v2status);
                switch (v2)
                {
                    case 0:
                        v2clsd.BackColor = Color.GreenYellow;
                        v2clsdlbl.BackColor = Color.GreenYellow;
                        v2opnd.BackColor = Color.Transparent;
                        v2opndlbl.BackColor = Color.Transparent;
                        v2flt.BackColor = Color.Transparent;
                        v2fltlbl.BackColor = Color.Transparent;
                        break;
                    case 1:
                        v2clsd.BackColor = Color.Transparent;
                        v2clsdlbl.BackColor = Color.Transparent;
                        v2opnd.BackColor = Color.GreenYellow;
                        v2opndlbl.BackColor = Color.GreenYellow;
                        v2flt.BackColor = Color.Transparent;
                        v2fltlbl.BackColor = Color.Transparent;
                        break;
                    case 2:
                        v2clsd.BackColor = Color.Transparent;
                        v2clsdlbl.BackColor = Color.Transparent;
                        v2opnd.BackColor = Color.Transparent;
                        v2opndlbl.BackColor = Color.Transparent;
                        v2flt.BackColor = Color.Red;
                        v2fltlbl.BackColor = Color.Red;
                        break;
                    default:

                        break;
                }

                int v3 = Convert.ToInt32(v3status);
                switch (v3)
                {
                    case 0:
                        v3clsd.BackColor = Color.GreenYellow;
                        v3clsdlbl.BackColor = Color.GreenYellow;
                        v3opnd.BackColor = Color.Transparent;
                        v3opndlbl.BackColor = Color.Transparent;
                        v3flt.BackColor = Color.Transparent;
                        v3fltlbl.BackColor = Color.Transparent;
                        break;
                    case 1:
                        v3clsd.BackColor = Color.Transparent;
                        v3clsdlbl.BackColor = Color.Transparent;
                        v3opnd.BackColor = Color.GreenYellow;
                        v3opndlbl.BackColor = Color.GreenYellow;
                        v3flt.BackColor = Color.Transparent;
                        v3fltlbl.BackColor = Color.Transparent;
                        break;
                    case 2:
                        v3clsd.BackColor = Color.Transparent;
                        v3clsdlbl.BackColor = Color.Transparent;
                        v3opnd.BackColor = Color.Transparent;
                        v3opndlbl.BackColor = Color.Transparent;
                        v3flt.BackColor = Color.Red;
                        v3fltlbl.BackColor = Color.Red;
                        break;
                    default:

                        break;
                }

                int v4 = Convert.ToInt32(v4status);
                switch (v4)
                {
                    case 0:
                        v4clsd.BackColor = Color.GreenYellow;
                        v4clsdlbl.BackColor = Color.GreenYellow;
                        v4opnd.BackColor = Color.Transparent;
                        v4opndlbl.BackColor = Color.Transparent;
                        v4flt.BackColor = Color.Transparent;
                        v4fltlbl.BackColor = Color.Transparent;
                        break;
                    case 1:
                        v4clsd.BackColor = Color.Transparent;
                        v4clsdlbl.BackColor = Color.Transparent;
                        v4opnd.BackColor = Color.GreenYellow;
                        v4opndlbl.BackColor = Color.GreenYellow;
                        v4flt.BackColor = Color.Transparent;
                        v4fltlbl.BackColor = Color.Transparent;
                        break;
                    case 2:
                        v4clsd.BackColor = Color.Transparent;
                        v4clsdlbl.BackColor = Color.Transparent;
                        v4opnd.BackColor = Color.Transparent;
                        v4opndlbl.BackColor = Color.Transparent;
                        v4flt.BackColor = Color.Red;
                        v4fltlbl.BackColor = Color.Red;
                        break;
                    default:

                        break;
                }

                cv1percent.Text = Ccv1percent.ToString();
                cv2percent.Text = Ccv2percent.ToString();
                cv3percent.Text = Ccv3percent.ToString();
                cv4percent.Text = Ccv4percent.ToString();
                tt1.Text = tt1value.ToString();
                tt2.Text = tt2value.ToString();
                pt1.Text = pt1value.ToString();
                pt2.Text = pt2value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SS_Click(object sender, EventArgs e)
        {

        }
    }
}

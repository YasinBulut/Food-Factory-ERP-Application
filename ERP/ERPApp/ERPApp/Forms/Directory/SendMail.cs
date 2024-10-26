using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace ERPApp.Forms.Directory
{
    public partial class SendMail : Form
    {
        public SendMail()
        {
            InitializeComponent();
        }
        public string mail;
        private void SendMail_Load(object sender, EventArgs e)
        {
            txtmail.Text = mail;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("yasinbulut_25@hotmail.com","şifre");
            client.Port = 587;
            client.Host = "smtp.live.com";
            client.EnableSsl = true;
            message.To.Add(txtmes.Text);
            message.From = new MailAddress("yasinbulut_25@hotmail.com");
            message.Subject = txtsub.Text;
            message.Body = txtmes.Text;
            client.Send(message);

        }
    }
}

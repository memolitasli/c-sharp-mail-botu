using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace mail_botu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string host = " ";
            int port = 0;
                    
            
            if(string.Compare(comboBox1.Text,"gmail") == 0)
            {
                host = "smtp.gmail.com";
                port = 587;

            }
            else if(string.Compare(comboBox1.Text,"outlook") == 0)
            {
                port = 587;
                host = "smtp.live.com";
            }

            for (int i = 0; i < mailler.Items.Count; i++)
            {

                MailMessage msg = new MailMessage();
                SmtpClient istemci = new SmtpClient();
                istemci.Credentials = new System.Net.NetworkCredential(textBox2.Text, textBox3.Text);
                istemci.Port = port;
                istemci.Host = host.Trim();
                istemci.EnableSsl = true;
                msg.To.Add(mailler.Items[i].ToString());
                msg.From = new MailAddress(textBox2.Text);
                msg.Subject = textBox5.Text;
                msg.Body = textBox1.Text;
                istemci.Send(msg);

            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            mailler.Items.Add(textBox4.Text);
        }
    }
}

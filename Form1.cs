using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SprinklerGoes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Password_txt.PasswordChar = '.';
            Password_txt.MaxLength = 12;
        }

        public string Multiply(string source, int multiplier)
        {
            StringBuilder sb = new StringBuilder(multiplier * source.Length);
            for(int i = 0; i< multiplier; i++)
            {
                sb.Append(source);
            }
            return sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                string htmlBody = "";

                Random random = new Random();
                int randomNumber = random.Next(30, 70);
                htmlBody = "Sprinkler goes latch" + Multiply("tch",randomNumber);

                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;

                SmtpServer.Credentials = new System.Net.NetworkCredential(textBox2.Text, Password_txt.Text);
                
                mail.From = new MailAddress(textBox2.Text);
                mail.To.Add(textBox1.Text);

                mail.Subject = "Test Mail";
                mail.IsBodyHtml = true;
                mail.Body = htmlBody;

                SmtpServer.Send(mail);
                MessageBox.Show("Mischieve Managed");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplication_apka_timer
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox2.Items[0];
            comboBox3.SelectedItem = comboBox2.Items[0];
            timer1.Start();
         

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string comboxowy = comboBox1.SelectedItem.ToString() + ":" + comboBox2.SelectedItem.ToString() + ":" + comboBox3.SelectedItem.ToString();
            label3.Text = System.DateTime.Now.ToLongTimeString();

            if (System.DateTime.Now.ToLongTimeString() == comboxowy && button1.Enabled == false)
            {
                procedure("execute agent2214_midmax.dodaj_dzień");
                label4.Text = "Status wykonano procedury";
                sendmail();
                MessageBox.Show("Wykonano procedurę na bazie", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Enabled = true;

            }


        }
   

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Pracuję";
            button1.Enabled = false;
        }

        void sendmail()
        {
            var fromAddress = new MailAddress("email", "Lucjan");
            var toAddress = new MailAddress("email");
            const string fromPassword = "password";
            const string subject = "Psst: skończyłem";
            string body = "Zrobiłęm pracę za Ciebie o: " + System.DateTime.Now.ToString() + "";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
               
            }

        }
   
        void procedure(string x1)
        {
            System.Data.SqlClient.SqlConnection M1conn;
            M1conn = new SqlConnection();
            M1conn.ConnectionString = Properties.Settings.Default.agent;
            M1conn.Open();
            System.Data.SqlClient.SqlCommand M1command = new SqlCommand();
            M1command.Connection = M1conn;
            M1command.CommandText = "" + x1 + "";
            M1command.ExecuteNonQuery();
            M1conn.Close();
        }
      
    

       
    }
}

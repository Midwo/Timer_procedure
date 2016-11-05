using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apka_procedury
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Apka_procedury.Properties.Settings.agent2214_db1portfolioConnectionString"].ConnectionString);
        public Form1()
        {
            InitializeComponent();
            label2.Text = System.DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button1.Text = "Pracuję";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            label2.Text = System.DateTime.Now.ToLongTimeString();
            
            if (System.DateTime.Now.ToLongTimeString() == textBox1.Text)
            {
                klaseprocedure.procedure("execute agent2214_midmax.dodaj_dzień");
                label5.Text = "Status: wykonano procedury";

                klasemail.sendmail();
            }
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9:]"))
            {
                MessageBox.Show("Tylko liczby od 0-9 i :");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}

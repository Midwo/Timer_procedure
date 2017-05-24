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
                claseprocedure.procedure(yourData.executeCommand);

                if (Error.statusError == 1)
                {
                    label5.Text = "Status: wystąpił błąd";
                }
                else
                {
                    label5.Text = "Status: wykonano procedury";
                }

                clasemail.sendmail();
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

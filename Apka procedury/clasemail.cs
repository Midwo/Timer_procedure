using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apka_procedury
{
    class clasemail
    {


        public static void sendmail()
        {


            try
            {
                var fromAddress = new MailAddress(yourData.emailFrom, yourData.describeEmail);
                var toAddress = new MailAddress(yourData.emailTo);
                string fromPassword = yourData.EmailPassword;
                string subject = yourData.Subject;
                string body = "Wykonano procedury: " + System.DateTime.Now.ToString() + "";

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
            catch (Exception ex)
            {
                Error.SaveErrorLogging(ex);
                Error.ReadError();
                MessageBox.Show(ex.Message, "Error");
                Error.statusError = 1;
            }
        }
    }
}

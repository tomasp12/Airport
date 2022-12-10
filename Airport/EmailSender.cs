using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace Airport
{
    public class EmailSender
    {        
        public void EmailSend(string emailBody) 
        {
            using (MailMessage mail = new MailMessage())
            {
                var appSettings = ConfigurationManager.AppSettings;
                mail.From = new MailAddress(appSettings["emailFromAddress"]);
                mail.To.Add(appSettings["emailToAddress"]);
                mail.Subject = "Airplane report";
                mail.Body = emailBody;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {                    
                    smtp.Credentials = new NetworkCredential(appSettings["gmailUsername"], appSettings["gmailPassword"]);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}

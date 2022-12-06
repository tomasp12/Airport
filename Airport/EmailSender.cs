using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Airport
{
    public class EmailSender
    {
        public void EmailSend(string emailBody) 
        {
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("f9cf1f54d7ffea", "d22f8851584625"),
                EnableSsl = true
            };
            client.Send("airplane@gmail.com", "tomyte@gmail.com", "Incoming airplane report", emailBody);
                
        }
    }
}

using Clients.Core.Interfaces;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Utils
{
    public class Emails : IEmail
    {        
        public async Task SendEmail(string from, List<string?> to, string fileName, string path)
        {
            var email = new MailMessage();
            var today = DateTime.Now;
            email.From = new MailAddress(from);
            foreach(var item in to)
            {
                email.To.Add(item);
            }            
            email.Subject = $"Datos de Facturas para emitir del día {today.AddDays(-1).ToString("d")}";
            email.Body = "<h1> Datos para emitir factura del día anterior</h1>";
            email.IsBodyHtml = true;

            var Attachment = new Attachment(fileName);
            email.Attachments.Add(Attachment);

            //send email
            using var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("alastorlml@gmail.com", "tomgnvslmlasrzvu"),
                EnableSsl = true
            };
            await smtp.SendMailAsync (email);
            email.Attachments.Dispose();
            System.IO.File.Delete(Path.Join(path, fileName));
        }
    }
}

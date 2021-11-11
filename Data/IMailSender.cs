using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace ProCivReport.Data
{
    public interface IMailSender
    {
        void Send(List<string> attachments);
    }

    public class MailSender : IMailSender
    {
        public void Send(List<string> attachments)
        {
            try
            {
                var mail = new MailMessage { From = new MailAddress("comunicazioni.vpcc@ennezeta.info") };
                mail.To.Add("info@protezionecivilecalderara.org");
                mail.CC.Add("comunicazione@protezionecivilecalderara.org");
                mail.Bcc.Add("nathan.ilcapitano@gmail.com");

                mail.Subject = $"Monitoraggio Territorio {DateTime.Now:dd/MM/yyyy}";
                mail.IsBodyHtml = true;
                mail.Body = @"Si allega verbale di servizio<br />-------------------<br />VOLONTARI PROTEZIONE CIVILE CALDERARA DI RENO <br />-------------------";
                
                foreach (var attachment in from fileName in attachments where File.Exists(fileName) select new Attachment(fileName))
                    mail.Attachments.Add(attachment);

                var smtp = new SmtpClient("mail.ennezeta.info");

                var credential = new NetworkCredential("comunicazioni.vpcc@ennezeta.info", "Vpcc1982!");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credential;
                smtp.Port = 25;    //alternative port number is 8889
                smtp.EnableSsl = false;
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                var x = e.Message;
            }
        }
    }
}
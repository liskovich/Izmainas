using Izmainas.ConfigOptions;
using Izmainas.Domain;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;

using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace Izmainas.Services
{
    public class EmailSendingService : IEmailSendingService
    {
        private SmtpClient _smtpClient;

        private readonly IOptions<EmailOptions> _emailOptions;
        private readonly IOptions<SmtpOptions> _smtpOptions;
        private readonly IOptions<ApplicationOptions> _appOptions;

        public EmailSendingService(IOptions<EmailOptions> emailOptions, IOptions<SmtpOptions> smtpOptions, IOptions<ApplicationOptions> appOptions)
        {
            _emailOptions = emailOptions;
            _smtpOptions = smtpOptions;
            _appOptions = appOptions;
        }

        private void Config()
        {
            _smtpClient = new SmtpClient();
            _smtpClient.Port = _smtpOptions.Value.Port;
            _smtpClient.Host = _smtpOptions.Value.Host;
            _smtpClient.EnableSsl = true;
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new NetworkCredential(_emailOptions.Value.SenderEmail, _emailOptions.Value.SenderPassword);
        }

        public bool SendMail(string message, string subject, bool htmlBody, List<EmailModel> recipients)
        {
            try
            {
                Config();

                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_emailOptions.Value.SenderEmail);
                
                foreach (var r in recipients)
                {
                    mailMessage.To.Add(r.Email);
                }
                
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = htmlBody;
                mailMessage.Body = message;

                _smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public string GenerateHTMLEmail(List<Record> records)
        {
            string rawHtml = "";

            rawHtml += @"<!DOCTYPE html>";
            rawHtml += @"<html><head>";
            rawHtml += @"<title>Stundu Izmaiņas Email</title>";
            rawHtml += @"<meta charset='utf-8'>";
            rawHtml += @"<style>.card{max-width: 500px;min-width: 300px;border: #dfe8e1 1px solid;box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);border-radius: 5px;margin: 20px auto;}.section {padding-bottom: 0px;padding-top: 5x;padding-left: 10px;padding-right: 10px;}hr {height:1px;border-width:0;color:#dfe8e1;background-color:#dfe8e1;}.subt {font-weight: bold;color: gray;}p {max-width: 480px;}</style>";
            rawHtml += @"</head><body>";

            rawHtml += @"<div style='text-align:center'>";
            rawHtml += @"<h3 style='margin: 20px'>Jaunākie ieraksti</h3>";
            rawHtml += @"<p style='margin:20px auto 40px auto; font-weight:normal; max-width:500px;'>Šodienas datums - " + DateTime.Today.ToString("D") + "</p>";
            rawHtml += @"</div>";

            foreach (var r in records)
            {
                rawHtml += GenerateCard(r);
            }

            rawHtml += @"<div style='text-align:center'>";
            rawHtml += @"<p style='font-weight:normal; margin:40px auto 20px auto; max-width:500px;'>Plašāka informācija <a href='" + _appOptions.Value.WebsiteURL + "'>Stundu izmaiņu mājaslapā</a> vai mobīlajā aplikācijā.</p>"; //https://www.google.com
            rawHtml += @"<p style='font-weight:normal; margin:20px auto; max-width:500px;'>Lai atteiktos no e-pasta ziņojumiem, dodieties uz <a href='" + _appOptions.Value.WebsiteURL + "'>Stundu izmaiņu mājaslapu</a> un sadaļā <b>Noderīgi</b> nospiediet <b>Atteikties no e-pastu ziņojumiem</b></p>";
            rawHtml += @"</div>";
            
            rawHtml += @"</body>";
            rawHtml += @"</html>";
            return rawHtml;
        }

        private string GenerateCard(Record record)
        {
            string rawHtml = "";

            rawHtml += "<div class='card'><div class='container'>";

            rawHtml += "<div class='section' style='height: 50px;'>";
            rawHtml += "<h1>" + record.ClassNumber + ". " + record.ClassLetter + "</h1>";
            rawHtml += "</div><hr><div class='section'><p class='subt'>Piezīme</p>";

            rawHtml += "<p>" + record.Note + "</p>";
            rawHtml += "</div><hr><div class='section'><p class='subt'>Telpa</p>";

            rawHtml += "<p>" + record.Room + "</p>";
            rawHtml += "</div><hr><div class='section'><p class='subt'>Skolotājs/a</p>";

            rawHtml += "<p>" + record.Teacher + "</p>";
            rawHtml += "</div><hr><div class='section'><p class='subt'>Stunda/as</p>";

            rawHtml += "<p>" + record.Lessons + "</p>";
            rawHtml += "</div></div></div>";
            rawHtml += "</body></html>";
            return rawHtml;
        }
    }
}

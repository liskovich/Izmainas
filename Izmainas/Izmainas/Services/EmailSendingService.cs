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
            catch
            {
                return false;
            }
        }

        public string GenerateHTMLEmail(List<Record> records)
        {
            string rawHtml = "";

            rawHtml += @"<!DOCTYPE html>";
            rawHtml += @"<html><head>";
            rawHtml += @"<title>Stundu Izmaiņas</title>";
            rawHtml += @"<meta charset='utf-8'>";
            rawHtml += @"<link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css' integrity='sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z' crossorigin='anonymous'>";
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

            rawHtml += @"<script src='https://code.jquery.com/jquery-3.5.1.slim.min.js' integrity='sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj' crossorigin='anonymous'></script>";
            rawHtml += @"<script src='https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js' integrity='sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN' crossorigin='anonymous'></script>";
            rawHtml += @"<script src='https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js' integrity='sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV' crossorigin='anonymous'></script>";
            rawHtml += @"</body>";
            rawHtml += @"</html>";
            return rawHtml;
        }

        private string GenerateCard(Record record)
        {
            string rawHtml = "";

            rawHtml += @"<div style='max-width:500px; margin:10px auto;'>";
            rawHtml += @"<div class='card h-100 shadow' style='margin: 0px 20px 20px 20px; min-width:300px'>";
            rawHtml += @"<div class='card-header bg-silver'>";
            rawHtml += @"<h4 class='card-title mt-3'>" + record.ClassNumber + ". " + record.ClassLetter + "</h4>";
            rawHtml += @"</div>";

            rawHtml += @"<div class='card-body mt-2'>";
            rawHtml += @"<div class='note-container'>";
            rawHtml += @"<h6 class='card-subtitle mb-2 text-muted'>Piezīme</h6>";
            rawHtml += @"<p class='card-text'>" + record.Note + "</p>";
            rawHtml += @"</div></div>";

            rawHtml += @"<ul class='list-group list-group-flush'>";
            rawHtml += @"<li class='list-group-item mt-2'>";
            rawHtml += @"<div class='row'>";
            rawHtml += @"<div class='align-self-center col-sm-3'>";
            rawHtml += @"<h6 class='card-subtitle text-muted'>Telpa</h6></div>";
            rawHtml += @"<div class='col-sm-9'>";
            rawHtml += @"<p class='card-text'>" + record.Room + "</p>";
            rawHtml += @"</div></div></li>";

            rawHtml += @"<li class='list-group-item mt-2'>";
            rawHtml += @"<div class='row'>";
            rawHtml += @"<div class='col-sm-3 align-self-center'>";
            rawHtml += @"<h6 class='card-subtitle text-muted'>Skolotājs/a</h6></div>";
            rawHtml += @"<div class='col-sm-9'>";
            rawHtml += @"<p class='card-text'>" + record.Teacher + "</p>";
            rawHtml += @"</div></div></li>";

            rawHtml += @"<li class='list-group-item mt-2'>";
            rawHtml += @"<div class='row'>";
            rawHtml += @"<div class='col-sm-3 align-self-center'>";
            rawHtml += @"<h6 class='card-subtitle text-muted'>Stunda/as</h6></div>";
            rawHtml += @"<div class='col-sm-9'>";
            rawHtml += @"<p class='card-text'>" + record.Lessons + "</p>";
            rawHtml += @"</div></div></li>";

            rawHtml += @"</ul></div></div>";
            return rawHtml;
        }
    }
}

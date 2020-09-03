using Izmainas.Domain;
using System.Collections.Generic;

namespace Izmainas.Services
{
    public interface IEmailSendingService
    {
        bool SendMail(string message, string subject, bool htmlBody, string recipient); //, List<EmailModel> recipients
        string GenerateHTMLEmail(List<Record> records, DeleteEmailModel emailModel);
        string GenerateVerificationEmail(string email, string vkey);
    }
}
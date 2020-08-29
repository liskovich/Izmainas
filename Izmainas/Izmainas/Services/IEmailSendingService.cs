using Izmainas.Domain;
using System.Collections.Generic;

namespace Izmainas.Services
{
    public interface IEmailSendingService
    {
        bool SendMail(string message, string subject, bool htmlBody, List<EmailModel> recipients);
        string GenerateHTMLEmail(List<Record> records);
        string GenerateVerificationEmail(string email, string vkey);
    }
}
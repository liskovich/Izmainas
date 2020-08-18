using Izmainas.Domain;
using System;
using System.Collections.Generic;

namespace Izmainas.Services
{
    public interface IEmailDataService
    {
        bool CreateEmailModel(EmailModel emailModel);
        bool DeleteEmailModel(string email);
        EmailModel GetEmailModelByEmail(string email);
        EmailModel GetEmailModelById(Guid modelId);
        List<EmailModel> GetEmailModels();
    }
}
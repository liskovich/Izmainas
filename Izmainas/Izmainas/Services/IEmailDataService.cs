using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Izmainas.Services
{
    public interface IEmailDataService
    {
        Task<bool> CreateEmailModel(EmailModel emailModel);
        Task<bool> DeleteEmailModel(DeleteEmailModel emailModel); // string email
        Task<EmailModel> GetEmailModelByEmail(string email);
        Task<EmailModel> GetEmailModelById(Guid modelId);
        Task<List<EmailModel>> GetEmailModels();
    }
}
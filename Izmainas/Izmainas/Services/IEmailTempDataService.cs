using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Izmainas.Services
{
    public interface IEmailTempDataService
    {
        Task<bool> CreateTempEmailModel(EmailModel emailModel);
        Task<bool> DeleteTempEmailModels();
        Task<EmailModel> GetTempEmailModelByEmail(string email);
        Task<EmailModel> GetTempEmailModelById(Guid modelId);
        Task<List<EmailModel>> GetTempEmailModels();
        Task<bool> VerifyTempEmailModel(string email);
    }
}
using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Izmainas.Services
{
    public interface IEmailTempDataService
    {
        Task<bool> CreateTempEmailModel(EmailTempModel emailModel);
        Task<bool> DeleteTempEmailModels();
        Task<EmailTempModel> GetTempEmailModelByEmail(string email);
        Task<EmailTempModel> GetTempEmailModelById(Guid modelId);
        Task<List<EmailTempModel>> GetTempEmailModels();
        Task<bool> VerifyTempEmailModel(string email, string vkey);
    }
}
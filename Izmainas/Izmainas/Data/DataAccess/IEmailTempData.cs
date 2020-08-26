using Izmainas.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Izmainas.Data.DataAccess
{
    public interface IEmailTempData
    {
        Task DeleteTempEmails();
        Task<List<DbEmailModel>> GetTempEmailByEmail(string emailText);
        Task<List<DbEmailModel>> GetTempEmailById(string emailId);
        Task<List<DbEmailModel>> GetTempEmails();
        Task SaveTempEmail(DbEmailModel emailModel);
        Task VerifyTempEmails(string emailText);
    }
}
using Izmainas.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Izmainas.Data.DataAccess
{
    public interface IEmailTempData
    {
        Task DeleteTempEmails();
        Task<List<DbEmailTempModel>> GetTempEmailByEmail(string emailText);
        Task<List<DbEmailTempModel>> GetTempEmailById(string emailId);
        Task<List<DbEmailTempModel>> GetTempEmails();
        Task SaveTempEmail(DbEmailTempModel emailModel);
        Task VerifyTempEmails(string emailVerificationToken);
    }
}
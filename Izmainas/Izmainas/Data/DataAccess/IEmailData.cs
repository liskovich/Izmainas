using Izmainas.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Izmainas.Data.DataAccess
{
    public interface IEmailData
    {
        Task DeleteEmail(string emailText);
        Task<List<DbEmailModel>> GetEmailByEmail(string emailText);
        Task<List<DbEmailModel>> GetEmailById(string emailId);
        Task<List<DbEmailModel>> GetEmails();
        Task SaveEmail(DbEmailModel emailModel);
    }
}
using Izmainas.Domain;
using System.Collections.Generic;

namespace Izmainas.Data.DataAccess
{
    public interface IEmailData
    {
        void DeleteEmail(string Email);
        List<DbEmailModel> GetEmailByEmail(string Email);
        List<DbEmailModel> GetEmailById(string Id);
        List<DbEmailModel> GetEmails();
        void SaveEmail(DbEmailModel emailModel);
    }
}
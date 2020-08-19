using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Data.DataAccess
{
    public class EmailData : IEmailData
    {
        private readonly ISqlDataAccess _sql;

        public EmailData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public List<DbEmailModel> GetEmails()
        {
            var output = _sql.LoadData<DbEmailModel, dynamic>("dbo.spEmails_GetAll", new { }, "IzmainasDB");
            return output;
        }

        public List<DbEmailModel> GetEmailById(string Id)
        {
            var output = _sql.LoadData<DbEmailModel, dynamic>("dbo.spEmails_GetById", new { Id }, "IzmainasDB");
            return output;
        }

        public List<DbEmailModel> GetEmailByEmail(string Email)
        {
            var output = _sql.LoadData<DbEmailModel, dynamic>("dbo.spEmails_GetByEmail", new { Email }, "IzmainasDB");
            return output;
        }

        public void SaveEmail(DbEmailModel emailModel)
        {
            _sql.SaveData("dbo.spEmails_Insert", emailModel, "IzmainasDB");
        }

        public void DeleteEmail(string Email)
        {
            _sql.SaveData("dbo.spEmails_Delete", Email, "IzmainasDB");
        }
    }
}

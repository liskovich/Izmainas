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
        private readonly IMySqlDataAccess _mySql;

        public EmailData(ISqlDataAccess sql, IMySqlDataAccess mySql)
        {
            _sql = sql;
            _mySql = mySql;
        }

        public async Task<List<DbEmailModel>> GetEmails()
        {
            /*
            var output = _sql.LoadData<DbEmailModel, dynamic>("dbo.spEmails_GetAll", new { }, "IzmainasDB");
            return output;
            */

            var output = await _mySql.LoadData<DbEmailModel, dynamic>("spEmails_GetAll", new { }, "Default");
            return output;
        }

        public async Task<List<DbEmailModel>> GetEmailById(string emailId)
        {
            /*
            var output = _sql.LoadData<DbEmailModel, dynamic>("dbo.spEmails_GetById", new { Id }, "IzmainasDB");
            return output;
            */

            var output = await _mySql.LoadData<DbEmailModel, dynamic>("spEmails_GetById", new { emailId }, "Default");
            return output;
        }

        public async Task<List<DbEmailModel>> GetEmailByEmail(string emailText)
        {
            var output = await _mySql.LoadData<DbEmailModel, dynamic>("spEmails_GetByEmail", new { emailText }, "Default");
            return output;
        }

        public async Task SaveEmail(DbEmailModel emailModel)
        {
            string emailId = emailModel.Id;
            string emailText = emailModel.Email;
            DateTime emailCratedDate = emailModel.CreatedDate;

            await _mySql.SaveData("spEmails_Insert", new { emailId, emailText, emailCratedDate }, "Default");
        }

        public async Task DeleteEmail(string emailText)
        {
            await _mySql.SaveData("spEmails_Delete", new { emailText }, "Default");
        }
    }
}

using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Data.DataAccess
{
    public class EmailTempData : IEmailTempData
    {
        private readonly IMySqlDataAccess _mySql;

        public EmailTempData(IMySqlDataAccess mySql)
        {
            _mySql = mySql;
        }

        public async Task<List<DbEmailModel>> GetTempEmails()
        {
            var output = await _mySql.LoadData<DbEmailModel, dynamic>("spEmailsTemp_GetAll", new { }, "Default");
            return output;
        }

        public async Task<List<DbEmailModel>> GetTempEmailById(string emailId)
        {
            var output = await _mySql.LoadData<DbEmailModel, dynamic>("spEmailsTemp_GetById", new { emailId }, "Default");
            return output;
        }

        public async Task<List<DbEmailModel>> GetTempEmailByEmail(string emailText)
        {
            var output = await _mySql.LoadData<DbEmailModel, dynamic>("spEmailsTemp_GetByEmail", new { emailText }, "Default");
            return output;
        }

        public async Task SaveTempEmail(DbEmailModel emailModel)
        {
            string emailId = emailModel.Id;
            string emailText = emailModel.Email;
            DateTime emailCratedDate = emailModel.CreatedDate;

            await _mySql.SaveData("spEmailsTemp_Insert", new { emailId, emailText, emailCratedDate }, "Default");
        }

        public async Task DeleteTempEmails()
        {
            await _mySql.SaveData("spEmailsTemp_DeleteAll", new { }, "Default");
        }

        public async Task VerifyTempEmails(string emailText)
        {
            await _mySql.SaveData("trEmailsTemp_VerifyEmail", new { emailText }, "Default");
        }
    }
}

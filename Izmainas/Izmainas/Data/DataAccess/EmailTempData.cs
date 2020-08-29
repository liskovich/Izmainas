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

        public async Task<List<DbEmailTempModel>> GetTempEmails()
        {
            var output = await _mySql.LoadData<DbEmailTempModel, dynamic>("spEmailsTemp_GetAll", new { }, "Default");
            return output;
        }

        public async Task<List<DbEmailTempModel>> GetTempEmailById(string emailId)
        {
            var output = await _mySql.LoadData<DbEmailTempModel, dynamic>("spEmailsTemp_GetById", new { emailId }, "Default");
            return output;
        }

        public async Task<List<DbEmailTempModel>> GetTempEmailByEmail(string emailText)
        {
            var output = await _mySql.LoadData<DbEmailTempModel, dynamic>("spEmailsTemp_GetByEmail", new { emailText }, "Default");
            return output;
        }

        public async Task SaveTempEmail(DbEmailTempModel emailModel)
        {
            string emailId = emailModel.Id;
            string emailText = emailModel.Email;
            DateTime emailCratedDate = emailModel.CreatedDate;
            string emailVerificationToken = emailModel.VerificationKey;

            await _mySql.SaveData("spEmailsTemp_Insert", new { emailId, emailText, emailCratedDate, emailVerificationToken }, "Default");
        }

        public async Task DeleteTempEmails()
        {
            await _mySql.SaveData("spEmailsTemp_DeleteAll", new { }, "Default");
        }

        public async Task VerifyTempEmails(string emailVerificationToken)
        {
            await _mySql.SaveData("trEmailsTemp_VerifyEmail", new { emailVerificationToken }, "Default");
        }
    }
}

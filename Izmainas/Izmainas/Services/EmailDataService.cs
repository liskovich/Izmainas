using Izmainas.Data.DataAccess;
using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Services
{
    public class EmailDataService : IEmailDataService
    {
        private readonly IEmailData _emailData;

        public EmailDataService(IEmailData emailData)
        {
            _emailData = emailData;
        }

        public async Task<bool> CreateEmailModel(EmailModel emailModel)
        {
            try
            {
                var existing = await _emailData.GetEmailByEmail(emailModel.Email);
                var item = existing.FirstOrDefault();
                if (item != null)
                {
                    return false;
                }

                var saveEmailModel = new DbEmailModel
                {
                    Id = emailModel.Id.ToString(),
                    Email = emailModel.Email,
                    CreatedDate = emailModel.CreatedDate
                };

                await _emailData.SaveEmail(saveEmailModel);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmailModel(string email)
        {
            try
            {
                var existing = await _emailData.GetEmailByEmail(email);
                var item = existing.FirstOrDefault();
                if (item != null)
                {
                    return false;
                }

                await _emailData.DeleteEmail(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<EmailModel> GetEmailModelById(Guid modelId)
        {
            try
            {
                var findId = modelId.ToString();
                var found = await _emailData.GetEmailById(findId);
                var item = found.FirstOrDefault();
                if (item == null)
                {
                    return null;
                }

                var emailModel = new EmailModel
                {
                    Id = modelId,
                    Email = item.Email,
                    CreatedDate = item.CreatedDate
                };
                return emailModel;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<EmailModel>> GetEmailModels()
        {
            try
            {
                var found = await _emailData.GetEmails();
                if (found == null)
                {
                    return null;
                }

                var emails = new List<EmailModel>();
                foreach (var e in found)
                {
                    var email = new EmailModel
                    {
                        Id = Guid.Parse(e.Id),
                        Email = e.Email,
                        CreatedDate = e.CreatedDate
                    };
                    emails.Add(email);
                }
                return emails;
            }
            catch
            {
                return null;
            }
        }

        public async Task<EmailModel> GetEmailModelByEmail(string email)
        {
            try
            {
                var found = await _emailData.GetEmailByEmail(email);
                var item = found.FirstOrDefault();
                if (item == null)
                {
                    return null;
                }

                var emailModel = new EmailModel
                {
                    Id = Guid.Parse(item.Id),
                    Email = email,
                    CreatedDate = item.CreatedDate
                };
                return emailModel;
            }
            catch
            {
                return null;
            }
        }
    }
}

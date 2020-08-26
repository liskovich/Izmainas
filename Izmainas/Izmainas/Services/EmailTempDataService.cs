using Izmainas.Data.DataAccess;
using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Services
{
    public class EmailTempDataService : IEmailTempDataService
    {
        private readonly IEmailTempData _emailTempData;

        public EmailTempDataService(IEmailTempData emailTempData)
        {
            _emailTempData = emailTempData;
        }

        public async Task<bool> CreateTempEmailModel(EmailModel emailModel)
        {
            try
            {
                var existing = await _emailTempData.GetTempEmailByEmail(emailModel.Email);
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

                await _emailTempData.SaveTempEmail(saveEmailModel);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteTempEmailModels()
        {
            try
            {
                await _emailTempData.DeleteTempEmails();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<EmailModel> GetTempEmailModelById(Guid modelId)
        {
            try
            {
                var findId = modelId.ToString();
                var found = await _emailTempData.GetTempEmailById(findId);
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

        public async Task<List<EmailModel>> GetTempEmailModels()
        {
            try
            {
                var found = await _emailTempData.GetTempEmails();
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

        public async Task<EmailModel> GetTempEmailModelByEmail(string email)
        {
            try
            {
                var found = await _emailTempData.GetTempEmailByEmail(email);
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

        public async Task<bool> VerifyTempEmailModel(string email)
        {
            try
            {
                var found = await _emailTempData.GetTempEmailByEmail(email);
                var item = found.FirstOrDefault();
                if(item == null)
                {
                    return false;
                }

                await _emailTempData.VerifyTempEmails(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

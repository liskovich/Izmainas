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
        private readonly IEmailData _emailData;

        public EmailTempDataService(IEmailTempData emailTempData, IEmailData emailData)
        {
            _emailTempData = emailTempData;
            _emailData = emailData;
        }

        public async Task<bool> CreateTempEmailModel(EmailTempModel emailModel)
        {
            try
            {
                var existingtemp = await _emailTempData.GetTempEmailByEmail(emailModel.Email);
                var itemtemp = existingtemp.FirstOrDefault();
                if (itemtemp != null)
                {
                    return false;
                }

                var existing = await _emailData.GetEmailByEmail(emailModel.Email);
                var item = existing.FirstOrDefault();
                if (item != null)
                {
                    return false;
                }

                var saveEmailModel = new DbEmailTempModel
                {
                    Id = emailModel.Id.ToString(),
                    Email = emailModel.Email,
                    CreatedDate = emailModel.CreatedDate,
                    VerificationKey = emailModel.VerificationKey
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

        public async Task<EmailTempModel> GetTempEmailModelById(Guid modelId)
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

                var emailModel = new EmailTempModel
                {
                    Id = modelId,
                    Email = item.Email,
                    CreatedDate = item.CreatedDate,
                    VerificationKey = item.VerificationKey
                };
                return emailModel;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<EmailTempModel>> GetTempEmailModels()
        {
            try
            {
                var found = await _emailTempData.GetTempEmails();
                if (found == null)
                {
                    return null;
                }

                var emails = new List<EmailTempModel>();
                foreach (var e in found)
                {
                    var email = new EmailTempModel
                    {
                        Id = Guid.Parse(e.Id),
                        Email = e.Email,
                        CreatedDate = e.CreatedDate,
                        VerificationKey = e.VerificationKey
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

        public async Task<EmailTempModel> GetTempEmailModelByEmail(string email)
        {
            try
            {
                var found = await _emailTempData.GetTempEmailByEmail(email);
                var item = found.FirstOrDefault();
                if (item == null)
                {
                    return null;
                }

                var emailModel = new EmailTempModel
                {
                    Id = Guid.Parse(item.Id),
                    Email = email,
                    CreatedDate = item.CreatedDate,
                    VerificationKey = item.VerificationKey
                };
                return emailModel;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> VerifyTempEmailModel(string email, string vkey)
        {
            try
            {
                var found = await _emailTempData.GetTempEmailByEmail(email);
                var item = found.FirstOrDefault();
                if(item == null)
                {
                    return false;
                }

                await _emailTempData.VerifyTempEmails(vkey);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

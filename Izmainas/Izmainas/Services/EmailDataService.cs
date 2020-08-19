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

        public bool CreateEmailModel(EmailModel emailModel)
        {
            try
            {
                var existing = _emailData.GetEmailByEmail(emailModel.Email).FirstOrDefault();
                if (existing != null)
                {
                    return false;
                }

                var saveEmailModel = new DbEmailModel
                {
                    Id = emailModel.Id.ToString(),
                    Email = emailModel.Email,
                    CreatedDate = emailModel.CreatedDate
                };

                _emailData.SaveEmail(saveEmailModel);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteEmailModel(string email)
        {
            try
            {
                var existing = _emailData.GetEmailByEmail(email).FirstOrDefault();
                if (existing == null)
                {
                    return false;
                }

                _emailData.DeleteEmail(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public EmailModel GetEmailModelById(Guid modelId)
        {
            try
            {
                var findId = modelId.ToString();
                var found = _emailData.GetEmailById(findId).FirstOrDefault();
                if (found == null)
                {
                    return null;
                }

                var emailModel = new EmailModel
                {
                    Id = modelId,
                    Email = found.Email,
                    CreatedDate = found.CreatedDate
                };
                return emailModel;
            }
            catch
            {
                return null;
            }
        }

        public List<EmailModel> GetEmailModels()
        {
            try
            {
                var found = _emailData.GetEmails();
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

        public EmailModel GetEmailModelByEmail(string email)
        {
            try
            {
                var found = _emailData.GetEmailByEmail(email).FirstOrDefault();
                if (found == null)
                {
                    return null;
                }

                var emailModel = new EmailModel
                {
                    Id = Guid.Parse(found.Id),
                    Email = email,
                    CreatedDate = found.CreatedDate
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

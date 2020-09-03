using Izmainas.Contracts.v1;
using Izmainas.Contracts.v1.Requests;
using Izmainas.Contracts.v1.Responses;
using Izmainas.Domain;
using Izmainas.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Controllers.v1
{
    public class EmailTempDataController : Controller
    {
        private readonly IEmailTempDataService _emailTempDataService;
        private readonly IEmailSendingService _emailSendingService;

        public EmailTempDataController(IEmailTempDataService emailTempDataService, IEmailSendingService emailSendingService)
        {
            _emailTempDataService = emailTempDataService;
            _emailSendingService = emailSendingService;
        }

        #region Production Actions

        [HttpPost(ApiRoutes.VerificationEmailClientData.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEmailModelRequest request)
        {
            // TODO - fix issue, when trying to imput an email that already exists in the database, it throws an exception
            var emailModel = new EmailTempModel
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                CreatedDate = request.CreatedDate,
                VerificationKey = Guid.NewGuid().ToString() //Convert.ToBase64String(Guid.NewGuid().ToByteArray())
            };

            var created = await _emailTempDataService.CreateTempEmailModel(emailModel);
            if (created == false)
            {
                return BadRequest();
            }

            // TODO - here the server should send a confirmation email
            var verificationMessage = _emailSendingService.GenerateVerificationEmail(emailModel.Email, emailModel.VerificationKey);
            /*
            var recipients = new List<EmailModel>
            {
                new EmailModel
                {
                    Id = emailModel.Id,
                    Email = emailModel.Email,
                    CreatedDate = emailModel.CreatedDate
                }
            };
            */

            _emailSendingService.SendMail(verificationMessage, "E-pasta verifikācija", true, emailModel.Email); //recipients
            // end of send

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.VerificationEmailClientData.Get.Replace("{modelId}", emailModel.Id.ToString());

            var response = new EmailModelResponse { Id = emailModel.Id };
            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.VerificationEmailClientData.DeleteAll)]
        public async Task<IActionResult> Delete() //[FromRoute] string email
        {
            var deleted = await _emailTempDataService.DeleteTempEmailModels();
            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost(ApiRoutes.VerificationEmailClientData.Verify)]
        public async Task<IActionResult> Verify([FromBody] VerifyEmailModelRequest request) //[FromRoute] string email, [FromRoute] string vkey
        {
            var verified = await _emailTempDataService.VerifyTempEmailModel(request.Email, request.VerificationKey);
            if(verified == false)
            {
                return BadRequest();
            }

            return Ok();
        }

        #endregion

        #region Test/Development Actions

        [HttpGet(ApiRoutes.VerificationEmailClientData.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _emailTempDataService.GetTempEmailModels());
        }

        [HttpGet(ApiRoutes.VerificationEmailClientData.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid modelId)
        {
            var emailModel = await _emailTempDataService.GetTempEmailModelById(modelId);
            if (emailModel == null)
            {
                return NotFound();
            }

            return Ok(emailModel);
        }

        [HttpGet(ApiRoutes.VerificationEmailClientData.Email)]
        public async Task<IActionResult> GetByEmail([FromRoute] string email)
        {
            var emailModel = await _emailTempDataService.GetTempEmailModelByEmail(email);
            if (emailModel == null)
            {
                return NotFound();
            }

            return Ok(emailModel);
        }

        #endregion
    }
}

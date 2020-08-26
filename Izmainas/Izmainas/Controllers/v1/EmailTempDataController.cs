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

        public EmailTempDataController(IEmailTempDataService emailTempDataService)
        {
            _emailTempDataService = emailTempDataService;
        }

        #region Production Actions

        [HttpPost(ApiRoutes.VerificationEmailClientData.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEmailModelRequest request)
        {
            // TODO - fix issue, when trying to imput an email that already exists in the database, it throws an exception
            var emailModel = new EmailModel
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                CreatedDate = request.CreatedDate
            };

            var created = await _emailTempDataService.CreateTempEmailModel(emailModel);
            if (created == false)
            {
                return NotFound();
            }

            // TODO - here the server should send a confirmation email

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.VerificationEmailClientData.Get.Replace("{modelId}", emailModel.Id.ToString());

            var response = new EmailModelResponse { Id = emailModel.Id };
            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.VerificationEmailClientData.DeleteAll)]
        public async Task<IActionResult> Delete() //[FromRoute] string email
        {
            var deleted = await _emailTempDataService.DeleteTempEmailModels();
            if (deleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost(ApiRoutes.VerificationEmailClientData.Verify)]
        public async Task<IActionResult> Verify([FromRoute] string email)
        {
            var verified = await _emailTempDataService.VerifyTempEmailModel(email);
            if(verified == false)
            {
                return NotFound();
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

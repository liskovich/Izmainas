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
    public class EmailClientDataController : Controller
    {
        private readonly IEmailDataService _emailDataService;

        public EmailClientDataController(IEmailDataService emailDataService)
        {
            _emailDataService = emailDataService;
        }

        #region Production Actions

        [HttpDelete(ApiRoutes.EmailClientData.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string email) // // [FromBody] DeleteEmailModelRequest request
        {
            var toDelete = await _emailDataService.GetEmailModelByEmail(email);
            if(toDelete == null)
            {
                return NotFound();
            }
            
            var emailModel = new DeleteEmailModel
            {
                Email = email,
                CreatedDate = toDelete.CreatedDate
            };
            var deleted = await _emailDataService.DeleteEmailModel(emailModel); // email
            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        #endregion

        #region Test/Development Actions

        [HttpPost(ApiRoutes.EmailClientData.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEmailModelRequest request)
        {
            var emailModel = new EmailModel
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                CreatedDate = request.CreatedDate
            };

            var created = await _emailDataService.CreateEmailModel(emailModel);
            if (created == false)
            {
                return BadRequest();
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.EmailClientData.Get.Replace("{modelId}", emailModel.Id.ToString());

            var response = new EmailModelResponse { Id = emailModel.Id };
            return Created(locationUri, response);
        }

        [HttpGet(ApiRoutes.EmailClientData.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _emailDataService.GetEmailModels());
        }

        [HttpGet(ApiRoutes.EmailClientData.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid modelId)
        {
            var emailModel = await _emailDataService.GetEmailModelById(modelId);
            if (emailModel == null)
            {
                return NotFound();
            }

            return Ok(emailModel);
        }

        #endregion

    }
}

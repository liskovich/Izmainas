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
    public class EmailAdminDataController : Controller
    {
        private readonly IEmailDataService _emailDataService;

        public EmailAdminDataController(IEmailDataService emailDataService)
        {
            _emailDataService = emailDataService;
        }

        #region Production Actions

        [HttpGet(ApiRoutes.EmailAdminData.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _emailDataService.GetEmailModels());
        }

        [HttpGet(ApiRoutes.EmailAdminData.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid modelId)
        {
            var emailModel = await _emailDataService.GetEmailModelById(modelId);
            if(emailModel == null)
            {
                return NotFound();
            }

            return Ok(emailModel);
        }

        [HttpPost(ApiRoutes.EmailAdminData.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEmailModelRequest request)
        {
            // TODO - fix issue, when trying to imput an email that already exists in the database, it throws an exception
            var emailModel = new EmailModel
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                CreatedDate = request.CreatedDate
            };

            var created = await _emailDataService.CreateEmailModel(emailModel);
            if(created == false)
            {
                return NotFound();
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.EmailAdminData.Get.Replace("{modelId}", emailModel.Id.ToString());

            var response = new EmailModelResponse { Id = emailModel.Id };
            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.EmailAdminData.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string email)
        {
            var deleted = await _emailDataService.DeleteEmailModel(email);
            if(deleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet(ApiRoutes.EmailAdminData.Email)]
        public async Task<IActionResult> GetByEmail([FromRoute] string email)
        {
            var emailModel = await _emailDataService.GetEmailModelByEmail(email);
            if(emailModel == null)
            {
                return NotFound();
            }

            return Ok(emailModel);
        }

        #endregion
    }
}

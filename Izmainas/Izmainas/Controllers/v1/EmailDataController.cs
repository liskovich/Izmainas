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
    public class EmailDataController : Controller
    {
        private readonly IEmailDataService _emailDataService;

        public EmailDataController(IEmailDataService emailDataService)
        {
            _emailDataService = emailDataService;
        }

        #region Production Actions

        [HttpGet(ApiRoutes.EmailData.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_emailDataService.GetEmailModels());
        }

        [HttpGet(ApiRoutes.EmailData.Get)]
        public IActionResult Get([FromRoute] Guid modelId)
        {
            var emailModel = _emailDataService.GetEmailModelById(modelId);
            if(emailModel == null)
            {
                return NotFound();
            }

            return Ok(emailModel);
        }

        [HttpPost(ApiRoutes.EmailData.Create)]
        public IActionResult Create([FromBody] CreateEmailModelRequest request)
        {
            var emailModel = new EmailModel
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                CreatedDate = request.CreatedDate
            };

            var created = _emailDataService.CreateEmailModel(emailModel);
            if(created == false)
            {
                return NotFound();
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.EmailData.Get.Replace("{modelId}", emailModel.Id.ToString());

            var response = new EmailModelResponse { Id = emailModel.Id };
            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.EmailData.Delete)]
        public IActionResult Delete([FromRoute] string email)
        {
            var deleted = _emailDataService.DeleteEmailModel(email);
            if(deleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet(ApiRoutes.EmailData.Email)]
        public IActionResult GetByEmail([FromRoute] string email)
        {
            var emailModel = _emailDataService.GetEmailModelByEmail(email);
            if(emailModel == null)
            {
                return NotFound();
            }

            return Ok(emailModel);
        }

        #endregion
    }
}

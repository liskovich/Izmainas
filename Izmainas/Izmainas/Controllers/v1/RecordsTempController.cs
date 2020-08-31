using Izmainas.Cache;
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
    public class RecordsTempController : Controller
    {
        private readonly IRecordTempService _recordTempService;
        private readonly IEmailDataService _emailDataService;
        private readonly IEmailSendingService _emailSendingService;

        public RecordsTempController(IRecordTempService recordTempService, IEmailDataService emailDataService, IEmailSendingService emailSendingService)
        {
            _recordTempService = recordTempService;
            _emailDataService = emailDataService;
            _emailSendingService = emailSendingService;
        }

        #region Production Actions

        [HttpGet(ApiRoutes.TempRecords.GetAll)]
        //[Cached(600)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _recordTempService.GetTempRecords());
        }

        [HttpGet(ApiRoutes.TempRecords.Get)]
        //[Cached(600)]
        public async Task<IActionResult> Get([FromRoute] Guid recordId)
        {
            var record = await _recordTempService.GetTempRecordById(recordId);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost(ApiRoutes.TempRecords.Create)]
        public async Task<IActionResult> Create([FromBody] CreateRecordRequest request)
        {
            var record = new Record
            {
                Id = Guid.NewGuid(),
                Teacher = request.Teacher,
                Room = request.Room,
                Note = request.Note,
                ClassNumber = request.ClassNumber,
                ClassLetter = request.ClassLetter,
                Lessons = request.Lessons,
                Date = request.Date
            };

            var created = await _recordTempService.CreateTempRecord(record);
            if (created == false)
            {
                return BadRequest();
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.TempRecords.Get.Replace("{recordId}", record.Id.ToString());

            var response = new RecordResponse { Id = record.Id };
            return Created(locationUri, response);
        }

        [HttpPut(ApiRoutes.TempRecords.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid recordId, [FromBody] UpdateRecordRequest request)
        {
            var record = await _recordTempService.GetTempRecordById(recordId);
            if (record == null)
            {
                return NotFound();
            }

            record.Teacher = request.Teacher;
            record.Room = request.Room;
            record.Note = request.Note;
            record.ClassNumber = request.ClassNumber;
            record.ClassLetter = request.ClassLetter;
            record.Lessons = request.Lessons;
            record.Date = request.Date;

            var updated = await _recordTempService.UpdateTempRecord(record);
            if (updated == false)
            {
                return BadRequest();
            }

            return Ok(record);
        }

        [HttpDelete(ApiRoutes.TempRecords.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid recordId)
        {
            var deleted = await _recordTempService.DeleteTempRecord(recordId);
            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost(ApiRoutes.TempRecords.Transfer)]
        public async Task<IActionResult> PublishTransfer()
        {
            var emails = await _emailDataService.GetEmailModels();
            if(emails == null)
            {
                return NotFound();
            }

            var records = await _recordTempService.GetTempRecords();
            if(records == null)
            {
                return NotFound();
            }

            var htmlEmailMessage = _emailSendingService.GenerateHTMLEmail(records);
            _emailSendingService.SendMail(htmlEmailMessage, "Jaunas stundu izmaiņas", true, emails);

            var transfered = await _recordTempService.TransferChanges();
            if (transfered == false)
            {
                return BadRequest();
            }

            return Ok();
        }

        #endregion
    }
}

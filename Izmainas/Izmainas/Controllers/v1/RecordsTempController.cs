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
        public IActionResult GetAll()
        {
            return Ok(_recordTempService.GetTempRecords());
        }

        [HttpGet(ApiRoutes.TempRecords.Get)]
        public IActionResult Get([FromRoute] Guid recordId)
        {
            var record = _recordTempService.GetTempRecordById(recordId);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost(ApiRoutes.TempRecords.Create)]
        public IActionResult Create([FromBody] CreateRecordRequest request)
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

            var created = _recordTempService.CreateTempRecord(record);
            if (created == false)
            {
                return NotFound();
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.TempRecords.Get.Replace("{recordId}", record.Id.ToString());

            var response = new RecordResponse { Id = record.Id };
            return Created(locationUri, response);
        }

        [HttpPut(ApiRoutes.TempRecords.Update)]
        public IActionResult Update([FromRoute] Guid recordId, [FromBody] UpdateRecordRequest request)
        {
            var record = _recordTempService.GetTempRecordById(recordId);
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

            var updated = _recordTempService.UpdateTempRecord(record);
            if (updated == false)
            {
                return NotFound();
            }

            return Ok(record);
        }

        [HttpDelete(ApiRoutes.TempRecords.Delete)]
        public IActionResult Delete([FromRoute] Guid recordId)
        {
            var deleted = _recordTempService.DeleteTempRecord(recordId);
            if (deleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost(ApiRoutes.TempRecords.Transfer)]
        public IActionResult PublishTransfer()
        {
            var emails = _emailDataService.GetEmailModels();
            if(emails == null)
            {
                return NotFound();
            }

            var records = _recordTempService.GetTempRecords();
            if(records == null)
            {
                return NotFound();
            }

            var htmlEmailMessage = _emailSendingService.GenerateHTMLEmail(records);
            _emailSendingService.SendMail(htmlEmailMessage, "Jaunas stundu izmaiņas", true, emails);

            var transfered = _recordTempService.TransferChanges();
            if (transfered == false)
            {
                return NotFound();
            }

            return Ok();
        }

        #endregion
    }
}

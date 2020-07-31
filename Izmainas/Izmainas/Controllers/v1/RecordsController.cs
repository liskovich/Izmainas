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
    public class RecordsController : Controller
    {
        private readonly IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet(ApiRoutes.Records.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_recordService.GetRecords());
        }

        [HttpGet(ApiRoutes.Records.Get)]
        public IActionResult Get([FromRoute] Guid recordId)
        {
            var record = _recordService.GetRecordById(recordId);
            if(record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost(ApiRoutes.Records.Create)]
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

            var created = _recordService.CreateRecord(record);
            if(created == false)
            {
                return NotFound();
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Records.Get.Replace("{recordId}", record.Id.ToString());

            var response = new RecordResponse { Id = record.Id };
            return Created(locationUri, response);
        }

        [HttpPut(ApiRoutes.Records.Update)]
        public IActionResult Update([FromRoute] Guid recordId, [FromBody] UpdateRecordRequest request)
        {
            var record = _recordService.GetRecordById(recordId);
            if(record == null)
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

            var updated = _recordService.UpdateRecord(record);
            if(updated == false)
            {
                return NotFound();
            }

            return Ok(record);
        }

        [HttpDelete(ApiRoutes.Records.Delete)]
        public IActionResult Delete([FromRoute] Guid recordId)
        {
            var deleted = _recordService.DeleteRecord(recordId);
            if(deleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet(ApiRoutes.Records.Date)]
        public IActionResult GetByDate([FromRoute] DateTime recordDate)
        {
            return Ok(_recordService.GetRecordByDate(recordDate));
        }
    }
}

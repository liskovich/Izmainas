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
    public class RecordsAdminController : Controller
    {
        private readonly IRecordService _recordService;

        public RecordsAdminController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        #region Production Actions

        [HttpGet(ApiRoutes.AdminRecords.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _recordService.GetRecords());
        }

        [HttpGet(ApiRoutes.AdminRecords.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid recordId)
        {
            var record = await _recordService.GetRecordById(recordId);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost(ApiRoutes.AdminRecords.Create)]
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

            var created = await _recordService.CreateRecord(record);
            if (created == false)
            {
                return BadRequest();
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.AdminRecords.Get.Replace("{recordId}", record.Id.ToString());

            var response = new RecordResponse { Id = record.Id };
            return Created(locationUri, response);
        }

        [HttpPut(ApiRoutes.AdminRecords.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid recordId, [FromBody] UpdateRecordRequest request)
        {
            var record = await _recordService.GetRecordById(recordId);
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

            var updated = await _recordService.UpdateRecord(record);
            if (updated == false)
            {
                return BadRequest();
            }

            return Ok(record);
        }

        [HttpDelete(ApiRoutes.AdminRecords.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid recordId)
        {
            var deleted = await _recordService.DeleteRecord(recordId);
            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet(ApiRoutes.AdminRecords.Date)]
        public async Task<IActionResult> GetByDate([FromRoute] DateTime recordDate)
        {
            return Ok(await _recordService.GetRecordByDate(recordDate));
        }

        /*
        [HttpPost(ApiRoutes.Records.Transfer)]
        public IActionResult PublishRecords()
        {
            var transfered = _recordService.TransferChanges();
            if(transfered == false)
            {
                return NotFound();
            }

            return Ok();
        }*/

        #endregion

        #region Test/Development Actions

        [HttpGet(ApiRoutes.AdminRecords.Today)]
        public async Task<IActionResult> GetToday()
        {
            var today = DateTime.Today;
            var test = await _recordService.GetRecordByDate(today);
            return Ok(test);
        }

        [HttpGet(ApiRoutes.AdminRecords.Tomorrow)]
        public async Task<IActionResult> GetTomorrow()
        {
            var tomorrow = DateTime.Today.AddDays(1);
            return Ok(await _recordService.GetRecordByDate(tomorrow));
        }

        #endregion
    }
}

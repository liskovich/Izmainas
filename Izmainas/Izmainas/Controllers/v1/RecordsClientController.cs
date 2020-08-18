using Izmainas.Contracts.v1;
using Izmainas.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Controllers.v1
{
    public class RecordsClientController : Controller
    {
        private readonly IRecordService _recordService;

        public RecordsClientController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        #region Production Actions

        [HttpGet(ApiRoutes.ClientRecords.Date)]
        public IActionResult GetByDate([FromRoute] DateTime recordDate)
        {
            return Ok(_recordService.GetRecordByDate(recordDate));
        }

        #endregion

        #region Test/Development Actions

        [HttpGet(ApiRoutes.ClientRecords.Today)]
        public IActionResult GetToday()
        {
            var today = DateTime.Today;
            var test = _recordService.GetRecordByDate(today);
            return Ok(test);
        }

        [HttpGet(ApiRoutes.ClientRecords.Tomorrow)]
        public IActionResult GetTomorrow()
        {
            var tomorrow = DateTime.Today.AddDays(1);
            return Ok(_recordService.GetRecordByDate(tomorrow));
        }

        [HttpGet(ApiRoutes.ClientRecords.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_recordService.GetRecords());
        }

        [HttpGet(ApiRoutes.ClientRecords.Get)]
        public IActionResult Get([FromRoute] Guid recordId)
        {
            var record = _recordService.GetRecordById(recordId);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        #endregion
    }
}

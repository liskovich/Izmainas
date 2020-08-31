using Izmainas.Cache;
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
        //[Cached(600)]
        public async Task<IActionResult> GetByDate([FromRoute] DateTime recordDate)
        {
            return Ok(await _recordService.GetRecordByDate(recordDate));
        }

        #endregion

        #region Test/Development Actions

        [HttpGet(ApiRoutes.ClientRecords.Today)]
        public async Task<IActionResult> GetToday()
        {
            var today = DateTime.Today;
            var test = await _recordService.GetRecordByDate(today);
            return Ok(test);
        }

        [HttpGet(ApiRoutes.ClientRecords.Tomorrow)]
        public async Task<IActionResult> GetTomorrow()
        {
            var tomorrow = DateTime.Today.AddDays(1);
            return Ok(await _recordService.GetRecordByDate(tomorrow));
        }

        [HttpGet(ApiRoutes.ClientRecords.GetAll)]
        //[Cached(600)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _recordService.GetRecords());
        }

        [HttpGet(ApiRoutes.ClientRecords.Get)]
        //[Cached(600)]
        public async Task<IActionResult> Get([FromRoute] Guid recordId)
        {
            var record = await _recordService.GetRecordById(recordId);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        #endregion
    }
}

using Izmainas.Contracts.v1;
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
            var test = new List<string>();
            test.Add("hello");
            test.Add("what");
            test.Add("test");
            test.Add("lol");
            test.Add("adios");

            return Ok(test);
        }
    }
}

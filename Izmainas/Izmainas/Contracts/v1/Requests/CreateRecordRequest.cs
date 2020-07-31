using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Contracts.v1.Requests
{
    public class CreateRecordRequest
    {
        public string Teacher { get; set; }
        public string Room { get; set; }
        public string Note { get; set; }
        public string ClassNumber { get; set; }
        public string ClassLetter { get; set; }
        public string Lessons { get; set; }
        public DateTime Date { get; set; }
    }
}

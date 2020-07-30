using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Domain
{
    public class Record
    {
        public Guid Id { get; set; }
        public string Teacher { get; set; }
        public string Room { get; set; }
        public string Note { get; set; }
        public string ClassNumber { get; set; }
        public string ClassLetter { get; set; }
        public string Lessons { get; set; }
        public DateTime Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace IzmainasAdmin.Models
{
    public class CreateRecord
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

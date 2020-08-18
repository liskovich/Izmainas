using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Contracts.v1.Responses
{
    public class ErrorResponse
    {
        public string Title { get; set; }
        public string ErrorText { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Contracts.v1.Requests
{
    public class CreateEmailModelRequest
    {
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

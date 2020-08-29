using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Domain
{
    public class EmailTempModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string VerificationKey { get; set; }
    }
}

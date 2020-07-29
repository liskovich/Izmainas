using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Services
{
    public class RecordService : IRecordService
    {
        public Task<bool> CreateRecordAsync(Record record)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRecordAsync(Guid recordId)
        {
            throw new NotImplementedException();
        }

        public Task<Record> GetRecordByIdAsync(Guid recordId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Record>> GetRecordsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRecordAsync(Record record)
        {
            throw new NotImplementedException();
        }
    }
}

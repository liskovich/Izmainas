using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Services
{
    public interface IRecordService
    {
        Task<List<Record>> GetRecordsAsync();
        Task<Record> GetRecordByIdAsync(Guid recordId);
        Task<bool> CreateRecordAsync(Record record);
        Task<bool> UpdateRecordAsync(Record record);
        Task<bool> DeleteRecordAsync(Guid recordId);
    }
}

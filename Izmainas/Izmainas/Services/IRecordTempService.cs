using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Izmainas.Services
{
    public interface IRecordTempService
    {
        Task<bool> CreateTempRecord(Record record);
        Task<bool> DeleteTempRecord(Guid recordId);
        Task<Record> GetTempRecordById(Guid recordId);
        Task<List<Record>> GetTempRecords();
        Task<bool> TransferChanges();
        Task<bool> UpdateTempRecord(Record record);
    }
}
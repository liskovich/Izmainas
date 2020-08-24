using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Services
{
    public interface IRecordService
    {
        Task<List<Record>> GetRecords();
        Task<Record> GetRecordById(Guid recordId);
        Task<List<Record>> GetRecordByDate(DateTime recordDate);
        Task<bool> CreateRecord(Record record);
        Task<bool> UpdateRecord(Record record);
        Task<bool> DeleteRecord(Guid recordId);
        //bool TransferChanges();
    }
}

using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Izmainas.Data.DataAccess
{
    public interface IRecordData
    {
        Task DeleteRecord(string recordId);
        Task EditRecord(DbRecord record);
        Task<List<DbRecord>> GetRecordByDate(DateTime recordDate);
        Task<List<DbRecord>> GetRecordById(string recordId);
        Task<List<DbRecord>> GetRecords(); // Task<>
        Task SaveRecord(DbRecord record);
        //void PublishRecords();
    }
}
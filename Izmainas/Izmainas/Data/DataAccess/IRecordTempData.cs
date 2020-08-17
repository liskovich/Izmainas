using Izmainas.Domain;
using System.Collections.Generic;

namespace Izmainas.Data.DataAccess
{
    public interface IRecordTempData
    {
        void DeleteTempRecord(string Id);
        void EditTempRecord(DbRecord record);
        List<DbRecord> GetTempRecordById(string Id);
        List<DbRecord> GetTempRecords();
        void PublishTempRecords();
        void SaveTempRecord(DbRecord record);
    }
}
using Izmainas.Domain;
using System;
using System.Collections.Generic;

namespace Izmainas.Data.DataAccess
{
    public interface IRecordData
    {
        void DeleteRecord(string Id);
        void EditRecord(DbRecord record);
        List<DbRecord> GetRecordByDate(DateTime Date);
        List<DbRecord> GetRecordById(string Id);
        List<DbRecord> GetRecords();
        void SaveRecord(DbRecord record);
        //void PublishRecords();
    }
}
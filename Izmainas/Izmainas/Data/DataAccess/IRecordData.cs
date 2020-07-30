using Izmainas.Domain;
using System;
using System.Collections.Generic;

namespace Izmainas.Data.DataAccess
{
    public interface IRecordData
    {
        void DeleteNotification(string Id);
        void EditNotification(Record record);
        List<Record> GetRecordByDate(DateTime Date);
        List<Record> GetRecordById(string Id);
        List<Record> GetRecords();
        void SaveNotification(Record record);
    }
}
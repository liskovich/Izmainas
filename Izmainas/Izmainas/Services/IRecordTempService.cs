using Izmainas.Domain;
using System;
using System.Collections.Generic;

namespace Izmainas.Services
{
    public interface IRecordTempService
    {
        bool CreateTempRecord(Record record);
        bool DeleteTempRecord(Guid recordId);
        Record GetTempRecordById(Guid recordId);
        List<Record> GetTempRecords();
        bool TransferChanges();
        bool UpdateTempRecord(Record record);
    }
}
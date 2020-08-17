using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Services
{
    public interface IRecordService
    {
        List<Record> GetRecords();
        Record GetRecordById(Guid recordId);
        List<Record> GetRecordByDate(DateTime recordDate);
        bool CreateRecord(Record record);
        bool UpdateRecord(Record record);
        bool DeleteRecord(Guid recordId);
        //bool TransferChanges();
    }
}

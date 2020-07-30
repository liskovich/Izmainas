using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Data.DataAccess
{
    public class RecordData : IRecordData
    {
        private readonly ISqlDataAccess _sql;

        public RecordData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public List<Record> GetRecords()
        {
            var output = _sql.LoadData<Record, dynamic>("dbo.spRecords_GetAll", new { }, "IzmainasData");
            return output;
        }

        public List<Record> GetRecordById(string Id)
        {
            var output = _sql.LoadData<Record, dynamic>("dbo.spRecords_GetById", new { Id }, "IzmainasData");
            return output;
        }

        public List<Record> GetRecordByDate(DateTime Date)
        {
            var output = _sql.LoadData<Record, dynamic>("dbo.spRecords_GetByDate", new { Date }, "IzmainasData");
            return output;
        }

        public void SaveNotification(Record record)
        {
            _sql.SaveData("dbo.spRecords_Insert", record, "IzmainasData");
        }

        public void EditNotification(Record record)
        {
            _sql.SaveData("dbo.spRecords_Edit", record, "IzmainasData");
        }

        public void DeleteNotification(string Id)
        {
            _sql.SaveData("dbo.spRecords_Delete", new { Id }, "IzmainasData");
        }
    }
}

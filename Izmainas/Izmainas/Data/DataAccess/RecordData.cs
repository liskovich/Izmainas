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

        public List<DbRecord> GetRecords()
        {
            var output = _sql.LoadData<DbRecord, dynamic>("dbo.spRecords_GetAll", new { }, "IzmainasData");
            return output;
        }

        public List<DbRecord> GetRecordById(string Id)
        {
            var output = _sql.LoadData<DbRecord, dynamic>("dbo.spRecords_GetById", new { Id }, "IzmainasData");
            return output;
        }

        public List<DbRecord> GetRecordByDate(DateTime Date)
        {
            var output = _sql.LoadData<DbRecord, dynamic>("dbo.spRecords_GetToday", new { Date }, "IzmainasData");
            return output; //spRecords_GetByDate
        }

        public void SaveRecord(DbRecord record)
        {
            _sql.SaveData("dbo.spRecords_Insert", record, "IzmainasData");
        }

        public void EditRecord(DbRecord record)
        {
            _sql.SaveData("dbo.spRecords_Edit", record, "IzmainasData");
        }

        public void DeleteRecord(string Id)
        {
            _sql.SaveData("dbo.spRecords_Delete", new { Id }, "IzmainasData");
        }
    }
}

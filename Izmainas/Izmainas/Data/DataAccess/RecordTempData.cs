using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Data.DataAccess
{
    public class RecordTempData : IRecordTempData
    {
        private readonly ISqlDataAccess _sql;

        public RecordTempData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public List<DbRecord> GetTempRecords()
        {
            var output = _sql.LoadData<DbRecord, dynamic>("dbo.spRecordsTemp_GetAll", new { }, "IzmainasData");
            return output;
        }

        public List<DbRecord> GetTempRecordById(string Id)
        {
            var output = _sql.LoadData<DbRecord, dynamic>("dbo.spRecordsTemp_GetById", new { Id }, "IzmainasData");
            return output;
        }

        public void SaveTempRecord(DbRecord record)
        {
            _sql.SaveData("dbo.spRecordsTemp_Insert", record, "IzmainasData");
        }

        public void EditTempRecord(DbRecord record)
        {
            _sql.SaveData("dbo.spRecordsTemp_Edit", record, "IzmainasData");
        }

        public void DeleteTempRecord(string Id)
        {
            _sql.SaveData("dbo.spRecordsTemp_Delete", new { Id }, "IzmainasData");
        }

        public void PublishTempRecords()
        {
            _sql.SaveData("dbo.trRecordsTemp_TransferToRecords", new { }, "IzmainasData");
        }
    }
}

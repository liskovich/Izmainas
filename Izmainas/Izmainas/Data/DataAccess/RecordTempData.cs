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
        private readonly IMySqlDataAccess _mySql;

        public RecordTempData(ISqlDataAccess sql, IMySqlDataAccess mySql)
        {
            _sql = sql;
            _mySql = mySql;
        }

        public async Task<List<DbRecord>> GetTempRecords()
        {
            /*
            var output = _sql.LoadData<DbRecord, dynamic>("dbo.spRecordsTemp_GetAll", new { }, "IzmainasDB");
            return output;
            */

            var output = await _mySql.LoadData<DbRecord, dynamic>("spRecordsTemp_GetAll", new { }, "Default");
            return output;
        }

        public async Task<List<DbRecord>> GetTempRecordById(string recordId)
        {
            /*
            var output = _sql.LoadData<DbRecord, dynamic>("dbo.spRecordsTemp_GetById", new { Id }, "IzmainasDB");
            return output;
            */

            var output = await _mySql.LoadData<DbRecord, dynamic>("spRecordsTemp_GetById", new { recordId }, "Default");
            return output;
        }

        public async Task SaveTempRecord(DbRecord record)
        {
            string recordId = record.Id;
            string recordTeacher = record.Teacher;
            string recordRoom = record.Room;
            string recordNote = record.Note;
            string recordClassNumber = record.ClassNumber;
            string recordClassLetter = record.ClassLetter;
            string recordLessons = record.Lessons;
            DateTime recordDate = record.Date;

            await _mySql.SaveData("spRecordsTemp_Insert", new { recordId, recordTeacher, recordRoom, recordNote, recordClassNumber, recordClassLetter, recordLessons, recordDate }, "Default");
        }

        public async Task EditTempRecord(DbRecord record)
        {
            string recordId = record.Id;
            string recordTeacher = record.Teacher;
            string recordRoom = record.Room;
            string recordNote = record.Note;
            string recordClassNumber = record.ClassNumber;
            string recordClassLetter = record.ClassLetter;
            string recordLessons = record.Lessons;
            DateTime recordDate = record.Date;

            await _mySql.SaveData("spRecordsTemp_Edit", new { recordId, recordTeacher, recordRoom, recordNote, recordClassNumber, recordClassLetter, recordLessons, recordDate }, "Default");
        }

        public async Task DeleteTempRecord(string recordId)
        {
            await _mySql.SaveData("spRecordsTemp_Delete", new { recordId }, "Default");
        }

        public async Task PublishTempRecords()
        {
            await _mySql.SaveData("trRecordsTemp_TransferToRecords", new { }, "Default");
        }
    }
}

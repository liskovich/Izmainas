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
        private readonly IMySqlDataAccess _mySql;

        public RecordData(ISqlDataAccess sql, IMySqlDataAccess mySql)
        {
            _sql = sql;
            _mySql = mySql;
        }

        public async Task<List<DbRecord>> GetRecords()
        {
            /*   
            var output = _sql.LoadData<DbRecord, dynamic>("dbo.spRecords_GetAll", new { }, "IzmainasDB");
            return output;
            */ 

            var output = await _mySql.LoadData<DbRecord, dynamic>("spRecords_GetAll", new { }, "Default");
            return output;
            
        }

        public async Task<List<DbRecord>> GetRecordById(string recordId) //Id
        {
            /*
            var output = _sql.LoadData<DbRecord, dynamic>("dbo.spRecords_GetById", new { Id }, "IzmainasDB");
            return output;
            */

            var output = await _mySql.LoadData<DbRecord, dynamic>("spRecords_GetById", new { recordId }, "Default");
            return output;
        }

        public async Task<List<DbRecord>> GetRecordByDate(DateTime recordDate)
        {
            /*
            var output = _sql.LoadData<DbRecord, dynamic>("dbo.spRecords_GetByDate", new { Date }, "IzmainasDB");
            return output;
            */

            var output = await _mySql.LoadData<DbRecord, dynamic>("spRecords_GetByDate", new { recordDate }, "Default");
            return output;
        }

        public async Task SaveRecord(DbRecord record) //void
        {
            string recordId = record.Id;
            string recordTeacher = record.Teacher;
            string recordRoom = record.Room;
            string recordNote = record.Note;
            string recordClassNumber = record.ClassNumber;
            string recordClassLetter = record.ClassLetter;
            string recordLessons = record.Lessons;
            DateTime recordDate = record.Date;

            await _mySql.SaveData("spRecords_Insert", new { recordId, recordTeacher, recordRoom, recordNote, recordClassNumber, recordClassLetter, recordLessons, recordDate }, "Default"); //record
        }

        public async Task EditRecord(DbRecord record)
        {
            string recordId = record.Id;
            string recordTeacher = record.Teacher;
            string recordRoom = record.Room;
            string recordNote = record.Note;
            string recordClassNumber = record.ClassNumber;
            string recordClassLetter = record.ClassLetter;
            string recordLessons = record.Lessons;
            DateTime recordDate = record.Date;

            await _mySql.SaveData("spRecords_Edit", new { recordId, recordTeacher, recordRoom, recordNote, recordClassNumber, recordClassLetter, recordLessons, recordDate }, "Default");
        }

        public async Task DeleteRecord(string recordId)
        {
            await _mySql.SaveData("spRecords_Delete", new { recordId }, "Default");
        }
    }
}

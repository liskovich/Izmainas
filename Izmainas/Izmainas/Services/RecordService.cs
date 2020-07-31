using Izmainas.Data.DataAccess;
using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Services
{
    public class RecordService : IRecordService
    {
        private readonly IRecordData _recordData;

        public RecordService(IRecordData recordData)
        {
            _recordData = recordData;
        }

        public bool CreateRecord(Record record)
        {
            try
            {
                var saveRecord = new DbRecord
                {
                    Id = record.Id.ToString(),
                    Teacher = record.Teacher,
                    Room = record.Room,
                    Note = record.Note,
                    ClassNumber = record.ClassNumber,
                    ClassLetter = record.ClassLetter,
                    Lessons = record.Lessons,
                    Date = record.Date
                };

                _recordData.SaveRecord(saveRecord);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteRecord(Guid recordId)
        {
            try
            {
                var deleteId = recordId.ToString();
                var existing = _recordData.GetRecordById(deleteId).FirstOrDefault();
                if (existing == null)
                {
                    return false;
                }

                _recordData.DeleteRecord(deleteId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Record> GetRecordByDate(DateTime recordDate)
        {
            try
            {
                var found = _recordData.GetRecordByDate(recordDate);
                if (found == null)
                {
                    return null;
                }

                var records = new List<Record>();
                foreach (var r in found)
                {
                    var record = new Record
                    {
                        Id = Guid.Parse(r.Id),
                        Teacher = r.Teacher,
                        Room = r.Room,
                        Note = r.Note,
                        ClassNumber = r.ClassNumber,
                        ClassLetter = r.ClassLetter,
                        Lessons = r.Lessons,
                        Date = r.Date
                    };
                    records.Add(record);
                }
                return records;
            }
            catch
            {
                return null;
            }
        }

        public Record GetRecordById(Guid recordId)
        {
            try
            {
                var findId = recordId.ToString();
                var found = _recordData.GetRecordById(findId).FirstOrDefault();
                if(found == null)
                {
                    return null;
                }

                var record = new Record
                {
                    Id = recordId,
                    Teacher = found.Teacher,
                    Room = found.Room,
                    Note = found.Note,
                    ClassNumber = found.ClassNumber,
                    ClassLetter = found.ClassLetter,
                    Lessons = found.Lessons,
                    Date = found.Date
                };
                return record;
            }
            catch
            {
                return null;
            }
        }

        public List<Record> GetRecords()
        {
            try
            {
                var found = _recordData.GetRecords();
                if(found == null)
                {
                    return null;
                }

                var records = new List<Record>();
                foreach (var r in found)
                {
                    var record = new Record
                    {
                        Id = Guid.Parse(r.Id),
                        Teacher = r.Teacher,
                        Room = r.Room,
                        Note = r.Note,
                        ClassNumber = r.ClassNumber,
                        ClassLetter = r.ClassLetter,
                        Lessons = r.Lessons,
                        Date = r.Date
                    };
                    records.Add(record);
                }
                return records;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateRecord(Record record)
        {
            try
            {
                var updateId = record.Id.ToString();
                var existing = _recordData.GetRecordById(updateId).FirstOrDefault();
                if (existing == null)
                {
                    return false;
                }

                var editRecord = new DbRecord
                {
                    Id = updateId,
                    Teacher = record.Teacher,
                    Room = record.Room,
                    Note = record.Note,
                    ClassNumber = record.ClassNumber,
                    ClassLetter = record.ClassLetter,
                    Lessons = record.Lessons,
                    Date = record.Date
                };

                _recordData.EditRecord(editRecord);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

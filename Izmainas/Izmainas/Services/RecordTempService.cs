using Izmainas.Data.DataAccess;
using Izmainas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Services
{
    public class RecordTempService : IRecordTempService
    {
        private readonly IRecordTempData _recordTempData;

        public RecordTempService(IRecordTempData recordTempData)
        {
            _recordTempData = recordTempData;
        }

        public bool CreateTempRecord(Record record)
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

                _recordTempData.SaveTempRecord(saveRecord);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTempRecord(Guid recordId)
        {
            try
            {
                var deleteId = recordId.ToString();
                var existing = _recordTempData.GetTempRecordById(deleteId).FirstOrDefault();
                if (existing == null)
                {
                    return false;
                }

                _recordTempData.DeleteTempRecord(deleteId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Record GetTempRecordById(Guid recordId)
        {
            try
            {
                var findId = recordId.ToString();
                var found = _recordTempData.GetTempRecordById(findId).FirstOrDefault();
                if (found == null)
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

        public List<Record> GetTempRecords()
        {
            try
            {
                var found = _recordTempData.GetTempRecords();
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

        public bool UpdateTempRecord(Record record)
        {
            try
            {
                var updateId = record.Id.ToString();
                var existing = _recordTempData.GetTempRecordById(updateId).FirstOrDefault();
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

                _recordTempData.EditTempRecord(editRecord);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TransferChanges()
        {
            try
            {
                _recordTempData.PublishTempRecords();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

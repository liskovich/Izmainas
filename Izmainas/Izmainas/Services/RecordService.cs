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

        public async Task<bool> CreateRecord(Record record)
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

                await _recordData.SaveRecord(saveRecord);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteRecord(Guid recordId)
        {
            try
            {
                var deleteId = recordId.ToString();
                var existing = await _recordData.GetRecordById(deleteId);
                var item = existing.FirstOrDefault();
                if (item == null)
                {
                    return false;
                }

                await _recordData.DeleteRecord(deleteId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Record>> GetRecordByDate(DateTime recordDate)
        {
            try
            {
                var found = await _recordData.GetRecordByDate(recordDate);
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

        public async Task<Record> GetRecordById(Guid recordId)
        {
            try
            {
                var findId = recordId.ToString();
                var found = await _recordData.GetRecordById(findId);
                var item = found.FirstOrDefault();
                if(item == null)
                {
                    return null;
                }

                var record = new Record
                {
                    Id = recordId,
                    Teacher = item.Teacher,
                    Room = item.Room,
                    Note = item.Note,
                    ClassNumber = item.ClassNumber,
                    ClassLetter = item.ClassLetter,
                    Lessons = item.Lessons,
                    Date = item.Date
                };
                return record;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Record>> GetRecords()
        {
            try
            {
                var found = await _recordData.GetRecords();
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

        public async Task<bool> UpdateRecord(Record record)
        {
            try
            {
                var updateId = record.Id.ToString();
                var existing = await _recordData.GetRecordById(updateId);
                var item = existing.FirstOrDefault();
                if (item == null)
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

                await _recordData.EditRecord(editRecord);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

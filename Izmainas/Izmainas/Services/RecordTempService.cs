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

        public async Task<bool> CreateTempRecord(Record record)
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

                await _recordTempData.SaveTempRecord(saveRecord);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteTempRecord(Guid recordId)
        {
            try
            {
                var deleteId = recordId.ToString();
                var existing = await _recordTempData.GetTempRecordById(deleteId);
                var item = existing.FirstOrDefault();
                if (item == null)
                {
                    return false;
                }

                await _recordTempData.DeleteTempRecord(deleteId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Record> GetTempRecordById(Guid recordId)
        {
            try
            {
                var findId = recordId.ToString();
                var found = await _recordTempData.GetTempRecordById(findId);
                var item = found.FirstOrDefault();
                if (item == null)
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

        public async Task<List<Record>> GetTempRecords()
        {
            try
            {
                var found = await _recordTempData.GetTempRecords();
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

        public async Task<bool> UpdateTempRecord(Record record)
        {
            try
            {
                var updateId = record.Id.ToString();
                var existing = await _recordTempData.GetTempRecordById(updateId);
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

                await _recordTempData.EditTempRecord(editRecord);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TransferChanges()
        {
            try
            {
                await _recordTempData.PublishTempRecords();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

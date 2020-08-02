using IzmainasAdmin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IzmainasAdmin.Services
{
    public interface IRecordService
    {
        Task DeleteRecord(Record record);
        Task EditRecord(Record record);
        Task<List<Record>> GetAll();
        Task<List<Record>> GetByDate(DateTime recordDate);
        Task<Record> GetById(Guid recordId);
        Task PostRecord(CreateRecord record);
    }
}
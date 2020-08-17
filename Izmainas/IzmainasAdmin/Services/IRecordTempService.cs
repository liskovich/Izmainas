using IzmainasAdmin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IzmainasAdmin.Services
{
    public interface IRecordTempService
    {
        Task DeleteRecord(Guid recordId);
        Task EditRecord(Record record);
        Task<List<Record>> GetAll();
        Task<Record> GetById(Guid recordId);
        Task PostRecord(CreateRecord record);
        Task PublishRecords();
    }
}
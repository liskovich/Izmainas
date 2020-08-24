using Izmainas.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Izmainas.Data.DataAccess
{
    public interface IRecordTempData
    {
        Task DeleteTempRecord(string recordId);
        Task EditTempRecord(DbRecord record);
        Task<List<DbRecord>> GetTempRecordById(string recordId);
        Task<List<DbRecord>> GetTempRecords();
        Task PublishTempRecords();
        Task SaveTempRecord(DbRecord record);
    }
}
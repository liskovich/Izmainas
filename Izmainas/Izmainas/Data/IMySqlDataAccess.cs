using System.Collections.Generic;
using System.Threading.Tasks;

namespace Izmainas.Data
{
    public interface IMySqlDataAccess
    {
        Task<List<T>> LoadData<T, U>(string statement, U parameters, string connectionStringName);
        Task SaveData<T>(string statement, T parameters, string connectionStringName);
    }
}
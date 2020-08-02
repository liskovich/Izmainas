using System.Net.Http;

namespace IzmainasAdmin.Data
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; }
    }
}
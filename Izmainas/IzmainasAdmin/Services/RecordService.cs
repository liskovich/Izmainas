using IzmainasAdmin.Data;
using IzmainasAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IzmainasAdmin.Services
{
    public class RecordService : IRecordService
    {
        private readonly IApiHelper _apiHelper;

        public RecordService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<Record>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/v1/records"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<Record>>();
                    return result;
                }
                else
                {
                    //throw new Exception(response.ReasonPhrase);
                    return null;
                }
            }
        }

        public async Task<Record> GetById(Guid recordId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/v1/records/{recordId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var recordsList = await response.Content.ReadAsAsync<List<Record>>();
                    var result = recordsList.FirstOrDefault();
                    return result;
                }
                else
                {
                    //throw new Exception(response.ReasonPhrase);
                    return null;
                }
            }
        }

        public async Task<List<Record>> GetByDate(DateTime recordDate)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/v1/records/dates/{recordDate}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<Record>>();
                    return result;
                }
                else
                {
                    //throw new Exception(response.ReasonPhrase);
                    return null;
                }
            }
        }

        public async Task PostRecord(CreateRecord record)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("api/v1/records", record))
            {
                if (response.IsSuccessStatusCode)
                {
                    // log successful post 
                }
                else
                {
                    //throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task EditRecord(Record record)
        {
            var selectedId = record.Id;
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync($"api/v1/records/{selectedId}", record))
            {
                if (response.IsSuccessStatusCode)
                {
                    // log successful post
                }
                else
                {
                    //throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task DeleteRecord(Guid recordId) //Record record
        {
            var selectedId = recordId;
            using (HttpResponseMessage response = await _apiHelper.ApiClient.DeleteAsync($"api/v1/records/{selectedId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    // log successful post
                }
                else
                {
                    //throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}

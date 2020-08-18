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
    public class RecordTempService : IRecordTempService
    {
        private readonly IApiHelper _apiHelper;

        public RecordTempService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<Record>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/v1/temprecords"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<Record>>();
                    return result;
                }
                else
                {
                    //throw new Exception(response.ReasonPhrase);
                    //var failed = new List<Record>
                    //{
                    //    new Record
                    //    {
                    //        Id = Guid.NewGuid(),
                    //        Teacher = "",
                    //        Room = "",
                    //        Note = "",
                    //        ClassNumber = "",
                    //        ClassLetter = "",
                    //        Lessons = "",
                    //        Date = DateTime.Today
                    //    }
                    //};
                    return null;
                }
            }
        }

        public async Task<Record> GetById(Guid recordId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/v1/temprecords/{recordId}"))
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

        public async Task PostRecord(CreateRecord record)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("api/v1/temprecords", record))
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
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync($"api/v1/temprecords/{selectedId}", record))
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
            using (HttpResponseMessage response = await _apiHelper.ApiClient.DeleteAsync($"api/v1/temprecords/{selectedId}"))
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

        public async Task PublishRecords()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync($"api/v1/temprecords/transfer", new { }))
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

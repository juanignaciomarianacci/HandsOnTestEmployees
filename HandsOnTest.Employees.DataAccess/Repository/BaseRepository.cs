using HandsOnTest.Employees.DataAccess.Repository.Contract;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HandsOnTest.Employees.DataAccess.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private Uri _baseUrl;

        public BaseRepository()
        {
            _baseUrl = new Uri("http://masglobaltestapi.azurewebsites.net/api/");
        }

        public async Task<T> GetAsync<T>(string target)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseUrl;
                client.Timeout = new TimeSpan(1, 0, 0);
                var response = await client.GetAsync(target);

                if (!response.IsSuccessStatusCode)
                {
                    return default(T);
                }

                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var responseObj = JsonConvert.DeserializeObject<T>(responseString);

                return responseObj;
            }
        }
    }
}

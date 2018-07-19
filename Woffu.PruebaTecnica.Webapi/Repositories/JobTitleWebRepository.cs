using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Woffu.PruebaTecnica.Webapi.Models;

namespace Woffu.PruebaTecnica.Webapi.Repositories
{
    public class JobTitleWebRepository
    {
        private const string _username = "aGhrZ0JZTnhZZDBISWFMd2hwenVjRWttTHIlMmZIYkRPWjZIa21EdkZ2akdGRzFubk1nbW5BY3clM2QlM2Q6";
        private const string _baseAddress = @"https://woffu-test.azurewebsites.net/";

        private static readonly HttpClient _httpClient;

        static JobTitleWebRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseAddress);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(@"application/json"));

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", _username);

        }


        public async Task<IEnumerable<JobTitle>> GetAllAsync()
        {
            var jobTitles = new List<JobTitle>();

            var response = await _httpClient.GetAsync(@"api/v1/jobtitles");

            if (response.IsSuccessStatusCode)
            {
                jobTitles = await response.Content.ReadAsAsync<List<JobTitle>>();
            }

            return jobTitles;
        }

        public async Task<JobTitle> GetById(int id)
        {
            var jobTitle = new JobTitle() { Name = "Not Found" };

            var response = await _httpClient.GetAsync(string.Format("api/v1/jobtitles/{0}", id));

            if (response.IsSuccessStatusCode)
            {
                jobTitle = await response.Content.ReadAsAsync<JobTitle>();
            }
            return jobTitle;
        }

        public async Task<HttpStatusCode> DeleteByIdAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(string.Format("api/v1/jobtitles/{0}", id));

            return response.StatusCode;
        }

        public async Task<HttpResponseMessage> CreateAsync(JobTitle jobTitle)
        {
            HttpResponseMessage response = null;

            try
            {
                string message = JsonConvert.SerializeObject(jobTitle);

                byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
                var content = new ByteArrayContent(messageBytes);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                response = await _httpClient.PostAsync("api/v1/jobtitles", content);

                response.EnsureSuccessStatusCode();
            }
            catch
            {
                Console.WriteLine(response?.ReasonPhrase);
            }

            return response;
        }

        public async Task Update(int id, JobTitle jobTitle)
        {
            HttpResponseMessage response = null;

            try
            {
                string message = JsonConvert.SerializeObject(jobTitle);

                byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
                var content = new ByteArrayContent(messageBytes);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                response = await _httpClient.PutAsync(string.Format("api/v1/jobtitles/{0}", id), content);

                response.EnsureSuccessStatusCode();
            }
            catch
            {
                Console.WriteLine(response?.ReasonPhrase);
            }

        }

    }
}

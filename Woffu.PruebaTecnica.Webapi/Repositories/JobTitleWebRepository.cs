using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<JobTitle>> GetAll()
        {

            var client = GetHttpClient();

            var stream = client.GetStreamAsync(@"https://woffu-test.azurewebsites.net/api/v1/jobtitles");

            var serializer = new DataContractJsonSerializer(typeof(List<JobTitle>));

            var jobTitles = serializer.ReadObject(await stream) as List<JobTitle>;

            return jobTitles;
        }

        public async Task<JobTitle> GetById(int id)
        {
            var client = GetHttpClient();

            var stream = client.GetStreamAsync(string.Format("https://woffu-test.azurewebsites.net/api/v1/jobtitles/{0}",id));

            var serializer = new DataContractJsonSerializer(typeof(JobTitle));

            JobTitle jobTitle;

            try
            {
                jobTitle = serializer.ReadObject(await stream) as JobTitle;
            }
            catch(Exception)
            {
                jobTitle = new JobTitle() { CompanyId = -1, JobTitleId = -1, Name = "Not Found" };
            }

            return jobTitle;
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", _username);

            return client;
        }
    }
}

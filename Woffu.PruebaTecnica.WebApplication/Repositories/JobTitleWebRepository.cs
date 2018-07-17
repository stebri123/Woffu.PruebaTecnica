using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Woffu.PruebaTecnica.WebApplication.Models;

namespace Woffu.PruebaTecnica.Webapi.Repositories
{
    public class JobTitleWebRepository
    {

        public async Task<IEnumerable<JobTitle>> GetAll()
        {

            var client = GetHttpClient();

            var stream = client.GetStreamAsync("http://localhost:56933/api/jobtitles");

            var serializer = new DataContractJsonSerializer(typeof(List<JobTitle>));

            List<JobTitle> jobTitles;

            try
            {
                jobTitles = serializer.ReadObject(await stream) as List<JobTitle>;
            }
            catch (Exception)
            {
                jobTitles = new List<JobTitle>();
            }

            return jobTitles;
        }

        public async Task<JobTitle> GetById(int id)
        {
            var client = GetHttpClient();

            var stream = client.GetStreamAsync(string.Format("http://localhost:56933/api/jobtitles/{0}", id));

            var serializer = new DataContractJsonSerializer(typeof(JobTitle));

            JobTitle jobTitle;

            try
            {
                jobTitle = serializer.ReadObject(await stream) as JobTitle;
            }
            catch (Exception)
            {
                jobTitle = new JobTitle() { companyId = -1, jobTitleId = -1, name = "Not Found" };
            }

            return jobTitle;
        }

        public void DeleteById(int id)
        {
            var client = GetHttpClient();

            var response = client.DeleteAsync(string.Format("http://localhost:56933/api/jobtitles/{0}", id)).Result;


        }

        public void Create(JobTitle jobTitle)
        {
            var client = GetHttpClient();

            var response = client.PostAsJsonAsync("http://localhost:56933/api/jobtitles", jobTitle).Result;
        }

        public void Update(int id, JobTitle jobTitle)
        {
            var client = GetHttpClient();

            var response = client.PutAsJsonAsync(string.Format("http://localhost:56933/api/jobtitles/{0}", id), jobTitle).Result;
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();

            return client;
        }
    }
}

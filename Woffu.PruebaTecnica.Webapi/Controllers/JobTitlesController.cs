using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Woffu.PruebaTecnica.Webapi.Models;
using Woffu.PruebaTecnica.Webapi.Repositories;

namespace Woffu.PruebaTecnica.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitlesController : Controller
    {
        private readonly JobTitleWebRepository _jobsWebRepository;

        public JobTitlesController(JobTitleWebRepository jobsWebRepository)
        {
            _jobsWebRepository = jobsWebRepository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<JobTitle> jobs;

            try
            {
                jobs = _jobsWebRepository.GetAllAsync().Result;
            }
            catch (Exception)
            {
                jobs = new List<JobTitle>();
            }
            return Json(jobs);
        }

        [HttpGet("{id}")]
        public JobTitle Get(int id)
        {
            var job = _jobsWebRepository.GetById(id).Result;
            return job;
        }

        [HttpPost]
        public void Post([FromBody] JobTitle value)
        {
            _jobsWebRepository.CreateAsync(value).Wait();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JobTitle value)
        {
            _jobsWebRepository.Update(id, value).Wait();
        }

        [HttpDelete("{id}")]
        public HttpStatusCode Delete(int id)
        {
            var result = _jobsWebRepository.DeleteByIdAsync(id).Result;

            return result;
        }
    }
}

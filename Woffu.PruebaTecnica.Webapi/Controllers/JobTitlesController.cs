using System;
using System.Collections.Generic;
using System.Linq;
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
            var jobs = _jobsWebRepository.GetAll().Result;

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
            _jobsWebRepository.Create(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JobTitle value)
        {
            _jobsWebRepository.Update(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _jobsWebRepository.DeleteById(id);
        }
    }
}

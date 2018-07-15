using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Woffu.PruebaTecnica.Webapi.Models;

namespace Woffu.PruebaTecnica.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitlesController : Controller
    {
        private readonly JobTitleContext _context;

        public JobTitlesController(JobTitleContext context)
        {
            _context = context;

            if (_context.JobTitles.Count() == 0)
            {
                _context.JobTitles.Add(new JobTitle() { CompanyId = 1, JobTitleId = 1, Name = "Manager" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public JsonResult Get()
        {
            var joblist = _context.JobTitles.ToList();

            return Json(joblist);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
            // post method
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            // implemente put method
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // delete 
        }
    }
}

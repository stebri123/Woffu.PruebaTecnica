using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Woffu.PruebaTecnica.Webapi.Models;

namespace Woffu.PruebaTecnica.Webapi.Controllers
{
    
    public class JobTitlesWebController : Controller
    {
        private JobTitleContext _context;

        public JobTitlesWebController(JobTitleContext context)
        {
            _context = context;

            if (_context.JobTitles.Count() == 0)
            {
                _context.JobTitles.Add(new JobTitle() { CompanyId = 1, JobTitleId = 1, Name = "Manager" });
                _context.SaveChanges();
            }
        }

        public ActionResult Index()
        {
            return View(_context.JobTitles.ToList());
        }
    }
}

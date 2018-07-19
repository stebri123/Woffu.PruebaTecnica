using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Woffu.PruebaTecnica.Webapi.Repositories;
using Woffu.PruebaTecnica.WebApplication.Models;

namespace Woffu.PruebaTecnica.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        readonly JobTitleWebRepository _jobsWebRepository;

        public HomeController()
        {
            _jobsWebRepository = new JobTitleWebRepository();
        }

        public IActionResult Index()
        {

            var jobTitles = _jobsWebRepository.GetAll().Result;

            return View(jobTitles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                _jobsWebRepository.Create(new JobTitle() { name = collection["name"] });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var job = _jobsWebRepository.GetById(id).Result;
            return View(job);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                _jobsWebRepository.Update(int.Parse(collection["jobTitleId"]), new JobTitle() { name = collection["name"] });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            JobTitle job = null;
            try
            {
                job = _jobsWebRepository.GetById(id).Result;
            }
            catch
            {
                return RedirectToAction(nameof(Index));

            }
            return View(job);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _jobsWebRepository.DeleteById(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Woffu Test.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Stefano Briganti";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

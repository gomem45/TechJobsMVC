using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            List<Dictionary<string, string>> viewJobs = new List<Dictionary<string, string>>();

            if (String.IsNullOrEmpty(searchTerm))
            {
                return View("Index");
            }

            if (searchType.Equals("all"))
            {
                viewJobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = viewJobs;
                return View("Index");
            }
            else
            {
                viewJobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = viewJobs;
                return View("Index");
            }

        }
    }
}

using ChilliSoftDLL.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSoftAssessment.Controllers
{
    public class AdminController : Controller
    {
        private readonly IChilliDB db;

        public AdminController(IChilliDB db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEmployee() { return View(); }

        [HttpGet]
        public IActionResult ViewAllEmployees() { return View(); }

        [HttpGet]
        public IActionResult ViewAllHistory() { return View(); }

    }
}

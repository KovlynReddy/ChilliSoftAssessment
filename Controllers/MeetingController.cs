using ChilliSoftAssessment.Models;
using ChilliSoftDLL.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSoftAssessment.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IChilliDB db;

        public MeetingController(IChilliDB db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SceduleMeeting() { return View(); }


        [HttpGet]
        public IActionResult StartMeeting() { return View(); }


        [HttpGet]
        public IActionResult Rooms() { return View(); }


        [HttpGet]
        public IActionResult History() { return View(); }

        [HttpGet]
        public IActionResult ViewAllEmployees() {

            ViewEmployeesViewModel model = new ViewEmployeesViewModel();


            var employees = db.GetAllEmployees();

            model.employees = employees;

            return View(model); 
        
        }


    }
}

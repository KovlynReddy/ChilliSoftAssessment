using ChilliSoftAssessment.Models;
using ChilliSoftDLL.DataAccess.Interfaces;
using ChilliSoftDLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSoftAssessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChilliDB db;

        public HomeController(ILogger<HomeController> logger,IChilliDB db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            var employees = db.GetAllEmployees();

            string UserName = User.Identity.Name;

            var matchedEmployees = employees.FirstOrDefault(m => m.EmployeeName == UserName || m.Email == UserName);

            if (UserName == string.Empty || matchedEmployees == null || matchedEmployees == new ChilliSoftDLL.Models.Employee())
            {
                Employee model = new Employee();

                model.EmployeeId = Guid.NewGuid().ToString();
                model.EmployeeStatus = "Employeed";
                model.EmployeePosition = "Member";
                model.Email = User.Identity.Name;
                model.EmployeeName = User.Identity.Name;

                db.AddEmployee(model);

            }

            return View();
        }

        public IActionResult CreateAccount(Employee model) {

            model.EmployeeId = Guid.NewGuid().ToString();
            model.EmployeeStatus = "Employeed";
            model.EmployeePosition = "Member";
            model.Email = User.Identity.Name;
            model.EmployeeName = User.Identity.Name;

            db.AddEmployee(model);

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

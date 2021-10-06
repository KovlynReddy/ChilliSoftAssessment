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


        [HttpGet]
        public IActionResult ViewAllReports() {

            return View(db.GetAllMeetings());
        }

        [HttpGet]
        public IActionResult ViewReport(string id) {
            #region RoomView
            //var meeting = db.GetAllMeetings().FirstOrDefault(m => m.MeetingId == id);
            //ViewReportViewModel model = new ViewReportViewModel();
            ////model._Meeting = meeting;

            //// join meeting by sending a message from sender with special code
            //var message = new Message();
            //message.MeetingId = id;
            //message.SenderId = User.Identity.Name;
            //message.TimeSent = DateTime.Now;
            //message.Body = "JoInInG";
            //message.ItemId = "Joined";
            //message.MessageId = Guid.NewGuid().ToString();
            //message.Type = "";

            //db.AddMessage(message);

            //// get state of cuttent BaseRoomViewModel
            //// get all messages and comments

            //var employees = db.GetAllEmployees();
            //List<Employee> attendies = new List<Employee>();
            //var meetings = db.GetAllMeetings().FirstOrDefault(m => m.MeetingId == id);
            //var messages = db.GetAllMessages().Where(m => m.MeetingId == id).Take(100).ToList();
            //var comments = db.GetAllMessages().Where(m => m.MeetingId == id).ToList();
            //var items = db.GetAllItems().Where(m => m.LastMeetingId == id).ToList();
            //List<MinutesEntry> minutes = new List<MinutesEntry>();
            //foreach (var item in items)
            //{
            //    minutes.AddRange(db.GetAllMinutes().Where(m => m.ItemId == item.ItemId).ToList());
            //}
            //var messagerids = messages.Select(p => p.SenderId).Distinct().ToList();
            //foreach (var msg in messagerids)
            //{
            //    attendies.Add(employees.FirstOrDefault(m => m.Email == msg));
            //}

            //// get all employees who sent messages to this meeting
            //model.MeetingId = id;
            //model.Atteendies = attendies;
            //model.Comments = comments;
            //model.Messages = messages;
            //model.Items = items;
            //// get all items associated with this meeting

            //return View("ViewReport", model);

            #endregion

            ViewReportViewModel model = new ViewReportViewModel();
            var selectedMeeting = db.GetAllMeetings().FirstOrDefault(m=>m.MeetingId == id);

            var allmessages = db.GetAllMessages().Where(m => m.MeetingId == selectedMeeting.MeetingId).ToList();
            var messages = allmessages.Where(m=>m.SenderId==selectedMeeting.MinutesMaster).ToList();
            var comments = allmessages.Where(m=>m.SenderId!=selectedMeeting.MinutesMaster).ToList();
            var allitems = db.GetAllItems();
            var items = db.GetAllItems().Where(m=>m.LastMeetingId ==selectedMeeting.MeetingId).ToList();

            List<Item> tempitems = new List<Item>();
            foreach (var obj in items)
            {
                tempitems.Add(allitems.FirstOrDefault(m=>m.ItemId==obj.ItemId && m.ItemName != null) );
            }

            foreach (var item in tempitems)
            {
                ReportListItemModel newitem = new ReportListItemModel();

                newitem.employeeName = item.EmployeeResponsible;
                newitem.itemName = item.Description;
                newitem.itemStatus = item.meetingstatus;
                newitem.MeetingId = selectedMeeting.MeetingId;
                model.items.Add(newitem);
                
            }


            ReportMessagesViewModel messagesmodel = new ReportMessagesViewModel();
            messagesmodel.Comments = comments;
            messagesmodel.Messages = messages;
            messagesmodel.meetingId = selectedMeeting.MeetingId;

            model.messages = messagesmodel ;

            return View(model);
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

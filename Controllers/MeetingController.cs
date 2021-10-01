using ChilliSoftAssessment.Models;
using ChilliSoftDLL.DataAccess.Interfaces;
using ChilliSoftDLL.Models;
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
        public IActionResult JoinMeeting(string id) {

            var meeting = db.GetAllMeetings().FirstOrDefault(m=>m.MeetingId == id);
            BaseRoomViewModel model = new BaseRoomViewModel();
            model._Meeting = meeting;

            // join meeting by sending a message from sender with special code

            // get state of cuttent BaseRoomViewModel
            // get all messages and comments
            // get all employees who sent messages to this meeting
            // get all items associated with this meeting

            return View("DemoRoom",model); }

        [HttpPost]
        public IActionResult SendMessage() { 
            // determine if the message is from the Minutes Master , Talker , or a Comment

            return View(); }
        [HttpPost]
        public IActionResult EditItemStatus() { 
            // choose from popup when changing Item
            // Add relevent Information

            return View(); }
        [HttpGet]
        public IActionResult RefreshRoom() { 
            //Get Meeting
            // Get Relevant Messages

            return View(); }


        [HttpGet]
        public IActionResult AddItem() { return View(); }
        [HttpPost]
        public IActionResult AddItem(Item model) {

            model.ItemId = Guid.NewGuid().ToString();

            db.AddItem(model);
            return View(); }

        [HttpPost]
        public IActionResult SceduleMeeting(SceduleMeetingViewModel model) {
            model.Employees = db.GetAllEmployees();
            model.Items = db.GetAllItems();

            var newmeeting = new Meeting();
            var assignedItem = new Item();
            var item = model.SelectedItem;

            if (model.Done)
            {
                newmeeting.MeetingId = Guid.NewGuid().ToString();
                newmeeting.MinutesMaster = User.Identity.Name;
                newmeeting.StartDateTime = model.DateSceduled;
                newmeeting.Caption = model.Caption;
                newmeeting.Type = model.Caption;
                assignedItem = new Item();
                assignedItem.ItemId = item;
                assignedItem.EmployeeResponsible = model.SelectedEmployee;
                model.SelectedItems.Add(assignedItem);

                foreach (var aitem in model.SelectedItems)
                {
                    
                    aitem.LastMeetingId = newmeeting.MeetingId ;

                    db.AddItem(aitem);
                } // asssign item , employee and minute master
   
                db.AddMeeting(newmeeting);
                return View("Index","Home");
            }
      
            assignedItem = new Item();
            assignedItem.ItemId = item;
            assignedItem.EmployeeResponsible = model.SelectedEmployee;
            model.SelectedItems.Add(assignedItem);
            return View(model); }

        [HttpGet]
        public IActionResult SceduleMeeting() {

            SceduleMeetingViewModel model = new SceduleMeetingViewModel();

            model.Employees = db.GetAllEmployees();
            model.Items = db.GetAllItems();

            return View(model);
        }


        [HttpGet]
        public IActionResult StartMeeting() { return View(); }

        [HttpGet]
        public IActionResult StartAMeeting() { 
           


            return View(); 
        }

        [HttpGet]
        public IActionResult Rooms() {

            var meetings = db.GetAllMeetings();


            return View("AvalibleRooms",meetings); }

        [HttpPost]
        public IActionResult JoinRoom(string id) {

            return View();
        }

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

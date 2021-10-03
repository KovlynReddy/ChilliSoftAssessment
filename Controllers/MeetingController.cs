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
            //model._Meeting = meeting;

            // join meeting by sending a message from sender with special code
            var message = new Message();
            message.MeetingId = id;
            message.SenderId = User.Identity.Name;
            message.TimeSent = DateTime.Now;
            message.Body = "JoInInG";
            message.ItemId = "Joined";
            message.MessageId = Guid.NewGuid().ToString();
            message.Type = "";

            db.AddMessage(message);
            
            // get state of cuttent BaseRoomViewModel
            // get all messages and comments
            
            var employees= db.GetAllEmployees();
            List<Employee> attendies = new List<Employee>();
            var meetings = db.GetAllMeetings().FirstOrDefault(m=>m.MeetingId == id);
            var messages = db.GetAllMessages().Where(m=>m.MeetingId == id).Take(100).ToList();
            var comments = db.GetAllMessages().Where(m=>m.MeetingId == id).ToList();
            var items = db.GetAllItems().Where(m=>m.LastMeetingId == id).ToList();
            List<MinutesEntry> minutes = new List<MinutesEntry>();
            foreach (var item in items)
            {
            minutes.AddRange(db.GetAllMinutes().Where(m=>m.ItemId == item.ItemId).ToList());
            }
            var messagerids = messages.Select(p => p.SenderId).Distinct().ToList();
            foreach (var msg in messagerids)
            {
                attendies.Add(employees.FirstOrDefault(m=>m.Email == msg));
            }

            // get all employees who sent messages to this meeting
            model.MeetingId = id;
            model.Atteendies = attendies ;
            model.Comments = comments;
            model.Messages = messages ;
            model.Items = items; 
            // get all items associated with this meeting

            return View("DemoRoom",model); }
            
        [HttpPost]
        public IActionResult SendMessage(BaseRoomViewModel newmessage) {

            var meeting = db.GetAllMeetings().FirstOrDefault(m => m.MeetingId == newmessage.MeetingId);
            BaseRoomViewModel model = new BaseRoomViewModel();
            //model._Meeting = meeting;

            // join meeting by sending a message from sender with special code
            var message = new Message();
            message.MeetingId = newmessage.MeetingId;
            message.SenderId = User.Identity.Name;
            message.TimeSent = DateTime.Now;
            message.Body = newmessage.Body;
            message.ItemId = newmessage.SelectedItemId;
            message.MessageId = Guid.NewGuid().ToString();
            message.Type = "Demo";

            db.AddMessage(message);

            // get state of cuttent BaseRoomViewModel
            // get all messages and comments

            var employees = db.GetAllEmployees();
            List<Employee> attendies = new List<Employee>();
            var meetings = db.GetAllMeetings().FirstOrDefault(m => m.MeetingId == newmessage.MeetingId);
            var messages = db.GetAllMessages().Where(m => m.MeetingId == newmessage.MeetingId).ToList();
            var comments = db.GetAllMessages().Where(m => m.MeetingId == newmessage.MeetingId).ToList();
            var items = db.GetAllItems().Where(m => m.LastMeetingId == newmessage.MeetingId).ToList();
            List<MinutesEntry> minutes = new List<MinutesEntry>();
            foreach (var item in items)
            {
                minutes.AddRange(db.GetAllMinutes().Where(m => m.ItemId == item.ItemId).ToList());
            }
            var messagerids = messages.Select(p => p.SenderId).Distinct().ToList();
            foreach (var msg in messagerids)
            {
                attendies.Add(employees.FirstOrDefault(m => m.Email == msg));
            }

            // get all employees who sent messages to this meeting
            model.MeetingId = newmessage.MeetingId;
            model.Atteendies = attendies;
            model.Comments = comments;
            model.Messages = messages;
            model.Items = items;
            // get all items associated with this meeting

            return View("DemoRoom", model);
            // determine if the message is from the Minutes Master , Talker , or a Comment

            return View();
        }
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
        [HttpPost]
        public IActionResult ChangeMeetingItem(BaseRoomViewModel model) {
            //Get Meeting
            var selectedmeeting = db.GetAllMeetings().FirstOrDefault(m=>m.MeetingId == model.MeetingId);
            var selecteditem = db.GetAllItems().FirstOrDefault(m=>m.ItemId == model.SelectedItemId);

            selecteditem.meetingstatus = model.SelectedItem;

            db.UpdateMeeting(selectedmeeting);
            db.UpdateItem(selecteditem);

            // Get Relevant Messages
            //selecteditem.meetingstatus;
            // update item status

            return View("JoinMeeting",new { id=model.MeetingId}); }


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
                newmeeting.StartDateTime = model.Date;
                assignedItem = new Item();
                assignedItem.ItemId = item;
                assignedItem.EmployeeResponsible = model.SelectedEmployee;
                model.SelectedItems.Add(assignedItem);

                foreach (var aitem in model.SelectedItems)
                {
                    
                    aitem.LastMeetingId = newmeeting.MeetingId ;
                    var thisitem = model.Items.FirstOrDefault(m => m.ItemId == aitem.ItemId);
                    aitem.Description = thisitem.Description;
                    aitem.Categorey = thisitem.Categorey;
                    aitem.EmployeeResponsible = model.SelectedEmployee;
                
                    db.AddItem(aitem);
                } // asssign item , employee and minute master
   
                db.AddMeeting(newmeeting);
                return View("Rooms");
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

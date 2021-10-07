using ChilliSoftAssessment.Models;
using ChilliSoftDLL.DataAccess.Interfaces;
using ChilliSoftDLL.Models;
using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public IActionResult InviteEmployees(string id) {

            InviteEmployeeViewModel model = new InviteEmployeeViewModel();

            model.MeetingId = id;
            model.employees = db.GetAllEmployees();


            return View(model); }
        public async Task<IActionResult> InviteEmployee(InviteEmployeeViewModel model)
        {

            var selectedEmployee = db.GetAllEmployees().FirstOrDefault(m => m.EmployeeId == model.SelectedEmployee);
            var selectedMeeting = db.GetAllMeetings().FirstOrDefault(m => m.MeetingId == model.MeetingId);

            // send invite to this employee via email

            await SendMail($"Please Attend the Meeting Sceduled for {selectedMeeting.StartDateTime}", selectedEmployee.Email);

            if (model.done)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("InviteEmployees", "Meeting", new { id = model.MeetingId });
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
            var items = db.GetAllItems().Where(m=>m.LastMeetingId == id && m.Description != null).ToList();
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

            var myprofile = db.GetAllEmployees().FirstOrDefault(m=>m.Email == User.Identity.Name);
            if (meeting.MinutesMaster == User.Identity.Name)
            {
                model.IsAdmin = true;
            }
            else { model.IsAdmin = false; }

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

            selecteditem.ItemTalker = selectedmeeting.Type;
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
            model.Items = db.GetAllItems().Where(m=>m.ItemName!=null).OrderBy(m => m.ItemTalker).ToList();

            var newmeeting = new Meeting();
            var assignedItem = new Item();
            var item = model.SelectedItem;

            if (model.Done)
            {
                newmeeting.MeetingId = Guid.NewGuid().ToString();
                newmeeting.MinutesMaster = User.Identity.Name;
                newmeeting.StartDateTime = model.DateSceduled;
                newmeeting.Caption = model.Caption;
                newmeeting.Type = model.MeetingType;
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
                return RedirectToAction("InviteEmployees","Meeting",new {id = newmeeting.MeetingId });
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
            model.Items = db.GetAllItems().Where(m=>m.ItemName!=null).OrderBy(m=>m.ItemTalker).ToList();

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
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }

        }
        public async Task SendMail(string amessage, string address)
        {

            #region mail1

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Credentials = new System.Net.NetworkCredential("Techno Solutions01", "T3$0em01");
            client.Port = 587;
            client.EnableSsl = true;
            // Specify the email sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress("TechnoSolutions0001@gmail.com",
               "Techno" + (char)0xD8 + "Solutions01", System.Text.Encoding.UTF8);
            // Set destinations for the email message.
            MailAddress to = new MailAddress(address);
            // Specify the message content.

            MailMessage message = new MailMessage(from, to);

            message.Body = " " + amessage;
            // Include some non-ASCII characters in body and subject.
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message.Body += Environment.NewLine + someArrows;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "Meeting Invite " + someArrows;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            // Set the method that is called back when the send operation ends.
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            // The userState can be any object that allows your callback
            // method to identify this send operation.
            // For this example, the userToken is a string constant.


            //client.Send(message);

            #endregion

            #region Mail2

            var sender = new SmtpSender(() => new SmtpClient(host: "smtp.gmail.com")
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 587,
                Credentials = new NetworkCredential("TechnoSolutions0001@gmail.com", "T3$0em01")
            });

            Email.DefaultSender = sender;

            var email = await Email
                .From(emailAddress: "TechnoSolutions0001@gmail.com")
                .To(emailAddress: address, name: "Hi User")
                .Subject(subject: " Meeting Invite ")
                .Body(body: "Please Take Note Of the Following :  \n" + amessage)
                .SendAsync();

            int result = 0;
            #endregion
        }

    }
}

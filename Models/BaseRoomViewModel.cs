using ChilliSoftDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSoftAssessment.Models
{
    public class BaseRoomViewModel
    {
        public string RoomId { get; set; }
        public string MeetingId { get; set; }
        //public Meeting _Meeting { get; set; }
        public List<Message> Comments { get; set; } = new List<Message>(); // messages by attendies
        public List<Message> Messages { get; set; } = new List<Message>(); // message sent by minutemaster

        public List<Item> Items { get; set; } = new List<Item>();// for admin
        //public Item SelectedItem { get; set; } 
        public string SelectedItem { get; set; } 
        public string SelectedItemId { get; set; } 
        public List<Employee> Atteendies { get; set; } = new List<Employee>();
        public string Body { get; set; } // message for everyone
        public string MinutesMasterId { get; set; }
        public bool Live { get; set; }
        public bool IsAdmin { get; set; }
        public Employee MinutesMaster { get; set; }
    }
}

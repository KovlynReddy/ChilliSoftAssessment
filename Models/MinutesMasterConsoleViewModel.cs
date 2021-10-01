using ChilliSoftDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSoftAssessment.Models
{
    public class MinutesMasterConsoleViewModel
    {
        public List<string> Messages { get; set; } = new List<string>();
        public List<string> Comments { get; set; } = new List<string>();
        public List<string> AttendyIds { get; set; } = new List<string>();
        public List<Item> Items { get; set; } = new List<Item>();
        public bool isLive { get; set; }
        public string meetingId { get; set; }
        public string MinuteMasterId { get; set; }
    }
}

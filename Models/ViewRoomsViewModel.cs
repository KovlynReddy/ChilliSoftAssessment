using ChilliSoftDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSoftAssessment.Models
{
    public class ViewRoomsViewModel
    {
        public List<Room> Rooms { get; set; } = new List<Room>();
        public Room Choice { get; set; }
        public List<string> MinuteMasters { get; set; } = new List<string>();
        public List<string> Titles { get; set; } = new List<string>();
    }
}

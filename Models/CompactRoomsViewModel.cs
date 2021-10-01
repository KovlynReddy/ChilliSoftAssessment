using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSoftAssessment.Models
{
    public class CompactRoomsViewModel
    {
        public List<RoomHeadViewModel> Rooms { get; set; } = new List<RoomHeadViewModel>();
        public RoomHeadViewModel Choice { get; set; }
    }
}

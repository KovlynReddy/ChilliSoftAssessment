using ChilliSoftDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSoftAssessment.Models
{
    public class ReportMessagesViewModel
    {
        public List<Message> Messages { get; set; }
        public List<Message> Comments { get; set; }
        public string meetingId { get; set; }
    }
}

using ChilliSoftDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSoftAssessment.Models
{
    public class ReportListItemModel
    {
        public string MeetingId { get; set; }
        public string employeeName { get; set; }
        public string itemName { get; set; }
        public string itemStatus { get; set; }
    }
}

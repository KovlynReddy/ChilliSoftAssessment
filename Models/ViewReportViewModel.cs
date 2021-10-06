using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSoftAssessment.Models
{
    public class ViewReportViewModel : BaseRoomViewModel
    {
        public ReportMessagesViewModel messages { get; set; }
        public List<ReportListItemModel> items { get; set; } = new List<ReportListItemModel>();


    }
}

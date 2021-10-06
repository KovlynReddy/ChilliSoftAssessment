using ChilliSoftDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSoftAssessment.Models
{
    public class InviteEmployeeViewModel
    {
        public string MeetingId { get; set; }
        public List<Employee> employees { get; set; } = new List<Employee>();
        public string SelectedEmployee { get; set; }
        public bool done { get; set; }
    }
}

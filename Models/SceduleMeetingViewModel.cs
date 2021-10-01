using ChilliSoftDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSoftAssessment.Models
{
    public class SceduleMeetingViewModel
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
        public List<Item> SelectedItems { get; set; } = new List<Item>();
        public Item SelectedItem { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Employee> SelectedEmployees { get; set; } = new List<Employee>();
        public Employee SelectedEmployee { get; set; }

        public DateTime DateSceduled { get; set; }

        public string Caption { get; set; }
        public bool Done { get; set; }
    }
}

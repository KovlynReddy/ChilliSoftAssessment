using ChilliSoftDLL.DataAccess.Interfaces;
using ChilliSoftDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilliSoftAssessment.Data
{
    public class MeetingsProccessor : IChilliDB
    {
        private readonly ApplicationDbContext db;

        public MeetingsProccessor(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Employee AddEmployee(Employee entity)
        {
            db.Employees.Add(entity);

            db.SaveChanges();

            return entity;
        }

        public Item AddItem(Item entity)
        {
            db.Items.Add(entity);

            db.SaveChanges();

            return entity;
        }

        public Meeting AddMeeting(Meeting entity)
        {
            db.Meetings.Add(entity);

            db.SaveChanges();

            return entity;
        }

        public Message AddMessage(Message entity)
        {
            db.Messages.Add(entity);

            db.SaveChanges();

            return entity;
        }

        public MinutesEntry AddMinutes(MinutesEntry entity)
        {
            db.MinutesEntry.Add(entity);

            db.SaveChanges();

            return entity;
        }

        public Report AddReport(Report entity)
        {
            db.Reports.Add(entity);

            db.SaveChanges();

            return entity;
        }

        public Employee DeleteEmployee(Employee entity)
        {
            db.Employees.Remove(entity);

            db.SaveChanges();

            return entity;
        }

        public Item DeleteItem(Item entity)
        {
            db.Items.Remove(entity);

            db.SaveChanges();

            return entity;
        }

        public Message DeleteMessage(Message entity)
        {
            db.Messages.Remove(entity);

            db.SaveChanges();

            return entity;
        }

        public MinutesEntry DeleteMinutes(MinutesEntry entity)
        {
            db.MinutesEntry.Remove(entity);

            db.SaveChanges();

            return entity;
        }

        public Report DeleteReport(Report entity)
        {
            db.Reports.Remove(entity);

            db.SaveChanges();

            return entity;
        }

        public List<Item> FilterItems(string query)
        {
            var items = db.Items.ToList();

            items = items.Where( i => i.ItemName.Contains(query)).ToList();

            return items;
        }

        public List<Meeting> FilterMeetings(string query)
        {
            throw new NotImplementedException();
        }

        public List<Message> FilterMessages(string query)
        {
            throw new NotImplementedException();
        }

        public List<MinutesEntry> FilterMinutes(string query)
        {
            throw new NotImplementedException();
        }

        public List<Report> FilterRepoer(string query)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            return db.Employees.ToList();
        }

        public List<Item> GetAllItems()
        {
            return db.Items.ToList();
        }

        public List<Meeting> GetAllMeetings()
        {
            return db.Meetings.ToList();
        }

        public List<Message> GetAllMessages()
        {
            return db.Messages.ToList();
        }

        public List<MinutesEntry> GetAllMinutes()
        {
            return db.MinutesEntry.ToList();
        }

        public List<Report> GetAllReport()
        {
            return db.Reports.ToList();
        }

        public Item GetItem(Item entity)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(string entity)
        {
            var iitems = db.Items.ToList();
            var item = iitems.FirstOrDefault(m=>m.ItemId == entity);

            return item;
        }

        public Meeting GetMeeting(Meeting entity)
        {
            throw new NotImplementedException();
        }

        public Meeting GetMeeting(string entity)
        {
            var iitems = db.Meetings.ToList();
            var item = iitems.FirstOrDefault(m => m.MeetingId == entity);

            return item;
        }

        public Message GetMessage(Message entity)
        {
            var iitems = db.Messages.ToList();
            var item = iitems.FirstOrDefault(m => m.MessageId == entity.MessageId);

            return item;
        }

        public Message GetMessage(string entity)
        {
            var iitems = db.Messages.ToList();
            var item = iitems.FirstOrDefault(m => m.MessageId == entity);

            return item;
        }

        public MinutesEntry GetMinutes(MinutesEntry entity)
        {
            throw new NotImplementedException();
        }

        public MinutesEntry GetMinutes(string entity)
        {
            var iitems = db.MinutesEntry.ToList();
            var item = iitems.FirstOrDefault(m => m.MinutesId == entity);

            return item;
        }

        public Report GetReport(Report entity)
        {
            throw new NotImplementedException();
        }

        public Report GetReport(string entity)
        {
            var iitems = db.Reports.ToList();
            var item = iitems.FirstOrDefault(m => m.ReportsId == entity);

            return item;
        }

        public Employee UpdateEmployee(Employee entity)
        {
            var selectedentity = db.Employees.FirstOrDefault(m => m.EmployeeId == entity.EmployeeId);
            selectedentity.EmployeePosition = entity.EmployeePosition;
            selectedentity.EmployeeStatus = entity.EmployeeStatus;
            selectedentity.EmployeeName = entity.EmployeeName;

            db.Entry(selectedentity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

            return selectedentity;

        }

        public Item UpdateItem(Item entity)
        {
            var selectedentity = db.Items.FirstOrDefault(m => m.ItemId == entity.ItemId);
            selectedentity.ItemName = entity.ItemId;
            selectedentity.Categorey = entity.Categorey;
            selectedentity.Description = entity.Description;
            selectedentity.EmployeeResponsible = entity.EmployeeResponsible;
            selectedentity.ItemId = entity.ItemId;
            selectedentity.LastMeetingId = entity.LastMeetingId;
            selectedentity.meetingstatus = entity.meetingstatus;
            selectedentity.ItemTalker = entity.ItemTalker;

            db.Entry(selectedentity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

            return selectedentity;
        }

        public Meeting UpdateMeeting(Meeting entity)
        {
            var selectedentity = db.Meetings.FirstOrDefault(m => m.MeetingId == entity.MeetingId);
            selectedentity.EndDateTime = entity.EndDateTime;
            selectedentity.StartDateTime = entity.StartDateTime;
            selectedentity.HoursDuration = entity.HoursDuration;
            selectedentity.MinutesMaster = entity.MinutesMaster;
            selectedentity.TimeElapsed = entity.TimeElapsed;
            selectedentity.Type = entity.Type;
            //selectedentity. = entity.EmployeeName;

            db.Entry(selectedentity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

            return selectedentity;
        }

        public Message UpdateMessage(Message entity)
        {
            throw new NotImplementedException();
        }

        public MinutesEntry UpdateMinutes(MinutesEntry entity)
        {
            var selectedentity = db.MinutesEntry.FirstOrDefault(m => m.MinutesId == entity.MinutesId);
            selectedentity.MinutesMasterId = entity.MinutesMasterId;
            selectedentity.EmployeeId = entity.EmployeeId;
            selectedentity.ItemId = entity.ItemId;
            selectedentity.MinutesId = entity.MinutesId;
            selectedentity.MinutesMasterId = entity.MinutesMasterId;
            selectedentity.Notes = entity.Notes;
            selectedentity.Remarks = entity.Remarks;
            //selectedentity.Remarks = entity.EmployeeName;

            db.Entry(selectedentity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

            return selectedentity;
        }

        public Report UpdateReport(Report entity)
        {
            var selectedentity = db.Reports.FirstOrDefault(m => m.ReportsId == entity.ReportsId);
            selectedentity.ReportsId = entity.ReportsId;
            selectedentity.ReportName = entity.ReportName;
            selectedentity.ReportDescription = entity.ReportDescription;
            selectedentity.Remarks = entity.Remarks;
            selectedentity.Rateing = entity.Rateing;
            //selectedentity. = entity.EmployeeName;

            db.Entry(selectedentity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

            return selectedentity;
        }
    }
}

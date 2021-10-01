using ChilliSoftDLL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChilliSoftAssessment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>().HasData(new Employee { id = 1 , EmployeeId = "EMID01", EmployeeName = "KovlynReddy" , EmployeePosition = "Executive" , EmployeeStatus = "Employeed"},
                                               new Employee { id = 2, EmployeeId = "EMID02", EmployeeName = "KatelynReddy", EmployeePosition = "Member", EmployeeStatus = "Employeed" },
                                               new Employee { id = 3, EmployeeId = "EMID03", EmployeeName = "ShanMchelm", EmployeePosition = "MinutesMaster", EmployeeStatus = "Employeed" }
                                                );

            base.OnModelCreating(builder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MinutesEntry> MinutesEntry { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}

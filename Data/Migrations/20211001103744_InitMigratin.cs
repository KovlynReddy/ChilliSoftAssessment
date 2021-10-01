using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilliSoftAssessment.Data.Migrations
{
    public partial class InitMigratin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    EmployeeStatus = table.Column<string>(nullable: true),
                    EmployeePosition = table.Column<string>(nullable: true),
                    ep = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(nullable: true),
                    Categorey = table.Column<string>(nullable: true),
                    ms = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EmployeeResponsible = table.Column<string>(nullable: true),
                    ItemTalker = table.Column<string>(nullable: true),
                    LastMeetingId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    TimeElapsed = table.Column<DateTime>(nullable: false),
                    HoursDuration = table.Column<int>(nullable: false),
                    MinutesMaster = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    mt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MinutesEntry",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinutesId = table.Column<string>(nullable: true),
                    ItemId = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    MinutesMasterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinutesEntry", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportsId = table.Column<string>(nullable: true),
                    ReportName = table.Column<string>(nullable: true),
                    ReportDescription = table.Column<string>(nullable: true),
                    Rateing = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "id", "EmployeeId", "EmployeeName", "EmployeePosition", "EmployeeStatus", "ep" },
                values: new object[] { 1, "EMID01", "KovlynReddy", "Executive", "Employeed", 0 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "id", "EmployeeId", "EmployeeName", "EmployeePosition", "EmployeeStatus", "ep" },
                values: new object[] { 2, "EMID02", "KatelynReddy", "Member", "Employeed", 0 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "id", "EmployeeId", "EmployeeName", "EmployeePosition", "EmployeeStatus", "ep" },
                values: new object[] { 3, "EMID03", "ShanMchelm", "MinutesMaster", "Employeed", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "MinutesEntry");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}

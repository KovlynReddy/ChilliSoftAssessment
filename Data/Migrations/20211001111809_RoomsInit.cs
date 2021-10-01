using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilliSoftAssessment.Data.Migrations
{
    public partial class RoomsInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<string>(nullable: true),
                    MeetingId = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    TimeSent = table.Column<DateTime>(nullable: false),
                    ItemId = table.Column<string>(nullable: true),
                    SenderId = table.Column<string>(nullable: true),
                    RoomId = table.Column<string>(nullable: true),
                    MinutesMaster = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    TimeStarted = table.Column<DateTime>(nullable: false),
                    TimeEnded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}

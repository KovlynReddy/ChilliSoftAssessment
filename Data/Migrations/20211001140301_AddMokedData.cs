using Microsoft.EntityFrameworkCore.Migrations;

namespace ChilliSoftAssessment.Data.Migrations
{
    public partial class AddMokedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "Meetings",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "id", "Categorey", "Description", "EmployeeResponsible", "ItemId", "ItemName", "ItemTalker", "LastMeetingId", "ms" },
                values: new object[] { 1, "Discussion", "Disucessing new potencial projects", "EMID01", "ProjectId1", "Project Meeting", null, null, 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "id", "Categorey", "Description", "EmployeeResponsible", "ItemId", "ItemName", "ItemTalker", "LastMeetingId", "ms" },
                values: new object[] { 2, "Discussion", "Disucessing potencial project fixes", "EMID02", "ProjectId2", "Project Discussion", null, null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "Meetings");
        }
    }
}

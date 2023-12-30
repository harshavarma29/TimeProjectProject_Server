using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTableProject.Data.TimetableMigrations
{
    /// <inheritdoc />
    public partial class Timetable_V7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoursPerDay",
                table: "TimeDetails",
                newName: "ClassesPerDay");

            migrationBuilder.AddColumn<string>(
                name: "ClassDuration",
                table: "TimeDetails",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassDuration",
                table: "TimeDetails");

            migrationBuilder.RenameColumn(
                name: "ClassesPerDay",
                table: "TimeDetails",
                newName: "HoursPerDay");
        }
    }
}

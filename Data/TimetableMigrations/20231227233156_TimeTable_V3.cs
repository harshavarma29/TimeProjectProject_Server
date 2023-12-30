using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTableProject.Data.TimeTableMigrations
{
    /// <inheritdoc />
    public partial class TimeTable_V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BreakDuration",
                table: "TimeDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolStartTime",
                table: "TimeDetails",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakDuration",
                table: "TimeDetails");

            migrationBuilder.DropColumn(
                name: "SchoolStartTime",
                table: "TimeDetails");
        }
    }
}

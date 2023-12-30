using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTableProject.Data.TimeTableMigrations
{
    /// <inheritdoc />
    public partial class TimeTable_V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysPerWeek",
                table: "TimeDetails");

            migrationBuilder.AddColumn<string>(
                name: "Days",
                table: "TimeDetails",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Days",
                table: "TimeDetails");

            migrationBuilder.AddColumn<int>(
                name: "DaysPerWeek",
                table: "TimeDetails",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTableProject.Data.TimetableMigrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AttendanceType = table.Column<string>(type: "TEXT", nullable: true),
                    Batch = table.Column<string>(type: "TEXT", nullable: true),
                    ClassTime = table.Column<string>(type: "TEXT", nullable: true),
                    ClassMode = table.Column<string>(type: "TEXT", nullable: true),
                    ClassRoom = table.Column<string>(type: "TEXT", nullable: true),
                    SubjectDuration = table.Column<string>(type: "TEXT", nullable: true),
                    SubjectName = table.Column<string>(type: "TEXT", nullable: true),
                    Term = table.Column<string>(type: "TEXT", nullable: true),
                    TrainerName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeTable");
        }
    }
}

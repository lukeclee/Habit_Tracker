using Microsoft.EntityFrameworkCore.Migrations;

namespace Habit_Tracker.Migrations
{
    public partial class addResetFieldToHabits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Reset",
                table: "Habit",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reset",
                table: "Habit");
        }
    }
}

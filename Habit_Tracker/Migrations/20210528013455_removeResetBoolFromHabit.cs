using Microsoft.EntityFrameworkCore.Migrations;

namespace Habit_Tracker.Migrations
{
    public partial class removeResetBoolFromHabit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reset",
                table: "Habit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Reset",
                table: "Habit",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

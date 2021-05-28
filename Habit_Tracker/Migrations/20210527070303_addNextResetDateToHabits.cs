using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Habit_Tracker.Migrations
{
    public partial class addNextResetDateToHabits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NextReset",
                table: "Habit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextReset",
                table: "Habit");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Migrations
{
    /// <inheritdoc />
    public partial class AddedLectureTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Lectures",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 1, 30, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Lectures",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldDefaultValue: new TimeSpan(0, 1, 30, 0, 0));
        }
    }
}

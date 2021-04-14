using Microsoft.EntityFrameworkCore.Migrations;

namespace School_Database.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marks",
                table: "StudentModel");

            migrationBuilder.AddColumn<int>(
                name: "C_Marks",
                table: "StudentModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OOPS_Marks",
                table: "StudentModel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "C_Marks",
                table: "StudentModel");

            migrationBuilder.DropColumn(
                name: "OOPS_Marks",
                table: "StudentModel");

            migrationBuilder.AddColumn<float>(
                name: "Marks",
                table: "StudentModel",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}

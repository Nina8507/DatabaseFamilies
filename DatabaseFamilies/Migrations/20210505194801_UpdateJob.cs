using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseFamilies.Migrations
{
    public partial class UpdateJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EyeColor",
                table: "ChildTable");

            migrationBuilder.DropColumn(
                name: "EyeColor",
                table: "AdultTable");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Job",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Job",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EyeColor",
                table: "ChildTable",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EyeColor",
                table: "AdultTable",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

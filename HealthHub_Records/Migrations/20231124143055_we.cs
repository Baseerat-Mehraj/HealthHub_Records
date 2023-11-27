using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthHub_Records.Migrations
{
    /// <inheritdoc />
    public partial class we : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Request",
                table: "HospitalRegs");

            migrationBuilder.AddColumn<bool>(
                name: "Request",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Request",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "Request",
                table: "HospitalRegs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

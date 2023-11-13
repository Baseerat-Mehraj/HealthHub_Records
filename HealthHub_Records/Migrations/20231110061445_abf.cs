using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthHub_Records.Migrations
{
    /// <inheritdoc />
    public partial class abf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "Appoinment");

            migrationBuilder.RenameColumn(
                name: "HospitalName",
                table: "Appoinment",
                newName: "HospitalDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HospitalDetails",
                table: "Appoinment",
                newName: "HospitalName");

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "Appoinment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

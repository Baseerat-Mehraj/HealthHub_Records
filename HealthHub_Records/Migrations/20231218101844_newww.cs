using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthHub_Records.Migrations
{
    /// <inheritdoc />
    public partial class newww : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "phoneno",
                table: "PatientRegs",
                type: "bigint",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "phoneno",
                table: "HospitalRegs",
                type: "bigint",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "phoneno",
                table: "PatientRegs",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "phoneno",
                table: "HospitalRegs",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 20);
        }
    }
}

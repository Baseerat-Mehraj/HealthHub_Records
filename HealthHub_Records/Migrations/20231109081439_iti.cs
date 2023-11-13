using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthHub_Records.Migrations
{
    /// <inheritdoc />
    public partial class iti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diabetic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DDiabetic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DBloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DAllergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnyMedication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DAnyMedication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asthematic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DAsthematic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriousInjury = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DSeriousInjury = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousInjury = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DPreviousInjury = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherProblem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOtherProblem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalDescription_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalDescription_userid",
                table: "MedicalDescription",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalDescription");
        }
    }
}

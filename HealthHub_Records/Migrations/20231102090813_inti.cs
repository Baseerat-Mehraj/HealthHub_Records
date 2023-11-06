using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthHub_Records.Migrations
{
    public partial class inti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isactive = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "HospitalRegs",
                columns: table => new
                {
                    Hospitalid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pincode = table.Column<int>(type: "int", nullable: false),
                    phoneno = table.Column<int>(type: "int", nullable: false),
                    licienceno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalRegs", x => x.Hospitalid);
                    table.ForeignKey(
                        name: "FK_HospitalRegs_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateTable(
                name: "PatientRegs",
                columns: table => new
                {
                    patientid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pincode = table.Column<int>(type: "int", nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phoneno = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRegs", x => x.patientid);
                    table.ForeignKey(
                        name: "FK_PatientRegs_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HospitalRegs_userid",
                table: "HospitalRegs",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRegs_userid",
                table: "PatientRegs",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalRegs");

            migrationBuilder.DropTable(
                name: "PatientRegs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

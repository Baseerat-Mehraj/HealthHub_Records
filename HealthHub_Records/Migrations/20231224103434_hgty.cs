using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthHub_Records.Migrations
{
    /// <inheritdoc />
    public partial class hgty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Reports",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Reports",
                newName: "title");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeEmploymentManagement.Migrations
{
    /// <inheritdoc />
    public partial class RemoveActiveFromCafe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Cafes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Cafes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

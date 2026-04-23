using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLostandFoundSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressAndContactToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Items");
        }
    }
}

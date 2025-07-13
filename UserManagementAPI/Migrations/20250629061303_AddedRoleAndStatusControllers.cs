using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedRoleAndStatusControllers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateofBirth",
                table: "UserDetails",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Statuses",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "UserDetails",
                newName: "DateofBirth");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Statuses",
                newName: "CreatedDate");
        }
    }
}

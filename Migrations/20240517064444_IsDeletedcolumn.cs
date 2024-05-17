using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multiple_Images_Upload_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class IsDeletedcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EmployeeTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "EmployeeTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeeTable");
        }
    }
}

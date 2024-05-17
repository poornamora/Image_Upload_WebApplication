using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multiple_Images_Upload_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class PhotoNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "EmployeeTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EmployeeTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoName",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "EmployeeTable");
        }
    }
}

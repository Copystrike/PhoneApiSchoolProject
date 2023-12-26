using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneApiSchoolProject.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OsModel",
                table: "OsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppsModel",
                table: "AppsModel");

            migrationBuilder.RenameTable(
                name: "OsModel",
                newName: "PhoneOs");

            migrationBuilder.RenameTable(
                name: "AppsModel",
                newName: "PhoneApps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneOs",
                table: "PhoneOs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneApps",
                table: "PhoneApps",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneOs",
                table: "PhoneOs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneApps",
                table: "PhoneApps");

            migrationBuilder.RenameTable(
                name: "PhoneOs",
                newName: "OsModel");

            migrationBuilder.RenameTable(
                name: "PhoneApps",
                newName: "AppsModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OsModel",
                table: "OsModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppsModel",
                table: "AppsModel",
                column: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneApiSchoolProject.Migrations
{
    /// <inheritdoc />
    public partial class keys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_Phones_OsId",
                table: "Phones",
                column: "OsId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneApps_CompatibleOsId",
                table: "PhoneApps",
                column: "CompatibleOsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneApps_PhoneOs_CompatibleOsId",
                table: "PhoneApps",
                column: "CompatibleOsId",
                principalTable: "PhoneOs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_PhoneOs_OsId",
                table: "Phones",
                column: "OsId",
                principalTable: "PhoneOs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneApps_PhoneOs_CompatibleOsId",
                table: "PhoneApps");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_PhoneOs_OsId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_OsId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_PhoneApps_CompatibleOsId",
                table: "PhoneApps");
        }
    }
}

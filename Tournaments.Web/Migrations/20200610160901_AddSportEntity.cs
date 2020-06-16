using Microsoft.EntityFrameworkCore.Migrations;

namespace Tournaments.Web.Migrations
{
    public partial class AddSportEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_SportEntity_SportId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SportEntity",
                table: "SportEntity");

            migrationBuilder.RenameTable(
                name: "SportEntity",
                newName: "Sports");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sports",
                table: "Sports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Sports_SportId",
                table: "Tournaments",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Sports_SportId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sports",
                table: "Sports");

            migrationBuilder.RenameTable(
                name: "Sports",
                newName: "SportEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SportEntity",
                table: "SportEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_SportEntity_SportId",
                table: "Tournaments",
                column: "SportId",
                principalTable: "SportEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

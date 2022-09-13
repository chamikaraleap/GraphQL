using Microsoft.EntityFrameworkCore.Migrations;

namespace CommanderGQL.Migrations
{
    public partial class init_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commands_Platforms_PlatformId1",
                table: "Commands");

            migrationBuilder.DropIndex(
                name: "IX_Commands_PlatformId1",
                table: "Commands");

            migrationBuilder.DropColumn(
                name: "PlatformId1",
                table: "Commands");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlatformId1",
                table: "Commands",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commands_PlatformId1",
                table: "Commands",
                column: "PlatformId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Commands_Platforms_PlatformId1",
                table: "Commands",
                column: "PlatformId1",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class PacketPacketCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacketCategoryId",
                table: "Packets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Packets_PacketCategoryId",
                table: "Packets",
                column: "PacketCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packets_PacketCategories_PacketCategoryId",
                table: "Packets",
                column: "PacketCategoryId",
                principalTable: "PacketCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packets_PacketCategories_PacketCategoryId",
                table: "Packets");

            migrationBuilder.DropIndex(
                name: "IX_Packets_PacketCategoryId",
                table: "Packets");

            migrationBuilder.DropColumn(
                name: "PacketCategoryId",
                table: "Packets");
        }
    }
}

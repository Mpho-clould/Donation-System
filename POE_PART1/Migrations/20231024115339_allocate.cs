using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POE_PART1.Migrations
{
    public partial class allocate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsAllocation_disaster_disastersId",
                table: "GoodsAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsAllocation_GoodsDonation_GoodsDonationsId",
                table: "GoodsAllocation");

            migrationBuilder.DropIndex(
                name: "IX_GoodsAllocation_disastersId",
                table: "GoodsAllocation");

            migrationBuilder.DropIndex(
                name: "IX_GoodsAllocation_GoodsDonationsId",
                table: "GoodsAllocation");

            migrationBuilder.DropColumn(
                name: "GoodsDonationsId",
                table: "GoodsAllocation");

            migrationBuilder.DropColumn(
                name: "disastersId",
                table: "GoodsAllocation");

            migrationBuilder.AlterColumn<string>(
                name: "Distaster_Name",
                table: "GoodsAllocation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "GoodsAllocation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsAllocation_CategoryName",
                table: "GoodsAllocation",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsAllocation_Distaster_Name",
                table: "GoodsAllocation",
                column: "Distaster_Name");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsAllocation_activeDisaster_Distaster_Name",
                table: "GoodsAllocation",
                column: "Distaster_Name",
                principalTable: "activeDisaster",
                principalColumn: "Distaster_Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsAllocation_Category_CategoryName",
                table: "GoodsAllocation",
                column: "CategoryName",
                principalTable: "Category",
                principalColumn: "CategoryName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsAllocation_activeDisaster_Distaster_Name",
                table: "GoodsAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsAllocation_Category_CategoryName",
                table: "GoodsAllocation");

            migrationBuilder.DropIndex(
                name: "IX_GoodsAllocation_CategoryName",
                table: "GoodsAllocation");

            migrationBuilder.DropIndex(
                name: "IX_GoodsAllocation_Distaster_Name",
                table: "GoodsAllocation");

            migrationBuilder.AlterColumn<string>(
                name: "Distaster_Name",
                table: "GoodsAllocation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "GoodsAllocation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "GoodsDonationsId",
                table: "GoodsAllocation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "disastersId",
                table: "GoodsAllocation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoodsAllocation_disastersId",
                table: "GoodsAllocation",
                column: "disastersId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsAllocation_GoodsDonationsId",
                table: "GoodsAllocation",
                column: "GoodsDonationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsAllocation_disaster_disastersId",
                table: "GoodsAllocation",
                column: "disastersId",
                principalTable: "disaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsAllocation_GoodsDonation_GoodsDonationsId",
                table: "GoodsAllocation",
                column: "GoodsDonationsId",
                principalTable: "GoodsDonation",
                principalColumn: "Id");
        }
    }
}

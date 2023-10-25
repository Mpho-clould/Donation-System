using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POE_PART1.Migrations
{
    public partial class newdatabbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "activeDisaster",
                columns: table => new
                {
                    Distaster_Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aid_Types = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activeDisaster", x => x.Distaster_Name);
                });

            migrationBuilder.CreateTable(
                name: "MoneysAllocate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distaster_Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneysAllocate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneysAllocate_activeDisaster_Distaster_Name",
                        column: x => x.Distaster_Name,
                        principalTable: "activeDisaster",
                        principalColumn: "Distaster_Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoneysAllocate_Distaster_Name",
                table: "MoneysAllocate",
                column: "Distaster_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoneysAllocate");

            migrationBuilder.DropTable(
                name: "activeDisaster");

           

         
        }
    }
}

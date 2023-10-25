using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POE_PART1.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

           

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryName);
                });

            migrationBuilder.CreateTable(
                name: "disaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anonymous = table.Column<bool>(type: "bit", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distaster_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aid_Types = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monetary_donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anonymous = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monetary_donations", x => x.Id);
                });

         

          

          
        

            migrationBuilder.CreateTable(
                name: "GoodsDonation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anonymous = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number_of_Iteams = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsDonation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsDonation_Category_CategoryName",
                        column: x => x.CategoryName,
                        principalTable: "Category",
                        principalColumn: "CategoryName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoneyAllocate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distaster_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    disastersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyAllocate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyAllocate_disaster_disastersId",
                        column: x => x.disastersId,
                        principalTable: "disaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GoodsAllocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distaster_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number_of_Iteams = table.Column<int>(type: "int", nullable: false),
                    disastersId = table.Column<int>(type: "int", nullable: true),
                    GoodsDonationsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsAllocation_disaster_disastersId",
                        column: x => x.disastersId,
                        principalTable: "disaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GoodsAllocation_GoodsDonation_GoodsDonationsId",
                        column: x => x.GoodsDonationsId,
                        principalTable: "GoodsDonation",
                        principalColumn: "Id");
                });


           


            migrationBuilder.CreateIndex(
                name: "IX_GoodsAllocation_disastersId",
                table: "GoodsAllocation",
                column: "disastersId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsAllocation_GoodsDonationsId",
                table: "GoodsAllocation",
                column: "GoodsDonationsId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsDonation_CategoryName",
                table: "GoodsDonation",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyAllocate_disastersId",
                table: "MoneyAllocate",
                column: "disastersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
       

            migrationBuilder.DropTable(
                name: "GoodsAllocation");

            migrationBuilder.DropTable(
                name: "Monetary_donations");

            migrationBuilder.DropTable(
                name: "MoneyAllocate");

           

          

            migrationBuilder.DropTable(
                name: "GoodsDonation");

            migrationBuilder.DropTable(
                name: "disaster");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}

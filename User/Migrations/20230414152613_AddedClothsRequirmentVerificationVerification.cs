using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Migrations
{
    /// <inheritdoc />
    public partial class AddedClothsRequirmentVerificationVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClothsRequirmentVerifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsTears = table.Column<bool>(type: "bit", nullable: false),
                    TearsPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FabricType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeTypeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReceiptAvailable = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfCloths = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothsRequirmentVerifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClothsRequirmentVerifications_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothsRequirmentVerifications_ProductID",
                table: "ClothsRequirmentVerifications",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothsRequirmentVerifications");
        }
    }
}

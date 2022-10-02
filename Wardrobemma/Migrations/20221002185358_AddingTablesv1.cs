using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobemma.Migrations
{
    public partial class AddingTablesv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GarmentColour",
                columns: table => new
                {
                    GarmentColourID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentColour", x => x.GarmentColourID);
                });

            migrationBuilder.CreateTable(
                name: "GarmentMaterial",
                columns: table => new
                {
                    GarmentMaterialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Natural = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentMaterial", x => x.GarmentMaterialID);
                });

            migrationBuilder.CreateTable(
                name: "GarmentPrimaryType",
                columns: table => new
                {
                    GarmentPrimaryTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentPrimaryType", x => x.GarmentPrimaryTypeID);
                });

            migrationBuilder.CreateTable(
                name: "GarmentSecondaryType",
                columns: table => new
                {
                    GarmentSecondaryTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentSecondaryType", x => x.GarmentSecondaryTypeID);
                });

            migrationBuilder.CreateTable(
                name: "GarmentStyle",
                columns: table => new
                {
                    GarmentStyleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentStyle", x => x.GarmentStyleID);
                });

            migrationBuilder.CreateTable(
                name: "Garment",
                columns: table => new
                {
                    GarmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preferred = table.Column<bool>(type: "bit", nullable: false),
                    DryCleaning = table.Column<bool>(type: "bit", nullable: false),
                    PurchaseYear = table.Column<int>(type: "int", nullable: false),
                    Weather = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    GarmentPrimaryTypeID = table.Column<int>(type: "int", nullable: true),
                    GarmentSecondaryTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garment", x => x.GarmentID);
                    table.ForeignKey(
                        name: "FK_Garment_GarmentPrimaryType_GarmentPrimaryTypeID",
                        column: x => x.GarmentPrimaryTypeID,
                        principalTable: "GarmentPrimaryType",
                        principalColumn: "GarmentPrimaryTypeID");
                    table.ForeignKey(
                        name: "FK_Garment_GarmentSecondaryType_GarmentSecondaryTypeID",
                        column: x => x.GarmentSecondaryTypeID,
                        principalTable: "GarmentSecondaryType",
                        principalColumn: "GarmentSecondaryTypeID");
                });

            migrationBuilder.CreateTable(
                name: "GarmentGarmentColour",
                columns: table => new
                {
                    GarmentColoursGarmentColourID = table.Column<int>(type: "int", nullable: false),
                    GarmentsGarmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentGarmentColour", x => new { x.GarmentColoursGarmentColourID, x.GarmentsGarmentID });
                    table.ForeignKey(
                        name: "FK_GarmentGarmentColour_Garment_GarmentsGarmentID",
                        column: x => x.GarmentsGarmentID,
                        principalTable: "Garment",
                        principalColumn: "GarmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GarmentGarmentColour_GarmentColour_GarmentColoursGarmentColourID",
                        column: x => x.GarmentColoursGarmentColourID,
                        principalTable: "GarmentColour",
                        principalColumn: "GarmentColourID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GarmentGarmentMaterial",
                columns: table => new
                {
                    GarmentMaterialsGarmentMaterialID = table.Column<int>(type: "int", nullable: false),
                    GarmentsGarmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentGarmentMaterial", x => new { x.GarmentMaterialsGarmentMaterialID, x.GarmentsGarmentID });
                    table.ForeignKey(
                        name: "FK_GarmentGarmentMaterial_Garment_GarmentsGarmentID",
                        column: x => x.GarmentsGarmentID,
                        principalTable: "Garment",
                        principalColumn: "GarmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GarmentGarmentMaterial_GarmentMaterial_GarmentMaterialsGarmentMaterialID",
                        column: x => x.GarmentMaterialsGarmentMaterialID,
                        principalTable: "GarmentMaterial",
                        principalColumn: "GarmentMaterialID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GarmentGarmentStyle",
                columns: table => new
                {
                    GarmentStylesGarmentStyleID = table.Column<int>(type: "int", nullable: false),
                    GarmentsGarmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentGarmentStyle", x => new { x.GarmentStylesGarmentStyleID, x.GarmentsGarmentID });
                    table.ForeignKey(
                        name: "FK_GarmentGarmentStyle_Garment_GarmentsGarmentID",
                        column: x => x.GarmentsGarmentID,
                        principalTable: "Garment",
                        principalColumn: "GarmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GarmentGarmentStyle_GarmentStyle_GarmentStylesGarmentStyleID",
                        column: x => x.GarmentStylesGarmentStyleID,
                        principalTable: "GarmentStyle",
                        principalColumn: "GarmentStyleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garment_GarmentPrimaryTypeID",
                table: "Garment",
                column: "GarmentPrimaryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Garment_GarmentSecondaryTypeID",
                table: "Garment",
                column: "GarmentSecondaryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GarmentGarmentColour_GarmentsGarmentID",
                table: "GarmentGarmentColour",
                column: "GarmentsGarmentID");

            migrationBuilder.CreateIndex(
                name: "IX_GarmentGarmentMaterial_GarmentsGarmentID",
                table: "GarmentGarmentMaterial",
                column: "GarmentsGarmentID");

            migrationBuilder.CreateIndex(
                name: "IX_GarmentGarmentStyle_GarmentsGarmentID",
                table: "GarmentGarmentStyle",
                column: "GarmentsGarmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GarmentGarmentColour");

            migrationBuilder.DropTable(
                name: "GarmentGarmentMaterial");

            migrationBuilder.DropTable(
                name: "GarmentGarmentStyle");

            migrationBuilder.DropTable(
                name: "GarmentColour");

            migrationBuilder.DropTable(
                name: "GarmentMaterial");

            migrationBuilder.DropTable(
                name: "Garment");

            migrationBuilder.DropTable(
                name: "GarmentStyle");

            migrationBuilder.DropTable(
                name: "GarmentPrimaryType");

            migrationBuilder.DropTable(
                name: "GarmentSecondaryType");
        }
    }
}

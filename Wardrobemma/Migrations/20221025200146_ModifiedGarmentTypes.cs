using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobemma.Migrations
{
    public partial class ModifiedGarmentTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garment_GarmentPrimaryType_GarmentPrimaryTypeID",
                table: "Garment");

            migrationBuilder.DropForeignKey(
                name: "FK_Garment_GarmentSecondaryType_GarmentSecondaryTypeID",
                table: "Garment");

            migrationBuilder.DropTable(
                name: "GarmentPrimaryType");

            migrationBuilder.DropTable(
                name: "GarmentSecondaryType");

            migrationBuilder.DropIndex(
                name: "IX_Garment_GarmentPrimaryTypeID",
                table: "Garment");

            migrationBuilder.DropColumn(
                name: "GarmentPrimaryTypeID",
                table: "Garment");

            migrationBuilder.RenameColumn(
                name: "GarmentSecondaryTypeID",
                table: "Garment",
                newName: "GarmentTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Garment_GarmentSecondaryTypeID",
                table: "Garment",
                newName: "IX_Garment_GarmentTypeID");

            migrationBuilder.CreateTable(
                name: "GarmentGenericType",
                columns: table => new
                {
                    GarmentGenericTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentGenericType", x => x.GarmentGenericTypeID);
                });

            migrationBuilder.CreateTable(
                name: "GarmentType",
                columns: table => new
                {
                    GarmentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GarmentGenericTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentType", x => x.GarmentTypeID);
                    table.ForeignKey(
                        name: "FK_GarmentType_GarmentGenericType_GarmentGenericTypeID",
                        column: x => x.GarmentGenericTypeID,
                        principalTable: "GarmentGenericType",
                        principalColumn: "GarmentGenericTypeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GarmentType_GarmentGenericTypeID",
                table: "GarmentType",
                column: "GarmentGenericTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Garment_GarmentType_GarmentTypeID",
                table: "Garment",
                column: "GarmentTypeID",
                principalTable: "GarmentType",
                principalColumn: "GarmentTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garment_GarmentType_GarmentTypeID",
                table: "Garment");

            migrationBuilder.DropTable(
                name: "GarmentType");

            migrationBuilder.DropTable(
                name: "GarmentGenericType");

            migrationBuilder.RenameColumn(
                name: "GarmentTypeID",
                table: "Garment",
                newName: "GarmentSecondaryTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Garment_GarmentTypeID",
                table: "Garment",
                newName: "IX_Garment_GarmentSecondaryTypeID");

            migrationBuilder.AddColumn<int>(
                name: "GarmentPrimaryTypeID",
                table: "Garment",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Garment_GarmentPrimaryTypeID",
                table: "Garment",
                column: "GarmentPrimaryTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Garment_GarmentPrimaryType_GarmentPrimaryTypeID",
                table: "Garment",
                column: "GarmentPrimaryTypeID",
                principalTable: "GarmentPrimaryType",
                principalColumn: "GarmentPrimaryTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Garment_GarmentSecondaryType_GarmentSecondaryTypeID",
                table: "Garment",
                column: "GarmentSecondaryTypeID",
                principalTable: "GarmentSecondaryType",
                principalColumn: "GarmentSecondaryTypeID");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage.DAL.Sql.Migrations
{
    public partial class Initialize_Main_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarLocationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarLocationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarLocationEntity_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseLocationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lat = table.Column<decimal>(type: "decimal(10,8)", precision: 10, scale: 8, nullable: false),
                    Long = table.Column<decimal>(type: "decimal(11,8)", precision: 11, scale: 8, nullable: false),
                    WarehouseId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseLocationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseLocationEntity_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearModel = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Licensed = table.Column<bool>(type: "bit", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_CarLocationEntity_CarLocationId",
                        column: x => x.CarLocationId,
                        principalTable: "CarLocationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarLocationId",
                table: "Car",
                column: "CarLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarLocationEntity_WarehouseId",
                table: "CarLocationEntity",
                column: "WarehouseId",
                unique: true,
                filter: "[WarehouseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseLocationEntity_WarehouseId",
                table: "WarehouseLocationEntity",
                column: "WarehouseId",
                unique: true,
                filter: "[WarehouseId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "WarehouseLocationEntity");

            migrationBuilder.DropTable(
                name: "CarLocationEntity");

            migrationBuilder.DropTable(
                name: "Warehouse");
        }
    }
}

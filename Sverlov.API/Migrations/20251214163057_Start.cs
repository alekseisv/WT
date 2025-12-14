using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sverlov.API.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TheTransportTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheTransportTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Automodiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    LiftingCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    parsedDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    TheTransportTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automodiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automodiles_TheTransportTypes_TheTransportTypeId",
                        column: x => x.TheTransportTypeId,
                        principalTable: "TheTransportTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automodiles_TheTransportTypeId",
                table: "Automodiles",
                column: "TheTransportTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automodiles");

            migrationBuilder.DropTable(
                name: "TheTransportTypes");
        }
    }
}
